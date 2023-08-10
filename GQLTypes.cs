using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubTest
{
    public class Todo
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
    }

    public class ResponseTypeTodos
    {
        public Todos ListTodos { get; set; }
    }

    public class Todos
    {
        public List<Todo> Items { get; set; }
        public string NextToken { get; set; }
    }

    public class ResponseTypeCreateTodo
    {
        public Todo CreateTodo { get; set; }
    }

    public class CreateTodoSubscriptionResult
    {
        public Todo OnCreateTodo { get; set; }
    }
}
