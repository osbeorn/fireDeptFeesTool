using System;

namespace FireDeptFeesTool.Common.Lib
{
    public class UPNRectangle
    {
        public UPNRectangle(float x1, float y1, float x2, float y2, float formHeight, float yMargin, float xOffset,
                            float yOffset)
        {
            _x1 = x1;
            _y1 = y1;
            _x2 = x2;
            _y2 = y2;
            _yMargin = yMargin;
            _formHeight = formHeight;
            _xOffset = xOffset;
            _yOffset = yOffset;
        }

        public UPNRectangle(float x1, float y1, float x2, float y2, float formHeight, float xMargin, float yMargin,
                            float xOffset, float yOffset)
        {
            _x1 = x1;
            _y1 = y1;
            _x2 = x2;
            _y2 = y2;
            _xMargin = xMargin;
            _yMargin = yMargin;
            _formHeight = formHeight;
            _xOffset = xOffset;
            _yOffset = yOffset;
        }

        public float X
        {
            get { return _xMargin + _x1 + _xOffset; }
        }

        public float Y
        {
            get
            {
                // tukej je treba prišet še 0.4f da bo bolj na sredino poravnano
                return _formHeight - _y1 + _yMargin + _yOffset;
            }
        }

        public float Width
        {
            get { return Math.Abs(_x2 - _x1); }
        }

        public float Height
        {
            get { return Math.Abs(_y2 - _y1); }
        }

        private float _x1 { get; set; }
        private float _y1 { get; set; }
        private float _x2 { get; set; }
        private float _y2 { get; set; }
        private float _yMargin { get; set; }
        private float _formHeight { get; set; }
        private float _xMargin { get; set; }
        private float _xOffset { get; set; }
        private float _yOffset { get; set; }
    }
}