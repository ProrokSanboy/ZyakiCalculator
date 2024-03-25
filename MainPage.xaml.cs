using ZyakiCalculator.Core.Entity;

namespace ZyakiCalculator
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void OnCalculateClick(object sender, EventArgs e)
        {
            int value = Int32.Parse(NumberEntry.Text);
            ZyakiConvertor convertor = new(value);

            convertor.Process();

            string result = convertor.Result();

            ResultLabel.Text = result;
            ResultLabel.IsVisible = true;
        }

        private void OnNumberEntryChanged(object sender, EventArgs e)
        {
            ResultLabel.Text = String.Empty;
            ResultLabel.IsVisible = false;
        }
    }

}
