using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CodeX
{
    class TextFileControl : FrameworkElement
    {
        static TextFileControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(TextFileControl), new FrameworkPropertyMetadata(typeof(TextFileControl)));
        }

        VisualCollection visualLines;

        List<string> lines = new List<string>();

        public TextFileControl()
        {
            visualLines = new VisualCollection(this);
        }

        public List<string> Lines
        {
            get
            {
                return new List<string>(lines);
            }
            set
            {
                lines = new List<string>(value);
                InitializeContent();
                InvalidateVisual();
            }
        }

        public double FontSize { get; set; }

        void InitializeContent()
        {
            visualLines.Clear();

            foreach (string line in lines)
            {
                Glyphs glyphs = new Glyphs();
                glyphs.UnicodeString = line;
                glyphs.FontRenderingEmSize = FontSize;
                glyphs.FontUri = new Uri(@"C:\WINDOWS\Fonts\CONSOLA.TTF");
                glyphs.Fill = new SolidColorBrush(Colors.Black);
                visualLines.Add(glyphs);
            }
        }

        #region Visual Tree Interface

        protected override int VisualChildrenCount
        {
            get
            {
                return visualLines.Count;
            }
        }

        protected override Visual GetVisualChild(int index)
        {
            if (index < 0 || index >= visualLines.Count)
            {
                throw new ArgumentOutOfRangeException("index");
            }

            return visualLines[index];
        }

        #endregion

        #region Layout System Interface

        protected override Size MeasureOverride(Size availableSize)
        {
            double totalHeight = 0;
            double maxWidth = 0;
            
            foreach (FrameworkElement lineVisual in visualLines)
            {
                lineVisual.Measure(availableSize);
                Size elementSize = lineVisual.DesiredSize;
                totalHeight += elementSize.Height;
                maxWidth = Math.Max(maxWidth, elementSize.Width);
            }

            return new Size(maxWidth, totalHeight);
        }

        protected override Size ArrangeOverride(Size finalSize)
        {
            double yOffset = 0;

            foreach (FrameworkElement lineVisual in visualLines)
            {
                Size elementSize = lineVisual.DesiredSize;
                elementSize.Width = finalSize.Width;
                double height = elementSize.Height;
                Rect elementRect = new Rect(new Point(0, yOffset), elementSize);
                yOffset += height;
                lineVisual.Arrange(elementRect);
            }

            return finalSize;
        }

        #endregion
    }
}
