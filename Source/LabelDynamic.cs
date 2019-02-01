﻿using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended;
using SpriteFontPlus;

namespace Apos.Gui {
    public class LabelDynamic : Label {
        //constructors
        public LabelDynamic() : this(() => "Text Missing") { }
        public LabelDynamic(Func<string> iText) {
            _text = iText;
            Width = PrefWidth;
            Height = PrefHeight;
        }

        //public vars
        public override int PrefWidth => (int) _textSize.Width;
        public override int PrefHeight => (int) _textSize.Height;

        //public functions
        public override void Draw(SpriteBatch s) {
            SetScissor(s);
            GuiHelper.DrawString(s, _text(), new Vector2(Left, Top), getColor());
            ResetScissor(s);
        }

        //private vars
        new Func<string> _text = () => "Text Missing";
        new Size2 _textSize => GuiHelper.MeasureString(_text());
    }
}