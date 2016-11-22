using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace Sprites_Tiles
{
    public abstract class Personaje
    {
        protected Rectangle rectangulo;
        public Rectangle Rectangulo
        {
            get{return this.rectangulo;}
            set{rectangulo = value;}
        }
        protected Texture2D txt;

        protected bool visible;
        public bool Visible
        { 
            get { return this.visible; } 
            set { visible = value; } 
        }

        protected string nomTextura;

        public string NomTextura
        {
            get { return nomTextura; }
            set { nomTextura = value; }
        }
        protected string nomSonido;

        public string NomSonido
        {
            get { return nomSonido; }
            set { nomSonido = value; }
        }

        protected ContentManager contenido;
        protected int limxesc;

        public int Limxesc
        {
            get { return limxesc; }
            set { limxesc = value; }
        }
        protected int limyesc;

        public int Limyesc
        {
            get { return this.limyesc; }
            set { limyesc = value; }
        }
        protected int ancho;

        public int Ancho
        {
            get { return ancho; }
            set { ancho = value; }
        }
        protected int alto;

        public int Alto
        {
            get { return alto; }
            set { alto = value; }
        }
        protected int posx;

        public int Posx
        {
            get { return this.posx; }
            set { posx = value; }
        }
        protected int posy;

        public int Posy
        {
            get { return this.posy; }
            set { posy = value; }
        }

        protected bool salta;

        public bool Salta
        {
            get { return salta; }
            set { salta = value; }
        }

  

        

        public Personaje(string nomtextura, string nomSonido,int limxesc,int limyesc,
                         int ancho,int alto,int posx,int posy,ContentManager contenido)
        {
            this.NomTextura = nomtextura;
            this.NomSonido=nomSonido;
            this.Limxesc=limxesc;
            this.Limyesc=limyesc;
            this.contenido=contenido;
            this.Ancho=ancho;
            this.Alto=alto;
            this.Posx=posx;
            this.Posy=posy;
            visible = true;
            txt= contenido.Load<Texture2D>(nomtextura);
            rectangulo = new Rectangle(posx, posy, ancho, alto);

        }

        public abstract void Dibuja(SpriteBatch spriteBatch,GameTime gameTime);
        public abstract void Dibujatuto(SpriteBatch spriteBatch, GameTime gameTime);
        public abstract void Mueve(GameTime gameTime);

        public abstract void Colision_arriba();
        public abstract void Colision_abajo();
        public abstract void Colision_izq();
        public abstract void Colision_der();
        

        
       
    }
}
