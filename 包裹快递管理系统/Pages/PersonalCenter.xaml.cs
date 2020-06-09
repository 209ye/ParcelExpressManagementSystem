using System.Windows;
using System.Windows.Controls;


namespace 包裹快递管理系统
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class PersonalCenter : UserControl
    {
        public PersonalCenter()
        {
            InitializeComponent();
        }

        private void ChangeGold(object sender, RoutedEventArgs e)
        {
            if (ButtonLeft.Opacity == 0.95)
            {
                HeadLeft.Opacity = 0.3;
                ButtonLeft.Opacity = 0.3;
                BorderLeft.Opacity = 0.8;
                BorderLeftBack.Background.Opacity = 0.9;
            }
            else
            {
                HeadLeft.Opacity = 1;
                ButtonLeft.Opacity = 0.95;
                BorderLeft.Opacity = 1;
                BorderLeftBack.Background.Opacity = 0.2;
            }
            
        }

        private void ChangeBlueGreen(object sender, RoutedEventArgs e)
        {
            if (ButtonRight.Opacity == 0.95)
            {
                HeadRight.Opacity = 0.3;
                ButtonRight.Opacity = 0.3;
                BorderRight.Opacity = 0.8;
                BorderRightBack.Background.Opacity = 0.9;
            }
            else
            {
                HeadRight.Opacity = 1;
                ButtonRight.Opacity = 0.95;
                BorderRight.Opacity = 1;
                BorderRightBack.Background.Opacity = 0.2;
            }

        }
    }
}
