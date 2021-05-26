using Aula1AspNetMVC.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Aula1AspNetMVC.Context
{
    [DbConfigurationType(typeof(MySql.Data.EntityFramework.MySqlEFConfiguration, MySql.Data.EntityFramework))]
    public class Aula1Context : DbContext // Define que a classe esta relacionada ao contexto
    {
        public Aula1Context() : base("Aula1Context") //nome da connectionString no webConfig
        {

        }

        public DbSet<Cliente> Cliente { get; set; } //Referenciando um Model, ela seria uma tabela para ser gerada
    }
}