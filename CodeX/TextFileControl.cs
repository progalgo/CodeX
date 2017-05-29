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

        public List<string> Lines { get; set; }

        public double FontSize { get; set; }

        public TextFileControl()
        {
            visualLines = new VisualCollection(this);
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
            if(index < 0 || index >= visualLines.Count)
            {
                throw new ArgumentOutOfRangeException("index");
            }

            return visualLines[index];
        }

        #endregion

        protected override Size MeasureOverride(Size availableSize)
        {
            return base.MeasureOverride(availableSize);
        }

        protected override Size ArrangeOverride(Size finalSize)
        {
            return base.ArrangeOverride(finalSize);
        }
    }
}
