using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;


namespace Sprites_Tiles
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Principal : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Rectangle esc;
        Rectangle pres;
        Rectangle tuto_0,tuto_1,tuto_2;
        Texture2D bg;
        Texture2D bg_pres;
        Texture2D ctrl_0,ctrl_1,ctrl_2;
        Player player;

        enum Fases{ 
            presentacion,
            tuto,
            nivel1,
            nivel2,
            nivel3,
            game_over,
            terminado
        }

        Fases actual = Fases.presentacion;

        const int anchoesc = 1024;
        const int altoesc = 720;
        const int anchotile =32;
        const int altotile = 32;
        

        int meta,score;
        int vidas=3;
        

        Mapa mapa;

        SpriteFont fuente;

        public Principal()
            : base()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            graphics.CreateDevice();

            graphics.PreferredBackBufferWidth = anchoesc;
            graphics.PreferredBackBufferHeight = altoesc;
            graphics.ApplyChanges();
            graphics.IsFullScreen = false;
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            if (actual == Fases.presentacion)
            {            
                pres = new Rectangle(0, 0, anchoesc, altoesc);
                fuente = Content.Load<SpriteFont>("lk");
            }
            if (actual == Fases.tuto) {
                mapa = new Mapa(anchotile, altotile);
                mapa.AdminContenido = Content;
                pres = new Rectangle(0, 0, anchoesc, altoesc);
                tuto_0 = new Rectangle(200, 200, 70,70);
                tuto_1 = new Rectangle(460, 200, 70, 70);
                tuto_2 = new Rectangle(700,200, 140, 70);
                mapa.Generar("tuto.txt");
                fuente = Content.Load<SpriteFont>("lk");
                player = new Player("personaje", "salto.wav", anchoesc, altoesc, Player.anchoplay, Player.altoplay, 200, 400, Content);
                
            }
            if (actual == Fases.nivel1)
            {
                mapa = new Mapa(anchotile, altotile);
                mapa.AdminContenido = Content;
                esc = new Rectangle(0, 0, anchoesc, altoesc);   
                mapa.Generar("lvl1.txt");
                player = new Player("personaje", "salto.wav", anchoesc, altoesc, Player.anchoplay, Player.altoplay, 32, 609, Content);
                fuente = Content.Load<SpriteFont>("lk");
            }
            if (actual == Fases.nivel2)
            {
                mapa = new Mapa(anchotile, altotile);
                mapa.AdminContenido = Content;
                mapa.Generar("lvl2.txt");
                esc = new Rectangle(0, 0, anchoesc, altoesc);
                player = new Player("personaje", "salto.wav", anchoesc, altoesc, Player.anchoplay, Player.altoplay,0, 640, Content);
                fuente = Content.Load<SpriteFont>("lk");
              
            }
            if (actual == Fases.nivel3)
            {
                mapa = new Mapa(anchotile, altotile);
                mapa.AdminContenido = Content;
                mapa.Generar("lvl3.txt");
                esc = new Rectangle(0, 0, anchoesc, altoesc);
                player = new Player("personaje", "salto.wav", anchoesc, altoesc, Player.anchoplay, Player.altoplay, 32, 640, Content);
                fuente = Content.Load<SpriteFont>("lk");
            }
            base.Initialize();
         


        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            
            bg_pres = Content.Load<Texture2D>("bg_pres");

            
           // mosaico = new Mosaico(32,32);

            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();


            switch (actual)
            { 
                case Fases.presentacion:
                    Update_presentacion(gameTime);
                    break;
                case Fases.tuto:
                    Update_tuto(gameTime);
                    break;
                case Fases.nivel1:
                    Update_nivel1(gameTime);
                    break;
                case Fases.game_over:
                    Update_gameover(gameTime);
                    break;
                case Fases.nivel2:
                    Update_nivel2(gameTime);
                    break;
                case Fases.nivel3:
                    Update_nivel3(gameTime);
                    break;
                case Fases.terminado:
                    Update_terminado(gameTime);
                    break;
            }

                        base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            graphics.GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();
            switch (actual) { 
                case Fases.presentacion:
                    Draw_presentacion(gameTime);
                    break;
                case Fases.tuto:
                    Draw_tuto(gameTime);
                    break;
                case Fases.nivel1:
                    Draw_nivel1(gameTime);
                    break;
                case Fases.nivel2:
                    Draw_nivel2(gameTime);
                    break;
                case Fases.nivel3:
                    Draw_nivel3(gameTime);
                    break;
                case Fases.game_over:
                    Draw_gameover(gameTime);
                    break;
                case Fases.terminado:
                    Draw_terminado(gameTime);
                    break;
               
            }
            spriteBatch.End();
            

            base.Draw(gameTime);
        }

        public void Update_presentacion(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Enter))
            {
                actual = Fases.tuto;
                Initialize();
            }

        }
        public void Update_tuto(GameTime gameTime) {
              Rectangle choca = new Rectangle((int)player.Posx, (int)player.Posy, player.Rectangulo.Width, player.Rectangulo.Height);

            // TODO: Add your update logic here

              foreach (Mosaico m in mapa.mosaicos)
              {
   
                  //mosaicos de colision
                  if (m.Tmosaico == 1)
                  {
                      
                      BoundingBox arriba = new BoundingBox();
                      arriba.Min = new Vector3(m.Rectangulo.X + 5, m.Rectangulo.Y, 0);
                      arriba.Max = new Vector3((m.Rectangulo.X + m.Rectangulo.Width) - 7, m.Rectangulo.Y + 2, 0);
                      BoundingBox abajo = new BoundingBox();
                      abajo.Min = new Vector3(m.Rectangulo.X + 5, (m.Rectangulo.Y + m.Rectangulo.Height) - 2, 0);
                      abajo.Max = new Vector3((m.Rectangulo.X + m.Rectangulo.Width) - 7, m.Rectangulo.Y + m.Rectangulo.Height, 0);
                      BoundingBox izq = new BoundingBox();
                      izq.Min = new Vector3(m.Rectangulo.X, m.Rectangulo.Y + 5, 0);
                      izq.Max = new Vector3(m.Rectangulo.X + 2, m.Rectangulo.Y + m.Rectangulo.Height, 0);
                      BoundingBox der = new BoundingBox();
                      der.Min = new Vector3((m.Rectangulo.X + m.Rectangulo.Width) - 2, m.Rectangulo.Y + 5, 0);
                      der.Max = new Vector3(m.Rectangulo.X + m.Rectangulo.Width, (m.Rectangulo.Y + m.Rectangulo.Height), 0);

                      BoundingBox cplayer = new BoundingBox(new Vector3(player.Posx, player.Posy, 0), new Vector3(player.Posx + player.Rectangulo.Width, player.Posy + player.Rectangulo.Height, 0));
                      if (cplayer.Intersects(arriba))
                      {
                          player.Salta = false;
                          player.Colision_arriba();

                      }
                      else if (cplayer.Intersects(abajo))
                      {
                          player.Salta = false;
                          player.Colision_abajo();

                      }

                      else if (cplayer.Intersects(izq))
                      {
                          player.Salta = false;
                          player.Colision_izq();

                      }
                      else if (cplayer.Intersects(der))
                      {
                          player.Salta = false;
                          player.Colision_der();

                      }
                  }
              }
              player.Mueve(gameTime);

            if (Keyboard.GetState().IsKeyDown(Keys.LeftShift)|| Keyboard.GetState().IsKeyDown(Keys.RightShift)) {

                actual = Fases.nivel1;
                Initialize();
            }
        }
        public void Update_nivel1(GameTime gameTime)
        {
           

            Rectangle choca = new Rectangle((int)player.Posx, (int)player.Posy, player.Rectangulo.Width, player.Rectangulo.Height);

            // TODO: Add your update logic here
           
            foreach (Mosaico m in mapa.mosaicos)
            {

                //mosaicos de colision
                if (m.Tmosaico == 1)
                {
                    BoundingBox arriba = new BoundingBox();
                    arriba.Min = new Vector3(m.Rectangulo.X+5, m.Rectangulo.Y, 0);
                    arriba.Max = new Vector3((m.Rectangulo.X + m.Rectangulo.Width)-7, m.Rectangulo.Y + 2, 0);
                    BoundingBox abajo = new BoundingBox();
                    abajo.Min = new Vector3(m.Rectangulo.X+5, (m.Rectangulo.Y + m.Rectangulo.Height)-2, 0);
                    abajo.Max = new Vector3((m.Rectangulo.X + m.Rectangulo.Width)-7, m.Rectangulo.Y + m.Rectangulo.Height, 0);
                    BoundingBox izq = new BoundingBox();
                    izq.Min = new Vector3(m.Rectangulo.X, m.Rectangulo.Y+5, 0);
                    izq.Max = new Vector3(m.Rectangulo.X + 2,m.Rectangulo.Y+m.Rectangulo.Height, 0);
                    BoundingBox der = new BoundingBox();
                    der.Min = new Vector3((m.Rectangulo.X + m.Rectangulo.Width) - 2, m.Rectangulo.Y+5, 0);
                    der.Max = new Vector3(m.Rectangulo.X + m.Rectangulo.Width, (m.Rectangulo.Y + m.Rectangulo.Height), 0);

                    BoundingBox cplayer = new BoundingBox(new Vector3(player.Posx, player.Posy, 0), new Vector3(player.Posx+ player.Rectangulo.Width, player.Posy + player.Rectangulo.Height, 0));
                    if (cplayer.Intersects(arriba))
                    {
                        player.Salta = false;
                        player.Colision_arriba();

                    }
                    else if (cplayer.Intersects(abajo))
                    {
                        player.Salta = false;
                        player.Colision_abajo();

                    }

                    else if (cplayer.Intersects(izq))
                    {
                        player.Salta = false;
                        player.Colision_izq();

                    }
                    else if (cplayer.Intersects(der))
                    {
                        player.Salta = false;
                        player.Colision_der();

                    }
            }

                //mosaicos de puntaje
                if (m.Tmosaico == 3)
                {
                    if (choca.Intersects(m.Rectangulo))
                    {
                        if (m.Visible)
                        {
                            meta++;
                            m.Visible = false;
                            score = score+100;
                        }
                    }
                    
                }
            }

            player.Mueve(gameTime);


         
                if (score == 400)
                {
                    actual = Fases.nivel2;
                    Initialize();
                }
                                   
             if (player.Posy < -30)
                    {
                        player.Posy += 8;
                    }
            
            if (player.Posy > altoesc)
            {
                vidas--;
                player.Posx=32;
                player.Posy=640-72;
                
                if (vidas == 0)
                {
                    actual = Fases.game_over;
                }
                if (score>=200)
            {
                player.Posx=448;
                player.Posy=35;
            }
            }

            
            
        }

        public void Update_nivel2(GameTime gameTime)
        {
            Rectangle choca = new Rectangle((int)player.Posx, (int)player.Posy, player.Rectangulo.Width, player.Rectangulo.Height);

            // TODO: Add your update logic here

            foreach (Mosaico m in mapa.mosaicos)
            {

                //mosaicos de colision
                if (m.Tmosaico == 1)
                {
                    BoundingBox arriba = new BoundingBox();
                    arriba.Min = new Vector3(m.Rectangulo.X + 5, m.Rectangulo.Y, 0);
                    arriba.Max = new Vector3((m.Rectangulo.X + m.Rectangulo.Width) - 7, m.Rectangulo.Y + 2, 0);
                    BoundingBox abajo = new BoundingBox();
                    abajo.Min = new Vector3(m.Rectangulo.X + 5, (m.Rectangulo.Y + m.Rectangulo.Height) - 2, 0);
                    abajo.Max = new Vector3((m.Rectangulo.X + m.Rectangulo.Width) - 7, m.Rectangulo.Y + m.Rectangulo.Height, 0);
                    BoundingBox izq = new BoundingBox();
                    izq.Min = new Vector3(m.Rectangulo.X, m.Rectangulo.Y + 5, 0);
                    izq.Max = new Vector3(m.Rectangulo.X + 2, m.Rectangulo.Y + m.Rectangulo.Height, 0);
                    BoundingBox der = new BoundingBox();
                    der.Min = new Vector3((m.Rectangulo.X + m.Rectangulo.Width) - 2, m.Rectangulo.Y + 5, 0);
                    der.Max = new Vector3(m.Rectangulo.X + m.Rectangulo.Width, (m.Rectangulo.Y + m.Rectangulo.Height), 0);

                    BoundingBox cplayer = new BoundingBox(new Vector3(player.Posx, player.Posy, 0), new Vector3(player.Posx + player.Rectangulo.Width, player.Posy + player.Rectangulo.Height, 0));
                    if (cplayer.Intersects(arriba))
                    {
                        player.Salta = false;
                        player.Colision_arriba();

                    }
                    else if (cplayer.Intersects(abajo))
                    {
                        player.Salta = false;
                        player.Colision_abajo();

                    }

                    else if (cplayer.Intersects(izq))
                    {
                        player.Salta = false;
                        player.Colision_izq();

                    }
                    else if (cplayer.Intersects(der))
                    {
                        player.Salta = false;
                        player.Colision_der();

                    }
                }

                //mosaicos de puntaje
                if (m.Tmosaico == 3)
                {
                    if (choca.Intersects(m.Rectangulo))
                    {
                        if (m.Visible)
                        {
                            meta++;
                            m.Visible = false;
                            score = score + 100;
                        }
                    }

                }
            }

            player.Mueve(gameTime);


            if (score == 800)
            {
                actual = Fases.nivel3;
                Initialize();
            }

            if (player.Posy < -30)
            {
                player.Posy += 8;
            }

            if (player.Posy > altoesc)
            {
                vidas--;
                player.Posx = 32;
                player.Posy = 640 - 72;

                if (vidas == 0)
                {
                    actual = Fases.game_over;
                }
                if (score >= 600)
                {
                    player.Posx = 448;
                    player.Posy = 35;
                }
            }

           
        }
        public void Update_nivel3(GameTime gameTime)
        {
            Rectangle choca = new Rectangle((int)player.Posx, (int)player.Posy, player.Rectangulo.Width, player.Rectangulo.Height);

            // TODO: Add your update logic here

            foreach (Mosaico m in mapa.mosaicos)
            {

                //mosaicos de colision
                if (m.Tmosaico == 1)
                {
                    BoundingBox arriba = new BoundingBox();
                    arriba.Min = new Vector3(m.Rectangulo.X + 5, m.Rectangulo.Y, 0);
                    arriba.Max = new Vector3((m.Rectangulo.X + m.Rectangulo.Width) - 7, m.Rectangulo.Y + 2, 0);
                    BoundingBox abajo = new BoundingBox();
                    abajo.Min = new Vector3(m.Rectangulo.X + 5, (m.Rectangulo.Y + m.Rectangulo.Height) - 2, 0);
                    abajo.Max = new Vector3((m.Rectangulo.X + m.Rectangulo.Width) - 7, m.Rectangulo.Y + m.Rectangulo.Height, 0);
                    BoundingBox izq = new BoundingBox();
                    izq.Min = new Vector3(m.Rectangulo.X, m.Rectangulo.Y + 5, 0);
                    izq.Max = new Vector3(m.Rectangulo.X + 2, m.Rectangulo.Y + m.Rectangulo.Height, 0);
                    BoundingBox der = new BoundingBox();
                    der.Min = new Vector3((m.Rectangulo.X + m.Rectangulo.Width) - 2, m.Rectangulo.Y + 5, 0);
                    der.Max = new Vector3(m.Rectangulo.X + m.Rectangulo.Width, (m.Rectangulo.Y + m.Rectangulo.Height), 0);

                    BoundingBox cplayer = new BoundingBox(new Vector3(player.Posx, player.Posy, 0), new Vector3(player.Posx + player.Rectangulo.Width, player.Posy + player.Rectangulo.Height, 0));
                    if (cplayer.Intersects(arriba))
                    {
                        player.Salta = false;
                        player.Colision_arriba();

                    }
                    else if (cplayer.Intersects(abajo))
                    {
                        player.Salta = false;
                        player.Colision_abajo();

                    }

                    else if (cplayer.Intersects(izq))
                    {
                        player.Salta = false;
                        player.Colision_izq();

                    }
                    else if (cplayer.Intersects(der))
                    {
                        player.Salta = false;
                        player.Colision_der();

                    }
                }

                //mosaicos de puntaje
                if (m.Tmosaico == 3)
                {
                    if (choca.Intersects(m.Rectangulo))
                    {
                        if (m.Visible)
                        {
                            meta++;
                            m.Visible = false;
                            score = score + 100;
                        }
                    }

                }
            }
          
                player.Mueve(gameTime);

                if (score == 1200)
                {
                    actual = Fases.terminado;
                    Initialize();
                }

            if (player.Posy < -70)
            {
                actual = Fases.nivel3;
                Initialize();
            }

            if (player.Posy > altoesc)
            {
                vidas--;
                player.Posx = 32;
                player.Posy = 640 - 72;

                if (vidas == 0)
                {
                    actual = Fases.game_over;
                }
            }
            
        }
        public void Update_gameover(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            else if (Keyboard.GetState().IsKeyDown(Keys.R))
            {
                score = 0;
                meta = 0;
                vidas = 3;
                actual = Fases.presentacion;
                Initialize();
            }
        }
        public void Update_terminado(GameTime gameTime) {
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            else if (Keyboard.GetState().IsKeyDown(Keys.R))
            {
                score = 0;
                meta = 0;
                vidas = 3;
                actual = Fases.presentacion;
                Initialize();
            }
        
        }

        public void Draw_presentacion(GameTime gameTime)
        {
            spriteBatch.Draw(bg_pres, pres, Color.White);
            spriteBatch.DrawString(fuente, "The Blind Forest", new Vector2(anchoesc/8,35), Color.Maroon,0f,Vector2.Zero,1.8f,SpriteEffects.None,0f);
        }

        public void Draw_tuto(GameTime gameTime) {
            bg = Content.Load<Texture2D>("bg");
            spriteBatch.Draw(bg, pres, Color.DarkBlue);
            spriteBatch.DrawString(fuente, "Instrucciones", new Vector2(anchoesc / 5, 35), Color.CornflowerBlue, 0f, Vector2.Zero, 1.8f, SpriteEffects.None, 0f);
            ctrl_0 = Content.Load<Texture2D>("ctrl_0");
            spriteBatch.DrawString(fuente, "Mover", new Vector2(190, 270), Color.CornflowerBlue, 0f, Vector2.Zero, .6f, SpriteEffects.None, 0f);
            ctrl_1 = Content.Load<Texture2D>("ctrl_1");
            spriteBatch.DrawString(fuente, "Correr", new Vector2(450, 270), Color.CornflowerBlue, 0f, Vector2.Zero, .6f, SpriteEffects.None, 0f);
            ctrl_2 = Content.Load<Texture2D>("ctrl_2");
            spriteBatch.DrawString(fuente, "Saltar", new Vector2(725, 270), Color.CornflowerBlue, 0f, Vector2.Zero, .6f, SpriteEffects.None, 0f);
            spriteBatch.Draw(ctrl_0, tuto_0, Color.White);
            spriteBatch.Draw(ctrl_1, tuto_1, Color.White);
            spriteBatch.Draw(ctrl_2, tuto_2, Color.White);
            spriteBatch.DrawString(fuente, "Presiona shift para Comenzar", new Vector2(anchoesc / 4 +25, 600), Color.CornflowerBlue, 0f, Vector2.Zero,.6f, SpriteEffects.None, 0f);
            mapa.Draw(spriteBatch);
            player.Dibujatuto(spriteBatch, gameTime);
        }

        public void Draw_nivel1(GameTime gameTime)
        {
             bg = Content.Load<Texture2D>("bg");
            spriteBatch.Draw(bg, esc, Color.White);
            spriteBatch.DrawString(fuente,"Score: "+score,new Vector2(anchoesc/4,5),Color.Beige,0f,Vector2.Zero,.6f,SpriteEffects.None,0f);
            spriteBatch.DrawString(fuente,"Vidas: "+vidas,new Vector2(anchoesc/2, 5),Color.Beige,0f,Vector2.Zero,.6f,SpriteEffects.None,0f);
            mapa.Draw(spriteBatch);            
            player.Dibuja(spriteBatch,gameTime);
       
        }
        public void Draw_nivel2(GameTime gameTime)
        {
            bg=Content.Load<Texture2D>("bg2");            
            spriteBatch.Draw(bg, esc, Color.White);
            spriteBatch.DrawString(fuente, "Score: " +score, new Vector2(anchoesc / 4, 5), Color.Beige, 0f, Vector2.Zero, .48f, SpriteEffects.None, 0f);
            spriteBatch.DrawString(fuente, "Vidas: " +vidas, new Vector2(anchoesc / 2, 5), Color.Beige, 0f, Vector2.Zero, .48f, SpriteEffects.None, 0f);
            mapa.Draw(spriteBatch);
            player.Dibuja(spriteBatch, gameTime);
        }
        public void Draw_nivel3(GameTime gameTime)
        {
            bg = Content.Load<Texture2D>("bg3");
            spriteBatch.Draw(bg, esc, Color.White);
            spriteBatch.DrawString(fuente, "Score: " +score, new Vector2(anchoesc / 4, 5), Color.Beige, 0f, Vector2.Zero, .48f, SpriteEffects.None, 0f);
            spriteBatch.DrawString(fuente, "Vidas: " +vidas, new Vector2(anchoesc / 2, 5), Color.Beige, 0f, Vector2.Zero, .48f, SpriteEffects.None, 0f);
            mapa.Draw(spriteBatch);
            player.Dibuja(spriteBatch, gameTime);
        }
        public void Draw_gameover(GameTime gameTime)
        {
            
            spriteBatch.Draw(bg,esc,Color.Peru);
            spriteBatch.DrawString(fuente, "Has perdido\npresiona R para reiniciar\no Esc para salir", new Vector2(anchoesc / 2, altoesc / 2), Color.White, 0f, Vector2.Zero, .8f, SpriteEffects.None, 0f);
        }
        public void Draw_terminado(GameTime gameTime) {
            spriteBatch.Draw(bg, esc, Color.GreenYellow);
            spriteBatch.DrawString(fuente, "Gracias por Jugar\nPresiona R para reiniciar\no Esc para salir", new Vector2(anchoesc / 2, altoesc / 2), Color.White, 0f, Vector2.Zero, .8f, SpriteEffects.None, 0f);
        }
    }
}
