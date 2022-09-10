using FictionalEureka.API.Entities.Base;
using System;

namespace FictionalEureka.API.Entities;

public class ToDo : BaseEntity
{
    public string Nome { get; set; }
    public bool Active { get; set; }
}
