using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace Sprites_Tiles
{
	public class Mosaico
	{

        private int tmosaico;
        public int Tmosaico{
          get {
              return tmosaico;
    }
            set{tmosaico=value;
    }
        }
		private Texture2D textura;
		public Texture2D Textura {
			get {
				return textura;
			}
			set {
				textura = value;    
			}
		}

		private Rectangle rectangulo;
		public Rectangle Rectangulo {
			get {
				return rectangulo;
			}
			set {
				rectangulo = value;
			}
		}

		private ContentManager adminContenido;
		public ContentManager AdminContenido {
			get {
				return adminContenido;
			}
			set {
				adminContenido = value;
			}
		}

        private bool visible;

        public bool Visible
        {
            get { return visible; }
            set { visible = value; }
        }

		public Mosaico (string nomMosaico, Rectangle rectangulo, ContentManager adminContenido, int tmosaico)
		{
			this.adminContenido = adminContenido;
			this.textura = this.adminContenido.Load<Texture2D> (nomMosaico);
			this.rectangulo = rectangulo;
            this.tmosaico = tmosaico;
            this.visible = true;
           
		}

		public void Draw (SpriteBatch spriteBatch)
		{
            if (visible)
			spriteBatch.Draw (textura, rectangulo, Color.White);
		}
	}
}

