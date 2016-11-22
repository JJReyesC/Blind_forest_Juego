using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;

namespace Sprites_Tiles
{
    public class Player:Personaje
    {
        public int velplay = 2;
        SoundEffect salto;
        SpriteEffects espejo;
        KeyboardState kbs;
       
        

        Rectangle corte,corte2;
        public const int anchoplay = 41;
        public const int altoplay = 63;

        int indice;
        public float tjuego;
        public float tsprite;

        
       
        public Player(string nomtextura, string nomSonido,int limxesc, int limyesc, int ancho, int alto, int posx, int posy, ContentManager contenido) :
            base(nomtextura, nomSonido, limxesc, limyesc, ancho, alto, posx, posy, contenido)
        {
        }

        public override void Mueve(Microsoft.Xna.Framework.GameTime gameTime)
        {
            kbs = Keyboard.GetState();
            salto = contenido.Load<SoundEffect>(this.nomSonido);

            tsprite = .2f;
            if (visible)
            {
               tjuego += (float)gameTime.ElapsedGameTime.TotalSeconds;
                          

                
                
                if (kbs.IsKeyDown(Keys.Left))
                {
                    espejo = SpriteEffects.FlipHorizontally;
                    this.posx -= velplay;
                    if (this.posx <= 0)
                    {
                        this.posx += velplay;

                    }

                    if (tjuego > tsprite)
                    {
                        indice++;
                        tjuego = 0f;

                      
                    }
                    if (indice > 4)
                        indice = 0;
                }
               

                if (kbs.IsKeyDown(Keys.Right))
                {
                    espejo = SpriteEffects.None;
                    this.posx += velplay;
                    if (this.posx >= Limxesc - Ancho)
                    {
                        this.posx -= velplay;
                    }

                    if (tjuego > tsprite)
                    {
                        
                        indice++;
                        tjuego = 0f;

                    

                    }
                    if (indice > 4)
                        indice = 0;
                }
                
                if (kbs.IsKeyDown(Keys.Space))
                {
                    salta=true;
                }
                
                if (salta)
                {             
                     this.posy -=5;
                     salta = false;
                }
                else
                {
                    this.posy += 5;
                }
               
                if (kbs.IsKeyDown(Keys.Up))
                {                

                        this.posy -= 8;
                        indice=5;
                        tjuego = 0;
                  

                }


                if (kbs.IsKeyDown(Keys.LeftControl))
                {
                    if (kbs.IsKeyDown(Keys.Right))
                    {
                        espejo = SpriteEffects.None;
                        this.posx += velplay+1;
                        tsprite = .15f;
                        if (this.posx >= Limxesc - Ancho)
                        {
                            this.posx -= velplay+1;
                        }
                        if (tjuego > tsprite)
                        {                            
                            indice++;
                            tjuego = 0f;                         

                        }
                        if (indice > 4)
                            indice = 0;

                    }
                    if (kbs.IsKeyDown(Keys.Left))
                    {
                        espejo = SpriteEffects.FlipHorizontally;
                        this.posx -= velplay * 2;
                        tsprite = .1f;
                        if (this.posx <= 0)
                        {
                            this.posx += velplay * 2;

                        }
                        if (tjuego > tsprite)
                        {
                           
                            indice++;
                            tjuego = 0f;

                            
                        }
                        if (indice > 4)
                            indice = 0;
                    }

                    
                }
                
                if(kbs.IsKeyDown(Keys.Z))
                    {
                        indice = 6;
                    }
            }
        }
        public override void  Dibuja(SpriteBatch spriteBatch, GameTime gameTime)
         {           
                corte = new Rectangle(anchoplay*indice, 0, anchoplay, altoplay);
                corte2 = new Rectangle(anchoplay *indice+9, 0, anchoplay+30, altoplay);

                if(indice<6)
                spriteBatch.Draw(txt, new Vector2(posx, posy), corte, Color.White, 0f, Vector2.Zero, 1f, espejo, 0f);
                else
                    spriteBatch.Draw(txt, new Vector2(posx, posy), corte2, Color.LightGray, 0f, Vector2.Zero, 1f, espejo, 0f);

            
        }
        public override void Dibujatuto(SpriteBatch spriteBatch, GameTime gameTime)
        {
            corte = new Rectangle(anchoplay * indice, 0, anchoplay, altoplay);
            corte2 = new Rectangle(anchoplay * indice + 9, 0, anchoplay + 30, altoplay);

            if (indice < 6)
                spriteBatch.Draw(txt, new Vector2(posx, posy), corte, Color.White, 0f, Vector2.Zero, 1.7f, espejo, 0f);
            else
                spriteBatch.Draw(txt, new Vector2(posx, posy), corte2, Color.LightGray, 0f, Vector2.Zero, 1.7f, espejo, 0f);


        }

      
        public override void Colision_arriba()
        {
            posy -= 5;
          
        }
        public override void Colision_abajo()
        {
            posy += 5;
        }
        public override void Colision_izq()
        {
            
            posx -=velplay;
            kbs = Keyboard.GetState();
            if (kbs.IsKeyDown(Keys.Right))
            {

                if (kbs.IsKeyDown(Keys.LeftControl))
                {
                    this.posx -= velplay * 2;
                }
            }

            
        }
        public override void Colision_der()
        {
            posx += velplay;
            kbs = Keyboard.GetState();
            if (kbs.IsKeyDown(Keys.Left))
            {

                if (kbs.IsKeyDown(Keys.LeftControl))
                {
                    this.posx += velplay * 2;
                }
            }
        }
    }

}
