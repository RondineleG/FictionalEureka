using FictionalEureka.API.Entities;
using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FictionalEureka.API.Repository;

public class ToDoRepository
{
    private string DatabaseName = @".\Data\Todo.db";
    private string TableName = "tasktodo";

    public IEnumerable<ToDo> Listar()
    {
        using (var db = new LiteDatabase(DatabaseName))
        {
            var taskCollection = db.GetCollection<ToDo>(TableName);

            var resultCollection = taskCollection.FindAll();

            return resultCollection.ToList();
        }
    }

    public ToDo Consultar(Guid id)
    {
        using (var db = new LiteDatabase(DatabaseName))
        {
            var taskCollection = db.GetCollection<ToDo>(TableName);
            var taskToDo = taskCollection.FindOne(x => x.Id == id);
            return taskToDo;
        }
    }


    public void Adicionar(ToDo task)
    {
        using (var db = new LiteDatabase(DatabaseName))
        {
            var taskCollection = db.GetCollection<ToDo>(TableName);
            taskCollection.Insert(task);
        }
    }

    public bool Alterar(ToDo task, Guid id)
    {
        using (var db = new LiteDatabase(DatabaseName))
        {
            var taskCollection = db.GetCollection<ToDo>(TableName);

            var originalTask = taskCollection.FindOne(x => x.Id == id);
            if (originalTask == null)
                return false;

            originalTask.Nome = task.Nome;
            originalTask.Active = task.Active;

            taskCollection.Update(originalTask);
            return true;
        }
    }

    public void Excluir(Guid id)
    {
        using (var db = new LiteDatabase(DatabaseName))
        {
            var usuarioCollection = db.GetCollection<ToDo>(TableName);

            usuarioCollection.Delete(id);
        }
    }
}