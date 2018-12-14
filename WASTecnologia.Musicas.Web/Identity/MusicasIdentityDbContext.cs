using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WASTecnologia.Musicas.Web.Identity
{

    //Contexto usado exclusivamente para Identity Framework

    public class MusicasIdentityDbContext : IdentityDbContext<IdentityUser>
    {
        public MusicasIdentityDbContext() :base("MusicasDbContext")
        {

        }
    }
}