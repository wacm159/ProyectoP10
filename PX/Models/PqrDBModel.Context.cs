﻿

//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------


namespace PX.Models
{

using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;


public partial class ParqueoDBEntities1 : DbContext
{
    public ParqueoDBEntities1()
        : base("name=ParqueoDBEntities1")
    {

    }

    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        throw new UnintentionalCodeFirstException();
    }


    public virtual DbSet<Catalogo> Catalogo { get; set; }

    public virtual DbSet<Categoria> Categoria { get; set; }

    public virtual DbSet<Conductor> Conductor { get; set; }

    public virtual DbSet<parqueo> parqueo { get; set; }

    public virtual DbSet<Servicios> Servicios { get; set; }

    public virtual DbSet<Ticket> Ticket { get; set; }

    public virtual DbSet<Ubicacion> Ubicacion { get; set; }

    public virtual DbSet<Vehiculo> Vehiculo { get; set; }

    public virtual DbSet<Vehiculo_parqueo> Vehiculo_parqueo { get; set; }

}

}
