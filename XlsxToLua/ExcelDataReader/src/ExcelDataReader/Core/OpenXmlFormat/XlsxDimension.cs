using System;

namespace ExcelDataReader.Core.OpenXmlFormat
{
    internal class XlsxDimension
    {
        public XlsxDimension(string value)
        {
            ParseDimensions(value);
        }

        public XlsxDimension(int rows, int cols)
        {
            FirstRow = 1;
            LastRow = rows;
            FirstCol = 1;
            LastCol = cols;

            IsRange = true;
        }

        public int FirstRow { get; set; }

        public int LastRow { get; set; }

        public int FirstCol { get; set; }

        public int LastCol { get; set; }

        public bool IsRange { get; set; }

        private void ParseDimensions(string value)
        {
            string[] parts = value.Split(':');

			int col;
			int row;
            ReferenceHelper.ParseReference(parts[0], out col, out row);
            FirstCol = col;
            FirstRow = row;

            if (parts.Length == 1)
            {
                LastCol = FirstCol;
                LastRow = FirstRow;
            }
            else
            {
                ReferenceHelper.ParseReference(parts[1], out col, out row);
                LastCol = col;
                LastRow = row;

                IsRange = true;
            }
        }
    }
}
