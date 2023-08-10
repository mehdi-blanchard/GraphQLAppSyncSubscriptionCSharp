using GraphQL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SubTest
{
    public partial class Form1 : Form
    {
        private RTGQLConnect _rtGQLConnect = null;

        public Form1()
        {
            InitializeComponent();
            TodoGQL.InitializeGQL();
        }

        private async void buttonGetTodos_Click(object sender, EventArgs e)
        {
            await getTodosAsync();
        }

        private async Task getTodosAsync()
        {
            List<Todo> todos = await TodoGQL.GetTodos();
            labelQuery.Text = $"Retrieved {todos.Count} Todos";
        }

        private void buttonInitializeClient_Click(object sender, EventArgs e)
        {
            try
            {
                if (_rtGQLConnect == null)
                {
                    _rtGQLConnect = new RTGQLConnect();
                    _rtGQLConnect.InitializeGQL();
                    labelMessage.Text = "The RTGQL Client is initialized";
                }
            }
            catch (Exception ex)
            {
                _rtGQLConnect = null;
                labelMessage.Text = "Exception: " + ex.Message;
            }
        }

        private async void buttonInitializeConnection_Click(object sender, EventArgs e)
        {
            if (_rtGQLConnect == null)
            {
                labelMessage.Text = "Please initialize Client first";
                return;
            }
            try
            {
                await _rtGQLConnect.InitializeConnection();
                labelMessage.Text = "InitializeWebsocketConnection Successful!";
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Exception: " + ex.Message;
            }
        }

        private void buttonSubscribeTodo_Click(object sender, EventArgs e)
        {
            if (_rtGQLConnect == null)
            {
                labelMessage.Text = "Please initialize Client first";
                return;
            }
            try
            {
                GraphQLRequest request = TodoGQLRequests.TodoCreatedSubscriptionRequest();

                _rtGQLConnect.GQLClient.CreateSubscriptionStream<CreateTodoSubscriptionResult>(request).Subscribe(create =>
                {
                    labelMessage.Text = "Notification: " + JsonSerializer.Serialize(create);
                },
                error =>
                {
                    labelMessage.Text = "SUBSCRIPTION ERROR: " + error.Message;
                },
                () =>
                {
                    labelStatus.Text = "Completed.";
                });
                labelMessage.Text = "The Subscription has been registered";
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Exception: " + ex.Message;
            }
        }
    }
}
