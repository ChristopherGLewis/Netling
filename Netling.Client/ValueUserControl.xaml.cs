using System.Windows;
using System.Windows.Media;

namespace Netling.Client
{
    public partial class ValueUserControl
    {
        bool _ADA = false;

        public ValueUserControl()
        {
            InitializeComponent();
        }

        public string Title
        {
            get { return TitleTextBlock.Text; }
            set { TitleTextBlock.Text = value?.ToUpper(); }
        }

        public string Value
        {
            get { return ValueTextBlock.Text; }
            set { ValueTextBlock.Text = value; }
        }

        public string Unit
        {
            get { return UnitTextBlock.Text; }
            set { UnitTextBlock.Text = value?.ToLower(); }
        }

        public string BaselineValue
        {
            get { return BaselineValueTextBlock.Text; }
            set
            {
                BaselineValueTextBlock.Text = value;
                BaselineValueTextBlock.Visibility = !string.IsNullOrWhiteSpace(value) ? Visibility.Visible : Visibility.Collapsed;
            }
        }

        public bool UseADA
        {
            get { return _ADA ; }
            set {
                _ADA = value;
                SetBackgroundForADA(_ADA);
            }
        }

        public Brush ValueBrush
        {
            get { return ValueTextBlock.Foreground; }
            set
            {
                if (value != null)
                {
                    ValueTextBlock.Foreground = value;
                    UnitTextBlock.Foreground = value;
                    ValueBorder.BorderBrush = value;

                    if (value.ToString().Equals(Brushes.Green.ToString()) ) {
                        ValueBorder.Background = this.FindResource("GreenHash") as VisualBrush;
                    } 
                    else 
                    {
                        ValueBorder.Background = this.FindResource("RedHash") as VisualBrush;
                    }
                    SetBackgroundForADA(_ADA);
                } 
                else
                {
                    ValueTextBlock.Foreground = new SolidColorBrush(Colors.Black);
                    UnitTextBlock.Foreground = new SolidColorBrush(Colors.Black);
                    ValueBorder.BorderBrush = new SolidColorBrush(Colors.DarkGray);
                    ValueBorder.Background = null; 
                }
            }
        }
        private void SetBackgroundForADA(bool ada)
        {
            if (_ADA) {
                if ((this.ValueBorder.Background as VisualBrush) != null) {
                    (this.ValueBorder.Background as VisualBrush).Opacity = 0.5;
                }
            } else {
                if ((this.ValueBorder.Background as VisualBrush) != null) {
                    (this.ValueBorder.Background as VisualBrush).Opacity = 0;
                }
            }
        }
    }
}
