using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

public class CaptureSectionDrawingForm : Form
{
    private Rectangle highlightRect;
    private Timer animationTimer;
    private int dashOffset;
    private Timer exitTimer;
    private IntPtr previousForegroundWindow;
    private Color[] darkColors = { Color.DarkRed, Color.DarkBlue, Color.DarkGreen, Color.DarkCyan, Color.DarkMagenta, Color.DarkOrange, Color.DarkGray, Color.DarkOliveGreen, Color.DarkSlateGray, Color.DarkSlateBlue, Color.DarkSeaGreen, Color.DarkTurquoise, Color.DarkGoldenrod, Color.DarkOrchid, Color.DarkSalmon, Color.DarkKhaki, Color.DarkViolet };
    private Color randomColor;
    private int animationTimeout;

    public CaptureSectionDrawingForm(Rectangle rect, int timeout)
    {
        this.animationTimeout = timeout;
        Random random = new Random();
        randomColor = darkColors[random.Next(darkColors.Length)];

        previousForegroundWindow = NativeMethods.GetForegroundWindow();
        highlightRect = rect;
        dashOffset = 0;

        // Set form properties
        FormBorderStyle = FormBorderStyle.None;
        WindowState = FormWindowState.Maximized;
        ShowInTaskbar = false;
        TopMost = true;
        BackColor = Color.Orange;
        TransparencyKey = Color.Orange;

        // Set the form opacity to 50% (adjust as desired)
        // Opacity = 0.5;

        // Make the form click-through
        int initialStyle = NativeMethods.GetWindowLong(this.Handle, -20);
        NativeMethods.SetWindowLong(this.Handle, -20, initialStyle | 0x80000);

        // Create a timer for animation
        animationTimer = new Timer();
        animationTimer.Interval = 50; // Set the interval (adjust as desired)
        animationTimer.Tick += AnimationTimer_Tick;
        animationTimer.Start();

        // Create a timer for exiting after the specified timeout
        exitTimer = new Timer();
        exitTimer.Interval = animationTimeout;
        exitTimer.Tick += ExitTimer_Tick;
        exitTimer.Start();

        // Register the paint event handler
        Paint += CaptureSectionDrawingForm_Paint;
    }

    private void CaptureSectionDrawingForm_Paint(object sender, PaintEventArgs e)
    {
        NativeMethods.SetForegroundWindow(previousForegroundWindow);
        // Draw the animated dashed border with a thicker width
        using (Pen pen = new Pen(randomColor, 2)) // Set the width (adjust as desired)
        {
            pen.DashStyle = DashStyle.Dash;
            pen.DashPattern = new float[] { 3, 3 }; // Customize the pattern (adjust as desired)
            pen.DashOffset = dashOffset;
            e.Graphics.DrawRectangle(pen, highlightRect);
        }
    }

    private void AnimationTimer_Tick(object sender, EventArgs e)
    {
        dashOffset++;
        if (dashOffset > 100) // Adjust the maximum offset (adjust as desired)
            dashOffset = 0;

        Invalidate(); // Redraw the form
    }

    private void ExitTimer_Tick(object sender, EventArgs e)
    {
        exitTimer.Stop(); // Stop the exit timer
        animationTimer.Stop(); // Stop the animation timer

        // Terminate the form
        Close();
    }

    protected override void OnActivated(EventArgs e)
    {
        base.OnActivated(e);

        // Store the handle of the previous foreground window
        // previousForegroundWindow = NativeMethods.GetForegroundWindow();
    }

    protected override void OnShown(EventArgs e)
    {
        base.OnShown(e);

        // Set the focus back to the previous foreground window
        NativeMethods.SetForegroundWindow(previousForegroundWindow);
    }

    // Native methods for click-through functionality
    private static class NativeMethods
    {
        [System.Runtime.InteropServices.DllImport("user32.dll", CharSet = System.Runtime.InteropServices.CharSet.Auto, SetLastError = true)]
        public static extern int GetWindowLong(IntPtr hWnd, int nIndex);

        [System.Runtime.InteropServices.DllImport("user32.dll", CharSet = System.Runtime.InteropServices.CharSet.Auto, SetLastError = true)]
        public static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern IntPtr GetForegroundWindow();

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool SetForegroundWindow(IntPtr hWnd);
    }
}
