﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Dominio
{
    //public enum TipoAdmin
    //{
    //    USER = 0,
    //    ADMIN = 1
    //}
    public class Usuario
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Pass { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string urlImagenPerfil { get; set; }
        //public TipoAdmin TipoUsuario { get; set; }
         public bool TipoUsuario { get; set; }

        public Usuario(string email, string pass, bool admin)
        {
            Email = email;
            Pass = pass;
            TipoUsuario = admin;

        }
        //public Usuario(string email, string pass, bool admin)
        //{
        //    Email = email;
        //    Pass = pass;
        //    TipoUsuario = admin ? TipoAdmin.ADMIN : TipoAdmin.USER;

        //}
        public Usuario()
        {
            
        }
    }
}
