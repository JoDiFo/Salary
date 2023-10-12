using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Salary
{
    public class ThemeColor
    {
        private Color _selectedColor;

        private int _tempIndex;
        private readonly List<string> _colorList = new List<string>()
        {
            "#3F51B5",
            "#009688",
            "#FF5722",
            "#607D8B",
            "#FF9800",
            "#9C27B0",
            "#2196F3",
            "#EA676C",
            "#E41A4A",
            "#5978BB",
            "#018790",
            "#0E3441",
        };

        public Color GetPrimaryColor()
        {
            return _selectedColor;
        }

        public Color GetSecondaryColor()
        {
            return ChangeColorBrightness(_selectedColor, -0.2);
        }

        public Color GetLighterColor()
        {
            return ChangeColorBrightness(_selectedColor, 0.2);
        }

        public void SelectRandomColor()
        {
            Random random = new Random();
            int index = random.Next(_colorList.Count);
            while (_tempIndex == index)
            {
                index = random.Next(_colorList.Count);
            }
            _tempIndex = index;

            string color = _colorList[index];
            _selectedColor = ColorTranslator.FromHtml(color);
        }
        private Color ChangeColorBrightness(Color color, double factor)
        {
            double red = color.R;
            double green = color.G;
            double blue = color.B;

            if (factor < 0)
            {
                factor += 1;
                red *= factor;
                green *= factor;
                blue *= factor;
            }
            else
            {
                red = (255 - red) * factor + red;
                green = (255 - green) * factor + green;
                blue = (255 - blue) * factor + blue;
            }

            return Color.FromArgb((byte)red, (byte)green, (byte)blue);
        }
    }
}
