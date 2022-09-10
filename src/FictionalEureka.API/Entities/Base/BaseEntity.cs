using System;

namespace FictionalEureka.API.Entities.Base;

public abstract class BaseEntity
{
    public Guid Id { get; private set; }
    public BaseEntity() => Id = Guid.NewGuid();
}
