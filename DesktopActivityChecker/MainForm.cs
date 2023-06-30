using System;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;
using Newtonsoft.Json;
using ShareX;
using ShareX.ScreenCaptureLib;
using System.Threading;
using ShareX.HelpersLib;
using System.Drawing.Imaging;
using System.Threading.Tasks;
using System.Linq;

namespace DesktopActivityChecker
{
    public partial class MainForm : Form
    {
        private readonly Dictionary<string, Dictionary<string, object>> entryData = new Dictionary<string, Dictionary<string, object>>();
        private string regionSvgContent = @"<svg xmlns='http://www.w3.org/2000/svg' xmlns:xlink='http://www.w3.org/1999/xlink' width='16px' height='16px' viewBox='0 0 16 16' version='1.1'><g id='surface1'><path style=' stroke:none;fill-rule:nonzero;fill:rgb(0%,0%,0%);fill-opacity:1;' d='M 14 2.5 L 14 6 C 14 6.277344 13.777344 6.5 13.5 6.5 C 13.222656 6.5 13 6.277344 13 6 L 13 3 L 10 3 C 9.722656 3 9.5 2.777344 9.5 2.5 C 9.5 2.222656 9.722656 2 10 2 L 13.5 2 C 13.777344 2 14 2.222656 14 2.5 Z M 6 2 L 2.5 2 C 2.222656 2 2 2.222656 2 2.5 L 2 6 C 2 6.277344 2.222656 6.5 2.5 6.5 C 2.777344 6.5 3 6.277344 3 6 L 3 3 L 6 3 C 6.277344 3 6.5 2.777344 6.5 2.5 C 6.5 2.222656 6.277344 2 6 2 Z M 13.5 9.5 C 13.222656 9.5 13 9.722656 13 10 L 13 13 L 10 13 C 9.722656 13 9.5 13.222656 9.5 13.5 C 9.5 13.777344 9.722656 14 10 14 L 13.5 14 C 13.777344 14 14 13.777344 14 13.5 L 14 10 C 14 9.722656 13.777344 9.5 13.5 9.5 Z M 6 13 L 3 13 L 3 10 C 3 9.722656 2.777344 9.5 2.5 9.5 C 2.222656 9.5 2 9.722656 2 10 L 2 13.5 C 2 13.777344 2.222656 14 2.5 14 L 6 14 C 6.277344 14 6.5 13.777344 6.5 13.5 C 6.5 13.222656 6.277344 13 6 13 Z M 6 13 '/></g></svg>";
        private string editSvgContent = @"<svg xmlns='http://www.w3.org/2000/svg' xmlns:xlink='http://www.w3.org/1999/xlink' width='16px' height='16px' viewBox='0 0 16 16' version='1.1'><g id='surface1'><rect x='0' y='0' width='16' height='16' style='fill:rgb(100%,100%,100%);fill-opacity:0.0117647;stroke:none;'/><path style='fill:none;stroke-width:4;stroke-linecap:round;stroke-linejoin:round;stroke:rgb(0%,0%,0%);stroke-opacity:1;stroke-miterlimit:4;' d='M 6.996094 42 L 42.996094 42 ' transform='matrix(0.333333,0,0,0.333333,0,0)'/><path style='fill-rule:nonzero;fill:rgb(18.431373%,53.333333%,100%);fill-opacity:1;stroke-width:4;stroke-linecap:butt;stroke-linejoin:round;stroke:rgb(0%,0%,0%);stroke-opacity:1;stroke-miterlimit:4;' d='M 11.003906 26.71875 L 11.003906 33.996094 L 18.316406 33.996094 L 39 13.3125 L 31.699219 6 Z M 11.003906 26.71875 ' transform='matrix(0.333333,0,0,0.333333,0,0)'/></g></svg>";
        private string deleteSvgContent = @"<svg xmlns='http://www.w3.org/2000/svg' xmlns:xlink='http://www.w3.org/1999/xlink' width='16px' height='16px' viewBox='0 0 16 16' version='1.1'><g id='surface1'><path style=' stroke:none;fill-rule:nonzero;fill:rgb(5.490196%,48.627451%,78.823529%);fill-opacity:1;' d='M 13.332031 3.332031 L 13.332031 13.332031 C 13.332031 14.4375 12.4375 15.332031 11.332031 15.332031 L 4.667969 15.332031 C 3.5625 15.332031 2.667969 14.4375 2.667969 13.332031 L 2.667969 3.332031 Z M 13.332031 3.332031 '/><path style=' stroke:none;fill-rule:nonzero;fill:rgb(27.843137%,65.098039%,89.019608%);fill-opacity:1;' d='M 13.332031 3.332031 L 13.332031 10 C 13.332031 11.105469 12.4375 12 11.332031 12 L 4.667969 12 C 3.5625 12 2.667969 11.105469 2.667969 10 L 2.667969 3.332031 Z M 13.332031 3.332031 '/><path style=' stroke:none;fill-rule:nonzero;fill:rgb(42.352941%,18.039216%,48.627451%);fill-opacity:1;' d='M 8.667969 0 L 7.332031 0 C 6.230469 0 5.332031 0.894531 5.332031 2 L 5.332031 2.667969 L 1.332031 2.667969 C 0.964844 2.667969 0.667969 2.964844 0.667969 3.332031 C 0.667969 3.703125 0.964844 4 1.332031 4 L 2 4 L 2 13.332031 C 2 14.804688 3.195312 16 4.667969 16 L 11.332031 16 C 12.804688 16 14 14.804688 14 13.332031 L 14 4 L 14.667969 4 C 15.035156 4 15.332031 3.703125 15.332031 3.332031 C 15.332031 2.964844 15.035156 2.667969 14.667969 2.667969 L 10.667969 2.667969 L 10.667969 2 C 10.667969 0.894531 9.769531 0 8.667969 0 Z M 6.667969 2 C 6.667969 1.632812 6.964844 1.332031 7.332031 1.332031 L 8.667969 1.332031 C 9.035156 1.332031 9.332031 1.632812 9.332031 2 L 9.332031 2.667969 L 6.667969 2.667969 Z M 12.667969 13.332031 C 12.667969 14.070312 12.070312 14.667969 11.332031 14.667969 L 4.667969 14.667969 C 3.929688 14.667969 3.332031 14.070312 3.332031 13.332031 L 3.332031 4 L 12.667969 4 Z M 12.667969 13.332031 '/><path style=' stroke:none;fill-rule:nonzero;fill:rgb(42.352941%,18.039216%,48.627451%);fill-opacity:1;' d='M 8 6 C 7.632812 6 7.332031 6.296875 7.332031 6.667969 L 7.332031 12 C 7.332031 12.367188 7.632812 12.667969 8 12.667969 C 8.367188 12.667969 8.667969 12.367188 8.667969 12 L 8.667969 6.667969 C 8.667969 6.296875 8.367188 6 8 6 Z M 8 6 '/><path style=' stroke:none;fill-rule:nonzero;fill:rgb(42.352941%,18.039216%,48.627451%);fill-opacity:1;' d='M 10 12 C 10 12.367188 10.296875 12.667969 10.667969 12.667969 C 11.035156 12.667969 11.332031 12.367188 11.332031 12 L 11.332031 6.667969 C 11.332031 6.296875 11.035156 6 10.667969 6 C 10.296875 6 10 6.296875 10 6.667969 Z M 10 12 '/><path style=' stroke:none;fill-rule:nonzero;fill:rgb(42.352941%,18.039216%,48.627451%);fill-opacity:1;' d='M 5.332031 6 C 4.964844 6 4.667969 6.296875 4.667969 6.667969 L 4.667969 12 C 4.667969 12.367188 4.964844 12.667969 5.332031 12.667969 C 5.703125 12.667969 6 12.367188 6 12 L 6 6.667969 C 6 6.296875 5.703125 6 5.332031 6 Z M 5.332031 6 '/></g></svg>";
        private string activityBase64ContentWhite = "iVBORw0KGgoAAAANSUhEUgAAADIAAAAyCAYAAAAeP4ixAAAACXBIWXMAAAsTAAALEwEAmpwYAAACoUlEQVR4nO2YXYhNURTH950wTPmK4gl5MUooKaGmRsoMb9I8DFOTJA++okQy0ryN5kGh8aTIi5TBgzKICS/kxYhkqJFvEUWR+Wmbc9mWdfY913Rudu3f21lrnbXX/7T3XuteYyKRSCQSMsAcoBe4CzSaUAFu8Jv3QLUJDaAG+MafLDChASzlb1pNaADbFCGdJjSAk4qQSyY0gIeKkNcmJIDxwHd0pphQAOpJZ7kJBWCXR8gOEwrAaY+Q4yYUgKceIXfM/wRQAJqAre4BBiaLwmV3/wKM8ORdabcfML1SQvY5xT0qzlHAClH4beC5sM1OybneiXkFTMxbxCTgoyhujSLQchS4KGxNKXnvi7gteQtpV/b+hcR3TtjtV+4QtnYl56KKnieGmp0dyVHOwlRlG80DWoStW8nbhc7cvITsJ51O5WCPBOYL+xORc0zKx7EcHE6xjXYxyuereL6Z5KsWvkFgnLPeWk/OF8VbDths57UMddjaG+wLzzIW/k65Xl0OOcXeE74lju9yiXVWAXXJB8jKgE08kDF4D3De41/nFHtK+DYl9hnKgHlVPHcDfZTHTyENQL8nyG6TM8BoYLUn7le/AHYL35HE3ibst4DFDI9+28/KPU+jgDdKMttnqpw4uz1cepPp4LGwb0jiH3gKPfZvp7+0mMPKYldEzDTh/wAsE7bPwIQkfm+KiLd2DMpLyEJlwQ4RU1Cu2Gvi+YQQrv04a8lFhLNwX6kxBLiOn3oR36NcAoW8hbQ6C74sbpEMW9C9+6uUSXgw8X8CanMVIRrpdrstUvwbPULaUt6pA3ZWTEQWPNeq/eozTSgAY1O6c48JDfRG22xCAzir9JMaExrAASGky4QIUJtcpcUxZpYJFYa6dnPF/imJRCKRSMSUzw/UmWH9EtnbFgAAAABJRU5ErkJggg==";
        private string lastPostRequestURL = ReadLastPostRequertURLFromJson();
        private string lastPostMessage = ReadLastPostMessageFromJson();

        public MainForm()
        {
            FormBorderStyle = FormBorderStyle.FixedSingle;
            WindowState = FormWindowState.Minimized;
            ShowInTaskbar = false;

            byte[] iconBytesWhite = Convert.FromBase64String(activityBase64ContentWhite);
            Icon titleBarIcon;
            using (MemoryStream memoryStream = new MemoryStream(iconBytesWhite))
            {
                Image image = Image.FromStream(memoryStream);
                titleBarIcon = Icon.FromHandle(((Bitmap)image).GetHicon());
            }

            Icon = titleBarIcon;
            FormClosing += MainForm_FormClosing;
            Resize += MainForm_Resize;

            InitializeComponent();
            comboBoxComparisonOption.SelectedIndex = 0;
            comboBoxWaitFor.SelectedIndex = 0;
            comboBoxMatchCaptures.SelectedIndex = 0;
            comboBoxColorMatches.SelectedIndex = -1;

            using (var stream = new System.IO.MemoryStream(System.Text.Encoding.UTF8.GetBytes(regionSvgContent)))
            {
                var svgDocument = Svg.SvgDocument.Open<Svg.SvgDocument>(stream);
                regionPicker.Image = svgDocument.Draw();
            }
            dataGridView1.DataSource = ReadExistingFormDataFromJson();
            entryPostRequestUrl.Text = lastPostRequestURL;
            entryPostMessage.Text = lastPostMessage;

            // Create a new thread and start it
            Thread newThread = new Thread(MonitoringService);
            newThread.Start();
        }

        #region MainForm FormClosed, FormClosing, Resize, MouseClick
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true; // Cancel the form closing event
                WindowState = FormWindowState.Minimized; // Minimize the form to the tray
            }
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                Hide(); // Hide the form when minimized
            }
        }
        #endregion

        #region Validations definitions and execution
        private bool ValidateStringEmpty(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return true;
            }
            return false;
        }

        private bool ValidateName()
        {
            string name = entryName.Text.Trim();
            if (string.IsNullOrEmpty(name))
            {
                return false;
            }
            else if (entryData.ContainsKey(name))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private bool ValidateNumeric(string value, int minValue = 0, int maxValue = 100000)
        {
            if (int.TryParse(value, out int num))
            {
                // return num > 0 && num < 100000;
                return num >= minValue && num <= maxValue;
            }
            else
            {
                return false;
            }
        }

        private bool ValidateUrl()
        {
            string url = entryPostRequestUrl.Text.Trim();
            return Regex.IsMatch(url, @"^(http|https)://[\w-]+(\.[\w-]+)+([\w.,@?^=%&:/~+#-]*[\w@?^=%&/~+#-])?$");
        }

        private bool RunValidations()
        {
            if (!ValidateName())
            {
                MessageBox.Show("Invalid name!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (!ValidateNumeric(entryX.Text, maxValue: 10000))
            {
                MessageBox.Show("Invalid X value!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (!ValidateNumeric(entryY.Text, maxValue: 10000))
            {
                MessageBox.Show("Invalid Y value!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (!ValidateNumeric(entryWidth.Text, maxValue: 10000))
            {
                MessageBox.Show("Invalid width!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (!ValidateNumeric(entryHeight.Text, maxValue: 10000))
            {
                MessageBox.Show("Invalid height!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (!ValidateNumeric(entryRepeatTime.Text, minValue: 10))
            {
                MessageBox.Show("Invalid repeat time, minimum value should be 10!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (comboBoxComparisonOption.SelectedItem.ToString() == "Match from Initial Capture" || comboBoxComparisonOption.SelectedItem.ToString() == "Match from Last Capture" || comboBoxComparisonOption.SelectedItem.ToString() == "Check same color background")
            {
                if (!(ValidateStringEmpty(entryComparisonValue.Text) && ValidateStringEmpty(entryOCRRegex.Text) && ValidateStringEmpty(entryOCRRegexGroup.Text) && ValidateStringEmpty(entryScaleFactor.Text)))
                {
                    MessageBox.Show("'Value To Compare': `"+ entryComparisonValue.Text + "`, 'OCR Regex': `" + entryOCRRegex.Text + "`, 'OCR Regex Group': `" + entryOCRRegexGroup.Text + "` or 'Scale Factor': `" + entryScaleFactor.Text + "` is not empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                if (comboBoxColorMatches.SelectedIndex != -1)
                {
                    MessageBox.Show("'Color Matches': `" + comboBoxColorMatches.SelectedItem.ToString() + " (" + comboBoxColorMatches.SelectedIndex + ")` is not empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            else if (comboBoxComparisonOption.SelectedItem.ToString() == "OCR compare")
            {
                if (ValidateStringEmpty(entryComparisonValue.Text) || ValidateStringEmpty(entryOCRRegex.Text) || ValidateStringEmpty(entryOCRRegexGroup.Text) || ValidateStringEmpty(entryScaleFactor.Text))
                {
                    MessageBox.Show("'Value To Compare': `" + entryComparisonValue.Text + "`, 'OCR Regex': `" + entryOCRRegex.Text + "`, 'OCR Regex Group': `" + entryOCRRegexGroup.Text + "` or 'Scale Factor': `" + entryScaleFactor.Text + "` is empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                if (comboBoxColorMatches.SelectedIndex != -1)
                {
                    MessageBox.Show("'Color Matches': `" + comboBoxColorMatches.SelectedItem.ToString() +" ("+ comboBoxColorMatches.SelectedIndex + ")` is not empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            else if (comboBoxComparisonOption.SelectedItem.ToString() == "Check pixel color present")
            {
                if (ValidateStringEmpty(entryComparisonValue.Text))
                {
                    MessageBox.Show("'Color To Compare' is empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                if (!(ValidateStringEmpty(entryOCRRegex.Text) && ValidateStringEmpty(entryOCRRegexGroup.Text) && ValidateStringEmpty(entryScaleFactor.Text)))
                {
                    MessageBox.Show("'OCR Regex': `" + entryOCRRegex.Text + "`, 'OCR Regex Group': `" + entryOCRRegexGroup.Text + "` or 'Scale Factor': `" + entryScaleFactor.Text + "` is not empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                if (comboBoxColorMatches.SelectedIndex == -1)
                {
                    MessageBox.Show("'Color Matches': `" + comboBoxColorMatches.SelectedItem.ToString() + " (" + comboBoxColorMatches.SelectedIndex + ")` is empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            else
            {
                MessageBox.Show("Unknown 'Comparison Option' is selected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (!ValidateNumeric(entrySleepBetweenCaptures.Text, minValue: 200))
            {
                MessageBox.Show("Invalid sleep between captures, minimum value should be 200!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (!ValidateNumeric(entryCapturePerInterval.Text, minValue: 1))
            {
                MessageBox.Show("Invalid capture per interval, minimum value should be 1!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if ( Convert.ToInt32(entrySleepBetweenCaptures.Text) * Convert.ToInt32(entryCapturePerInterval.Text) > Convert.ToInt32(entryRepeatTime.Text)*1000 )
            {
                MessageBox.Show("'Sleep between captures' * 'Capture per interval' is greater then 'Repeat Time'. Another run will occur before all captures completes.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (!ValidateUrl())
            {
                MessageBox.Show("Invalid POST request URL!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
        #endregion

        private static string GetDataStorePath()
        {
            string projectDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string directoryName = Directory.GetParent(projectDirectory).Name;
            if (directoryName == "Debug")
            {
                projectDirectory = Directory.GetParent(Directory.GetParent(Directory.GetParent(projectDirectory).FullName).FullName).FullName;
            }
            return Path.Combine(projectDirectory, "./datastore/entries.json");
        }

        private FormData GetDataFromFields()
        {
            return new FormData
            {
                Id = string.IsNullOrEmpty(entryId.Text) ? Convert.ToInt32(ReadLastIdFromJson()) + 1 : Convert.ToInt32(entryId.Text),
                Name = entryName.Text,
                X = entryX.Text,
                Y = entryY.Text,
                Width = entryWidth.Text,
                Height = entryHeight.Text,
                RepeatTime = entryRepeatTime.Text,
                ComparisonOption = comboBoxComparisonOption.SelectedItem.ToString(),
                WaitFor = comboBoxWaitFor.SelectedItem.ToString(),
                ComparisonValue = entryComparisonValue.Text,
                OCRRegex = entryOCRRegex.Text,
                OCRRegexGroup = entryOCRRegexGroup.Text,
                ScaleFactor = entryScaleFactor.Text,
                ColorMatches = comboBoxColorMatches.SelectedIndex >= 0 ? comboBoxColorMatches.SelectedItem.ToString() : "",
                SleepBetweenCaptures = entrySleepBetweenCaptures.Text,
                CapturePerInterval = entryCapturePerInterval.Text,
                MatchCaptures = comboBoxMatchCaptures.SelectedItem.ToString(),
                PostRequestUrl = entryPostRequestUrl.Text,
                PostMessage = entryPostMessage.Text,
                Enabled = checkBoxEnabled.Checked
            };
            
        }

        private void ClearAllFields()
        {
            // Clear the entry fields
            entryId.Clear();
            entryName.Clear();
            entryX.Clear();
            entryY.Clear();
            entryWidth.Clear();
            entryHeight.Clear();
            entryRepeatTime.Clear();
            comboBoxComparisonOption.SelectedIndex = 0;
            comboBoxWaitFor.SelectedIndex = 0;
            entryComparisonValue.Clear();
            entryOCRRegex.Clear();
            entryOCRRegexGroup.Clear();
            entryScaleFactor.Clear();
            comboBoxColorMatches.SelectedIndex = -1;
            entrySleepBetweenCaptures.Clear();
            entryCapturePerInterval.Clear();
            comboBoxMatchCaptures.SelectedIndex = 0;
            entryPostRequestUrl.Text = lastPostRequestURL;
            entryPostMessage.Text = lastPostMessage;
            checkBoxEnabled.Checked = true;

            entrySleepBetweenCaptures.Text = "250";
            entryCapturePerInterval.Text = "10";
        }

        private static int ReadLastIdFromJson()
        {
            string filePath = GetDataStorePath();
            if (File.Exists(filePath))
            {
                try
                {
                    string jsonData = File.ReadAllText(filePath);
                    List<FormData> allFormData = JsonConvert.DeserializeObject<List<FormData>>(jsonData);
                    FormData lastElement = allFormData[allFormData.Count - 1];
                    return lastElement.Id;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred while reading the JSON file: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            return 0; // Return 0 if the JSON file doesn't exist or couldn't be read
        }

        private static string ReadLastPostRequertURLFromJson()
        {
            string filePath = GetDataStorePath();
            if (File.Exists(filePath))
            {
                try
                {
                    string jsonData = File.ReadAllText(filePath);
                    List<FormData> allFormData = JsonConvert.DeserializeObject<List<FormData>>(jsonData);
                    FormData lastElement = allFormData[allFormData.Count - 1];
                    return lastElement.PostRequestUrl;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred while reading the JSON file: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            return "https://www.ntfy.sh/"; // Return default if the JSON file doesn't exist or couldn't be read
        }

        private static string ReadLastPostMessageFromJson()
        {
            string filePath = GetDataStorePath();
            if (File.Exists(filePath))
            {
                try
                {
                    string jsonData = File.ReadAllText(filePath);
                    List<FormData> allFormData = JsonConvert.DeserializeObject<List<FormData>>(jsonData);
                    FormData lastElement = allFormData[allFormData.Count - 1];
                    return lastElement.PostMessage;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred while reading the JSON file: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            return ""; // Return default if the JSON file doesn't exist or couldn't be read
        }

        private static List<FormData> ReadExistingFormDataFromJson()
        {
            string filePath = GetDataStorePath();
            if (File.Exists(filePath))
            {
                try
                {
                    string jsonData = File.ReadAllText(filePath);
                    List<FormData> existingFormDataList = JsonConvert.DeserializeObject<List<FormData>>(jsonData);
                    return existingFormDataList ?? new List<FormData>();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred while reading exisiting form data to the JSON file: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            return new List<FormData>();
        }

        #region Crud Operations
        private void AddEntry()
        {
            if (RunValidations())
            {
                FormData formData = GetDataFromFields();
                try
                {
                    string filePath = GetDataStorePath();
                    List<FormData> existingFormDataList = ReadExistingFormDataFromJson();
                    existingFormDataList.Add(formData);
                    string jsonData = JsonConvert.SerializeObject(existingFormDataList, Formatting.Indented);
                    File.WriteAllText(filePath, jsonData);
                    MessageBox.Show("Form data has been saved to the JSON file.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    lastPostRequestURL = entryPostRequestUrl.Text;
                    lastPostMessage = entryPostMessage.Text;
                    ClearAllFields();

                    dataGridView1.DataSource = ReadExistingFormDataFromJson();
                    buttonCreate.Text = "Create";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred while saving the form data to the JSON file: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void DeleteEntry(int id)
        {
            List<FormData> formData = ReadExistingFormDataFromJson();
            FormData formDataToDelete = formData.Find(p => p.Id == id);
            if (formDataToDelete != null)
            {
                formData.Remove(formDataToDelete);
                for (int i = 0; i < formData.Count; i++)
                {
                    formData[i].Id = i + 1;
                }
                string jsonData = JsonConvert.SerializeObject(formData, Formatting.Indented);
                File.WriteAllText(GetDataStorePath(), jsonData);
            }
        }

        private void EditShowEntry(int id)
        {
            List<FormData> formData = ReadExistingFormDataFromJson();
            FormData formDataToEdit = formData.Find(p => p.Id == id);
            if (formDataToEdit != null)
            {
                entryId.Text = Convert.ToString(formDataToEdit.Id);
                entryName.Text = formDataToEdit.Name;
                entryX.Text = formDataToEdit.X;
                entryY.Text = formDataToEdit.Y;
                entryWidth.Text = formDataToEdit.Width;
                entryHeight.Text = formDataToEdit.Height;
                entryRepeatTime.Text = formDataToEdit.RepeatTime;
                comboBoxComparisonOption.SelectedIndex = -1;
                foreach (var item in comboBoxComparisonOption.Items)
                {
                    if (item.ToString() == formDataToEdit.ComparisonOption)
                    {
                        comboBoxComparisonOption.SelectedItem = item;
                        break;
                    }
                }
                comboBoxWaitFor.SelectedIndex = -1;
                foreach (var item in comboBoxWaitFor.Items)
                {
                    if (item.ToString() == formDataToEdit.WaitFor)
                    {
                        comboBoxWaitFor.SelectedItem = item;
                        break;
                    }
                }
                entryComparisonValue.Text = formDataToEdit.ComparisonValue;
                entryOCRRegex.Text = formDataToEdit.OCRRegex;
                entryOCRRegexGroup.Text = formDataToEdit.OCRRegexGroup;
                entryScaleFactor.Text = formDataToEdit.ScaleFactor;
                comboBoxColorMatches.SelectedIndex = -1;
                foreach (var item in comboBoxColorMatches.Items)
                {
                    if (item.ToString() == formDataToEdit.ColorMatches)
                    {
                        comboBoxColorMatches.SelectedItem = item;
                        break;
                    }
                }
                entrySleepBetweenCaptures.Text = formDataToEdit.SleepBetweenCaptures;
                entryCapturePerInterval.Text = formDataToEdit.CapturePerInterval;
                comboBoxMatchCaptures.SelectedIndex = -1;
                foreach (var item in comboBoxMatchCaptures.Items)
                {
                    if (item.ToString() == formDataToEdit.MatchCaptures)
                    {
                        comboBoxMatchCaptures.SelectedItem = item;
                        break;
                    }
                }
                entryPostRequestUrl.Text = formDataToEdit.PostRequestUrl;
                entryPostMessage.Text = formDataToEdit.PostMessage;
                checkBoxEnabled.Checked = formDataToEdit.Enabled;

                buttonCreate.Text = "Update";
                mainTabControl.SelectTab(tabCreateEditEntry);
            }
        }

        private void EditUpdateEntry()
        {
            if (RunValidations())
            {
                string filePath = GetDataStorePath();
                FormData newFormData = GetDataFromFields();
                try
                {
                    List<FormData> formData = ReadExistingFormDataFromJson();
                    FormData formDataToUpdate = formData.Find(p => p.Id == newFormData.Id);
                    if (formDataToUpdate != null)
                    {
                        formDataToUpdate.Id = Convert.ToInt32(entryId.Text);
                        formDataToUpdate.Name = entryName.Text;
                        formDataToUpdate.X = entryX.Text;
                        formDataToUpdate.Y = entryY.Text;
                        formDataToUpdate.Width = entryWidth.Text;
                        formDataToUpdate.Height = entryHeight.Text;
                        formDataToUpdate.RepeatTime = entryRepeatTime.Text;
                        formDataToUpdate.ComparisonOption = comboBoxComparisonOption.SelectedItem.ToString();
                        formDataToUpdate.WaitFor = comboBoxWaitFor.SelectedItem.ToString();
                        formDataToUpdate.ComparisonValue = entryComparisonValue.Text;
                        formDataToUpdate.OCRRegex = entryOCRRegex.Text;
                        formDataToUpdate.OCRRegexGroup = entryOCRRegexGroup.Text;
                        formDataToUpdate.ScaleFactor = entryScaleFactor.Text;
                        formDataToUpdate.ColorMatches = comboBoxColorMatches.SelectedIndex == -1 ? "" : comboBoxColorMatches.SelectedItem.ToString();
                        formDataToUpdate.SleepBetweenCaptures = entrySleepBetweenCaptures.Text;
                        formDataToUpdate.CapturePerInterval = entryCapturePerInterval.Text;
                        formDataToUpdate.MatchCaptures = comboBoxMatchCaptures.SelectedItem.ToString();
                        formDataToUpdate.PostRequestUrl = entryPostRequestUrl.Text;
                        formDataToUpdate.PostMessage = entryPostMessage.Text;
                        formDataToUpdate.Enabled = checkBoxEnabled.Checked;
                        
                        string jsonData = JsonConvert.SerializeObject(formData, Formatting.Indented);
                        File.WriteAllText(filePath, jsonData);
                        lastPostRequestURL = entryPostRequestUrl.Text;
                        lastPostMessage = entryPostMessage.Text;
                        MessageBox.Show("Form data has been updated to the JSON file.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ClearAllFields();
                    }
                    dataGridView1.DataSource = ReadExistingFormDataFromJson();
                    buttonCreate.Text = "Create";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred while saving the form data to the JSON file: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void UpdateEnabledDisabled(int id, bool isEnabled)
        {
            string filePath = GetDataStorePath();
            List<FormData> formData = ReadExistingFormDataFromJson();
            FormData formDataToUpdate = formData.Find(p => p.Id == id);
            if (formDataToUpdate != null)
            {
                formDataToUpdate.Enabled = isEnabled;
                string jsonData = JsonConvert.SerializeObject(formData, Formatting.Indented);
                File.WriteAllText(filePath, jsonData);
            }
        }
        #endregion

        #region GUI Event Handlers
        private void comboBoxComparisonOption_SelectedIndexChanged(object sender, EventArgs e)
        {
            entryComparisonValue.Text = "";
            entryOCRRegex.Text = "";
            entryOCRRegexGroup.Text = "";
            entryScaleFactor.Text = "";
            comboBoxColorMatches.SelectedIndex = -1;
            // Change "Labels and Controls" visibility according to the "Comparison Option" selected.
            if (comboBoxComparisonOption.SelectedIndex == 0 || comboBoxComparisonOption.SelectedIndex == 1 || comboBoxComparisonOption.SelectedIndex == 4)
            {
                labelComparisonValue.Visible = false;
                entryComparisonValue.Visible = false;
                labelOCRRegex.Visible = false;
                entryOCRRegex.Visible = false;
                labelOCRRegexGroup.Visible = false;
                entryOCRRegexGroup.Visible = false;
                labelScaleFactor.Visible = false;
                entryScaleFactor.Visible = false;
                labelColorMatches.Visible = false;
                comboBoxColorMatches.Visible = false;
            }
            else if (comboBoxComparisonOption.SelectedIndex == 2)
            {
                labelComparisonValue.Visible = true;
                entryComparisonValue.Visible = true;
                labelOCRRegex.Visible = true;
                entryOCRRegex.Visible = true;
                labelOCRRegexGroup.Visible = true;
                entryOCRRegexGroup.Visible = true;
                labelScaleFactor.Visible = true;
                entryScaleFactor.Visible = true;
                entryScaleFactor.Text = "4";
                labelColorMatches.Visible = false;
                comboBoxColorMatches.Visible = false;
            }
            else if(comboBoxComparisonOption.SelectedIndex == 3)
            {
                labelComparisonValue.Visible = true;
                entryComparisonValue.Visible = true;
                labelOCRRegex.Visible = false;
                entryOCRRegex.Visible = false;
                labelOCRRegexGroup.Visible = false;
                entryOCRRegexGroup.Visible = false;
                labelScaleFactor.Visible = false;
                entryScaleFactor.Visible = false;
                labelColorMatches.Visible = true;
                comboBoxColorMatches.Visible = true;
                comboBoxColorMatches.SelectedIndex = 0;
            }

            // Change "Wait For" label value according to the "Comparison Option" selected.
            if (comboBoxComparisonOption.SelectedIndex == 2)
            {
                comboBoxWaitFor.Items.Clear();
                comboBoxWaitFor.Items.Add("Numeric.==");
                comboBoxWaitFor.Items.Add("Numeric.!=");
                comboBoxWaitFor.Items.Add("Numeric.>");
                comboBoxWaitFor.Items.Add("Numeric.>=");
                comboBoxWaitFor.Items.Add("Numeric.<");
                comboBoxWaitFor.Items.Add("Numeric.<=");
                comboBoxWaitFor.Items.Add("String.Equality");
                comboBoxWaitFor.Items.Add("String.Non Equality");
                comboBoxWaitFor.SelectedIndex = 0;
            }
            else if(comboBoxComparisonOption.SelectedIndex == 3 || comboBoxComparisonOption.SelectedIndex == 4)
            {
                comboBoxWaitFor.Items.Clear();
                comboBoxWaitFor.Items.Add("Present");
                comboBoxWaitFor.Items.Add("Not Present");
                comboBoxWaitFor.SelectedIndex = 0;
            }
            else
            {
                comboBoxWaitFor.Items.Clear();
                comboBoxWaitFor.Items.Add("Equality");
                comboBoxWaitFor.Items.Add("Non Equality");
                comboBoxWaitFor.SelectedIndex = 0;
            }

            // Change "Comparison Value" label value according to the "Comparison Option" selected.
            if (comboBoxComparisonOption.SelectedIndex == 3)
            {
                labelComparisonValue.Text = "Color To Compare (seperated by comma and prefix by #):";
            }
            else
            {
                labelComparisonValue.Text = "Value To Compare:";
            }
        }

        private void regionPicker_Click(object sender, EventArgs e)
        {
            SettingManager.LoadInitialSettings();
            // new CaptureRegion().Capture(true);
            this.WindowState = FormWindowState.Minimized;
            this.Hide();
            TaskSettings taskSettings = TaskSettings.GetDefaultTaskSettings();
            Screenshot screenshot = TaskHelpers.GetScreenshot(taskSettings);
            screenshot.CaptureCursor = false;
            RegionCaptureForm form = new RegionCaptureForm(RegionCaptureMode.Annotation, taskSettings.CaptureSettingsReference.SurfaceOptions, screenshot.CaptureFullscreen());
            form.ShowDialog();
            Console.WriteLine("Form has been closed, the cords are");
            Rectangle rect = form.GetCoordsOfSelection();
            Console.WriteLine(rect);
            this.Show();
            this.WindowState = FormWindowState.Normal;

            entryX.Text = rect.X.ToString();
            entryY.Text = rect.Y.ToString();
            entryWidth.Text = rect.Width.ToString();
            entryHeight.Text = rect.Height.ToString();
        }

        private void buttonCreate_Click(object sender, EventArgs e)
        {
            if (entryId.Text == "")
            { 
                AddEntry();
            }
            else
            {
                EditUpdateEntry();
            }
        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            ClearAllFields();

            dataGridView1.DataSource = ReadExistingFormDataFromJson();
            buttonCreate.Text = "Create";
        }
        #endregion

        #region dataGridView GUI Event Handlers
        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name == "Edit")
            {
                Image editSvgImage;
                using (var stream = new System.IO.MemoryStream(System.Text.Encoding.UTF8.GetBytes(editSvgContent)))
                {
                    var svgDocument = Svg.SvgDocument.Open<Svg.SvgDocument>(stream);
                    editSvgImage = svgDocument.Draw();
                }
                e.Value = new Bitmap(editSvgImage);
            }
            else if (dataGridView1.Columns[e.ColumnIndex].Name == "Delete")
            {
                Image deleteSvgImage;
                using (var stream = new System.IO.MemoryStream(System.Text.Encoding.UTF8.GetBytes(deleteSvgContent)))
                {
                    var svgDocument = Svg.SvgDocument.Open<Svg.SvgDocument>(stream);
                    deleteSvgImage = svgDocument.Draw();
                }
                e.Value = new Bitmap(deleteSvgImage);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                int rowIndex = e.RowIndex;
                int id = Convert.ToInt32(dataGridView1.Rows[rowIndex].Cells["Id"].Value);
                string name = Convert.ToString(dataGridView1.Rows[rowIndex].Cells["NameOfEntry"].Value);
                if (dataGridView1.Columns[e.ColumnIndex].Name == "Enabled")
                {
                    UpdateEnabledDisabled(id, !Convert.ToBoolean(dataGridView1.Rows[rowIndex].Cells["Enabled"].Value));
                }
                else if(dataGridView1.Columns[e.ColumnIndex].Name == "Edit")
                {
                    DialogResult result = MessageBox.Show($"Do you want to edit record with {name} ({id})?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        EditShowEntry(id);
                        dataGridView1.DataSource = ReadExistingFormDataFromJson();
                    }
                    else
                    {
                        return;
                    }
                }
                else if (dataGridView1.Columns[e.ColumnIndex].Name == "Delete")
                {
                    DialogResult result = MessageBox.Show($"Do you want to delete record with {name} ({id})?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        DeleteEntry(id);
                        dataGridView1.DataSource = ReadExistingFormDataFromJson();
                    }
                    else
                    {
                        return;
                    }
                }
            }
        }
        #endregion

        public void MonitoringService()
        {
            List<FormData> existingFormDataList = ReadExistingFormDataFromJson();
            ExecuteRecordsInInterval(existingFormDataList);
        }

        public void ExecuteRecordsInInterval(List<FormData> existingFormDataList)
        {
            foreach (var formData in existingFormDataList)
            {
                if (formData.Enabled)
                {
                    TimerCallback callback;
                    System.Threading.Timer timer = null;


                    if (formData.ComparisonOption == "Match from Initial Capture" || formData.ComparisonOption == "Match from Last Capture")
                    {
                        bool isFirstRun = true;
                        Image originalImage = null;
                        string originalImageStringBase64 = null;
                        callback = state =>
                        {
                            if (isFirstRun == true)
                            {
                                int firstCaptureAnimationTime = (int)Math.Round(Convert.ToDouble(formData.RepeatTime) / 2);
                                firstCaptureAnimationTime = (firstCaptureAnimationTime > 10 ? 10 : firstCaptureAnimationTime) * 1000;
                                originalImage = getImageFromCoordinatesOfFormData(formData, firstCaptureAnimationTime);
                                originalImageStringBase64 = ConvertImageToBase64(originalImage);
                                isFirstRun = false;
                                return;
                            }
                            bool isAlert = false;
                            int noOfValidCaptures = 0;
                            for (int i = 0; i < Convert.ToInt32(formData.CapturePerInterval); i++)
                            {
                                int timeout = Convert.ToInt32(formData.SleepBetweenCaptures) > 200 ? (Convert.ToInt32(formData.SleepBetweenCaptures) / 2 > 2000 ? Convert.ToInt32(formData.SleepBetweenCaptures) - 2000 : Convert.ToInt32(formData.SleepBetweenCaptures) / 2) : 100;
                                Image newImage = getImageFromCoordinatesOfFormData(formData, timeout);
                                string newImageStringBase64 = ConvertImageToBase64(newImage);

                                bool isEqual = string.Equals(originalImageStringBase64, newImageStringBase64, StringComparison.OrdinalIgnoreCase);
                                if ((formData.WaitFor == "Equality" && isEqual) || (formData.WaitFor == "Non Equality" && !isEqual))
                                {
                                    if (formData.MatchCaptures == "Any")
                                    {
                                        isAlert = true;
                                        break;
                                    }
                                    noOfValidCaptures++;
                                }
                                Thread.Sleep(Convert.ToInt32(formData.SleepBetweenCaptures));
                            }
                            if (formData.ComparisonOption == "Match from Last Capture")
                            {
                                originalImage = getImageFromCoordinatesOfFormData(formData);
                            }
                            if (formData.MatchCaptures == "All" && noOfValidCaptures == Convert.ToInt32(formData.CapturePerInterval))
                            {
                                isAlert = true;
                            }
                            if (isAlert)
                            {
                                timer.Dispose();
                                // Alert via ntfy.sh here
                                MessageBox.Show("Time to alert now, condition met in `"+ formData.ComparisonOption + "`:`" + formData.WaitFor + "`," +
                                    "Captures Per Interval: `" + formData.CapturePerInterval + "`, Matching: `" + formData.MatchCaptures + "`", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        };
                        new Thread(() =>
                        {
                            // Thread.Sleep(5000); // Sleep for 5 seconds
                            Thread.Sleep((5 + (int)Math.Round(formData.Id * 1.5)) * 1000);
                            timer = new System.Threading.Timer(callback, null, TimeSpan.Zero, TimeSpan.FromSeconds(Convert.ToInt32(formData.RepeatTime)));
                        }).Start();
                    }
                    else if (formData.ComparisonOption == "OCR compare")
                    {
                        bool isFirstRun = true;
                        callback = async state =>
                        {
                            if (isFirstRun == true)
                            {
                                isFirstRun = false;
                                return;
                            }
                            bool isAlert = false;
                            int noOfValidCaptures = 0;
                            for (int i = 0; i < Convert.ToInt32(formData.CapturePerInterval); i++)
                            {
                                TaskSettings taskSettings = TaskSettings.GetDefaultTaskSettings();
                                OCROptions options = taskSettings.CaptureSettingsReference.OCROptions;

                                int timeout = Convert.ToInt32(formData.SleepBetweenCaptures) > 200 ? (Convert.ToInt32(formData.SleepBetweenCaptures) / 2 > 2000 ? Convert.ToInt32(formData.SleepBetweenCaptures) - 2000 : Convert.ToInt32(formData.SleepBetweenCaptures) / 2) : 100;
                                Image newImage = getImageFromCoordinatesOfFormData(formData, timeout);

                                string capturedText = await OCRHelper.OCR((Bitmap)newImage, options.Language, float.Parse(formData.ScaleFactor), options.SingleLine);
                                Console.WriteLine("====================================================================================================");
                                Console.WriteLine("Captured Text: " + capturedText);
                                Regex regex = new Regex(Regex.Escape(formData.OCRRegex));
                                Match match = regex.Match(capturedText);
                                if (match.Success && match.Groups.Count > Convert.ToInt32(formData.OCRRegexGroup))
                                {
                                    string result = match.Groups[formData.OCRRegexGroup].Value;
                                    Console.WriteLine("Regex Group Text To Compare (result): " + result);
                                    Console.WriteLine("====================================================================================================");
                                    if (
                                    formData.WaitFor == "Numeric.==" && Convert.ToInt32(result) == Convert.ToInt32(formData.ComparisonValue) ||
                                    formData.WaitFor == "Numeric.!=" && Convert.ToInt32(result) != Convert.ToInt32(formData.ComparisonValue) ||
                                    formData.WaitFor == "Numeric.>" && Convert.ToInt32(result) > Convert.ToInt32(formData.ComparisonValue) ||
                                    formData.WaitFor == "Numeric.>=" && Convert.ToInt32(result) >= Convert.ToInt32(formData.ComparisonValue) ||
                                    formData.WaitFor == "Numeric.<" && Convert.ToInt32(result) < Convert.ToInt32(formData.ComparisonValue) ||
                                    formData.WaitFor == "Numeric.<=" && Convert.ToInt32(result) <= Convert.ToInt32(formData.ComparisonValue) ||
                                    formData.WaitFor == "String.Equality" && result == formData.ComparisonValue ||
                                    formData.WaitFor == "String.Non Equality" && result != formData.ComparisonValue
                                    )
                                    {
                                        if (formData.MatchCaptures == "Any")
                                        {
                                            isAlert = true;
                                            break;
                                        }
                                        noOfValidCaptures++;
                                    }
                                }
                                Thread.Sleep(Convert.ToInt32(formData.SleepBetweenCaptures));
                            }
                            if (formData.MatchCaptures == "All" && noOfValidCaptures == Convert.ToInt32(formData.CapturePerInterval))
                            {
                                isAlert = true;
                            }
                            if (isAlert)
                            {
                                timer.Dispose();
                                // Alert via ntfy.sh here
                                MessageBox.Show("Time to alert now, condition met in `OCR compare`:`" + formData.WaitFor + "`," +
                                    "Captures Per Interval: `" + formData.CapturePerInterval + "`, Matching: `" + formData.MatchCaptures + "`", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                timer.Change(TimeSpan.FromSeconds(Convert.ToInt32(formData.RepeatTime)), Timeout.InfiniteTimeSpan);
                            }
                        };
                        new Thread(() =>
                        {
                            Thread.Sleep((5 + (int)Math.Round(formData.Id * 1.5)) * 1000);
                            timer = new System.Threading.Timer(callback, null, TimeSpan.Zero, Timeout.InfiniteTimeSpan);
                        }).Start();   
                    }
                    else if (formData.ComparisonOption == "Check pixel color present")
                    {
                        bool isFirstRun = true;
                        callback = state =>
                        {
                            if (isFirstRun == true)
                            {
                                isFirstRun = false;
                                return;
                            }
                            bool isAlert = false;
                            int noOfValidCaptures = 0;
                            for (int i = 0; i < Convert.ToInt32(formData.CapturePerInterval); i++)
                            {
                                string[] colors = entryComparisonValue.Text.Split(',');
                                int timeout = Convert.ToInt32(formData.SleepBetweenCaptures) > 200 ? (Convert.ToInt32(formData.SleepBetweenCaptures) / 2 > 2000 ? Convert.ToInt32(formData.SleepBetweenCaptures) - 2000 : Convert.ToInt32(formData.SleepBetweenCaptures) / 2) : 100;
                                Image newImage = getImageFromCoordinatesOfFormData(formData, timeout);

                                Bitmap bitmap = new Bitmap(newImage);
                                Color referenceColor = bitmap.GetPixel(0, 0);
                                bool? areColorsFound = null;
                                areColorsFound = formData.WaitFor == "Present" ? false : areColorsFound;
                                areColorsFound = formData.WaitFor == "Not Present" ? true : areColorsFound;
                                for (int y = 0; y < bitmap.Height; y++)
                                {
                                    for (int x = 0; x < bitmap.Width; x++)
                                    {
                                        string pixelColor = bitmap.GetPixel(x, y).ToString();
                                        if (Array.IndexOf(colors, pixelColor) != -1)
                                        {
                                            if (formData.WaitFor == "Present" && formData.ColorMatches == "Any")
                                            {
                                                areColorsFound = true;
                                                goto endOfOuterLoop;
                                            }
                                            if (formData.WaitFor == "Present" && formData.ColorMatches == "All")
                                            {
                                                List<string> colorsList = colors.ToList();
                                                colorsList.Remove(pixelColor);
                                                colors = colorsList.ToArray();
                                                if (colors.Length == 0)
                                                {
                                                    areColorsFound = true;
                                                    goto endOfOuterLoop;
                                                }
                                            }
                                        }
                                        else
                                        {
                                            if (formData.WaitFor == "Not Present" && formData.ColorMatches == "Any")
                                            {
                                                areColorsFound = false;
                                                goto endOfOuterLoop;
                                            }
                                            if (formData.WaitFor == "Not Present" && formData.ColorMatches == "All")
                                            {
                                                List<string> colorsList = colors.ToList();
                                                colorsList.Remove(pixelColor);
                                                colors = colorsList.ToArray();
                                                if (colors.Length == 0)
                                                {
                                                    areColorsFound = false;
                                                    goto endOfOuterLoop;
                                                }
                                            }
                                        }
                                    }
                                }
                                endOfOuterLoop:
                                if ((formData.WaitFor == "Present" && (areColorsFound ?? false)) || (formData.WaitFor == "Not Present" && !(areColorsFound ?? true)))
                                {
                                    if (formData.MatchCaptures == "Any")
                                    {
                                        isAlert = true;
                                        break;
                                    }
                                    noOfValidCaptures++;
                                }
                                Thread.Sleep(Convert.ToInt32(formData.SleepBetweenCaptures));
                            }
                            if (formData.MatchCaptures == "All" && noOfValidCaptures == Convert.ToInt32(formData.CapturePerInterval))
                            {
                                isAlert = true;
                            }
                            if (isAlert)
                            {
                                timer.Dispose();
                                // Alert via ntfy.sh here
                                MessageBox.Show("Time to alert now, condition met in `Check pixel color present`:`" + formData.WaitFor + "`," +
                                    "Captures Per Interval: `" + formData.CapturePerInterval + "`, Matching: `" + formData.MatchCaptures + "`", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        };
                        new Thread(() =>
                        {
                            Thread.Sleep((5 + (int)Math.Round(formData.Id * 1.5)) * 1000);
                            timer = new System.Threading.Timer(callback, null, TimeSpan.Zero, TimeSpan.FromSeconds(Convert.ToInt32(formData.RepeatTime)));
                        }).Start();
                    }
                    else if (formData.ComparisonOption == "Check same color background")
                    {
                        bool isFirstRun = true;
                        callback = state =>
                        {
                            if (isFirstRun == true)
                            {
                                isFirstRun = false;
                                return;
                            }
                            bool isAlert = false;
                            int noOfValidCaptures = 0;
                            for (int i = 0; i < Convert.ToInt32(formData.CapturePerInterval); i++)
                            {
                                int timeout = Convert.ToInt32(formData.SleepBetweenCaptures) > 200 ? (Convert.ToInt32(formData.SleepBetweenCaptures) / 2 > 2000 ? Convert.ToInt32(formData.SleepBetweenCaptures) - 2000 : Convert.ToInt32(formData.SleepBetweenCaptures) / 2) : 100;
                                Image newImage = getImageFromCoordinatesOfFormData(formData, timeout);

                                Bitmap bitmap = new Bitmap(newImage);
                                Color referenceColor = bitmap.GetPixel(0, 0);
                                bool isSameColorBackground = true;
                                for (int y = 0; y < bitmap.Height; y++)
                                {
                                    for (int x = 0; x < bitmap.Width; x++)
                                    {
                                        Color pixelColor = bitmap.GetPixel(x, y);
                                        if (pixelColor != referenceColor)
                                        {
                                            isSameColorBackground = false;
                                        }
                                    }
                                }
                                if ((formData.WaitFor == "Present" && isSameColorBackground) || (formData.WaitFor == "Not Present" && !isSameColorBackground))
                                {
                                    if (formData.MatchCaptures == "Any")
                                    {
                                        isAlert = true;
                                        break;
                                    }
                                    noOfValidCaptures++;
                                }
                                Thread.Sleep(Convert.ToInt32(formData.SleepBetweenCaptures));
                            }
                            if (formData.MatchCaptures == "All" && noOfValidCaptures == Convert.ToInt32(formData.CapturePerInterval))
                            {
                                isAlert = true;
                            }
                            if (isAlert)
                            {
                                timer.Dispose();
                                // Alert via ntfy.sh here
                                MessageBox.Show("Time to alert now, condition met in `Check same color background`:`" + formData.WaitFor + "`," +
                                    "Captures Per Interval: `" + formData.CapturePerInterval + "`, Matching: `" + formData.MatchCaptures + "`", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        };
                        new Thread(() =>
                        {
                            Thread.Sleep((5 + (int)Math.Round(formData.Id * 1.5)) * 1000);
                            timer = new System.Threading.Timer(callback, null, TimeSpan.Zero, TimeSpan.FromSeconds(Convert.ToInt32(formData.RepeatTime)));
                        }).Start();
                    }
                }
            }
        }

        public Image getImageFromCoordinatesOfFormData(FormData formData, int timeout = 1500)
        {
            SettingManager.LoadInitialSettings();
            TaskSettings taskSettings = TaskSettings.GetDefaultTaskSettings();
            Rectangle rect = new Rectangle(Convert.ToInt32(formData.X), Convert.ToInt32(formData.Y), Convert.ToInt32(formData.Width), Convert.ToInt32(formData.Height));
            Task.Run(() =>
            {
                // Create and show the capture section drawing form
                using (CaptureSectionDrawingForm form = new CaptureSectionDrawingForm(rect, timeout))
                {
                    form.ShowDialog();
                }
            });
            return TaskHelpers.GetScreenshot(taskSettings).CaptureRectangle(rect);
        }

        static string ConvertImageToBase64(Image image)
        {
            using (MemoryStream memoryStream = new MemoryStream())
            {
                image.Save(memoryStream, System.Drawing.Imaging.ImageFormat.Png);
                byte[] imageBytes = memoryStream.ToArray();
                string base64String = Convert.ToBase64String(imageBytes);
                return base64String;
            }
        }
    }

    public class FormData
    {
        public bool Enabled { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public string X { get; set; }
        public string Y { get; set; }
        public string Width { get; set; }
        public string Height { get; set; }
        public string RepeatTime { get; set; }
        public string ComparisonOption { get; set; }
        public string WaitFor { get; set; }
        public string ComparisonValue { get; set; }
        public string OCRRegex { get; set; }
        public string OCRRegexGroup { get; set; }
        public string ScaleFactor { get; set; }
        public string ColorMatches { get; set; }
        public string SleepBetweenCaptures { get; set; }
        public string CapturePerInterval { get; set; }
        public string MatchCaptures { get; set; }
        public string PostRequestUrl { get; set; }
        public string PostMessage { get; set; }
    }
    static class Program
    {
        static string activityBase64ContentBlack = "iVBORw0KGgoAAAANSUhEUgAAABgAAAAYCAYAAADgdz34AAAACXBIWXMAAAsTAAALEwEAmpwYAAABOklEQVR4nN2UP0vEQBDFf4fFFVYWWkpE1O5SKgfH9SIIihfzabS1Ow4r/QQWln4AS0HQTgQLW1sLG/EPC29gWDZgwgrig2Eym2FeZuZt4D+jBCby2TEHHAK1fD83wYKK17IiN0EREQxzEwwign2gl5NgFBHUwFIibwa8yrfCToKgjHKWgQ/gC/gEVrsoqHa2HeUdq7jZSRcF7eouWDzv8u4jgqcuChoBYxevJcbjbautggYqavG4YTxm520VVGgsFk+0oztX9MY9v6TkHNRRJZZaax9owXa26cYT/IakGnfzbh0dNBSv9LX2EXZ+6oqERQdcNozszWYed1Dp3LDo3l24AmEXAevAc6KDM36IHrAngit3uVbIiKEIrkUQFp0VhQhuRXCUm6CvX8iD1BMuW3aUwCMw/Y3ifxPfr1xna6wnLu4AAAAASUVORK5CYII=";
        static NotifyIcon notifyIcon;
        static MainForm mainform;

        #region Tray Icon Event Handlers
        static void NotifyIcon_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (mainform.WindowState == FormWindowState.Minimized)
                {
                    mainform.WindowState = FormWindowState.Normal;
                }
                mainform.Activate();
            }
        }

        static void ExitMenuItem_Click(object sender, EventArgs e)
        {
            // Perform any cleanup or save operations here before exiting
            notifyIcon.Visible = false;  // Hide the NotifyIcon
            Application.Exit();  // Exit the application
        }
        #endregion

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            byte[] iconBytesBlack = Convert.FromBase64String(activityBase64ContentBlack);
            Icon trayIcon;
            using (MemoryStream memoryStream = new MemoryStream(iconBytesBlack))
            {
                Image image = Image.FromStream(memoryStream);
                trayIcon = Icon.FromHandle(((Bitmap)image).GetHicon());
            }

            notifyIcon = new NotifyIcon();
            notifyIcon.Icon = trayIcon;
            notifyIcon.Text = "Desktop Activity Checker";

            ContextMenuStrip contextMenu = new ContextMenuStrip();
            ToolStripMenuItem exitMenuItem = new ToolStripMenuItem();
            exitMenuItem.Text = "Exit";
            exitMenuItem.Click += ExitMenuItem_Click;
            contextMenu.Items.Add(exitMenuItem);
            notifyIcon.ContextMenuStrip = contextMenu;

            notifyIcon.Visible = true;
            notifyIcon.MouseClick += NotifyIcon_MouseClick;

            mainform = new MainForm();
            Application.Run(mainform);

            Application.ApplicationExit += Application_ApplicationExit;
        }

        private static void Application_ApplicationExit(object sender, EventArgs e)
        {
            // Dispose the NotifyIcon component
            notifyIcon.Dispose();
        }
    }
}
