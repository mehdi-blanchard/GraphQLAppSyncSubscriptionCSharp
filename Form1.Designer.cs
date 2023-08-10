namespace SubTest
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonGetTodos = new System.Windows.Forms.Button();
            this.buttonSubscribe = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.labelMessage = new System.Windows.Forms.Label();
            this.buttonInitializeConnection = new System.Windows.Forms.Button();
            this.buttonSubscribeTodo = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.labelQuery = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonGetTodos
            // 
            this.buttonGetTodos.Location = new System.Drawing.Point(42, 19);
            this.buttonGetTodos.Name = "buttonGetTodos";
            this.buttonGetTodos.Size = new System.Drawing.Size(163, 37);
            this.buttonGetTodos.TabIndex = 1;
            this.buttonGetTodos.Text = "Get Todos";
            this.buttonGetTodos.UseVisualStyleBackColor = true;
            this.buttonGetTodos.Click += new System.EventHandler(this.buttonGetTodos_Click);
            // 
            // buttonSubscribe
            // 
            this.buttonSubscribe.Location = new System.Drawing.Point(261, 36);
            this.buttonSubscribe.Name = "buttonSubscribe";
            this.buttonSubscribe.Size = new System.Drawing.Size(163, 37);
            this.buttonSubscribe.TabIndex = 3;
            this.buttonSubscribe.Text = "Create RT Client";
            this.buttonSubscribe.UseVisualStyleBackColor = true;
            this.buttonSubscribe.Click += new System.EventHandler(this.buttonInitializeClient_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 158);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Response:";
            // 
            // labelMessage
            // 
            this.labelMessage.AutoSize = true;
            this.labelMessage.Location = new System.Drawing.Point(89, 158);
            this.labelMessage.Name = "labelMessage";
            this.labelMessage.Size = new System.Drawing.Size(16, 13);
            this.labelMessage.TabIndex = 5;
            this.labelMessage.Text = "...";
            // 
            // buttonInitializeConnection
            // 
            this.buttonInitializeConnection.Location = new System.Drawing.Point(163, 95);
            this.buttonInitializeConnection.Name = "buttonInitializeConnection";
            this.buttonInitializeConnection.Size = new System.Drawing.Size(163, 37);
            this.buttonInitializeConnection.TabIndex = 6;
            this.buttonInitializeConnection.Text = "Initialize Connection";
            this.buttonInitializeConnection.UseVisualStyleBackColor = true;
            this.buttonInitializeConnection.Click += new System.EventHandler(this.buttonInitializeConnection_Click);
            // 
            // buttonSubscribeTodo
            // 
            this.buttonSubscribeTodo.Location = new System.Drawing.Point(381, 95);
            this.buttonSubscribeTodo.Name = "buttonSubscribeTodo";
            this.buttonSubscribeTodo.Size = new System.Drawing.Size(155, 37);
            this.buttonSubscribeTodo.TabIndex = 7;
            this.buttonSubscribeTodo.Text = "Subscribe to Todo";
            this.buttonSubscribeTodo.UseVisualStyleBackColor = true;
            this.buttonSubscribeTodo.Click += new System.EventHandler(this.buttonSubscribeTodo_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.labelQuery);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.buttonGetTodos);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(776, 142);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Query";
            // 
            // labelQuery
            // 
            this.labelQuery.AutoSize = true;
            this.labelQuery.Location = new System.Drawing.Point(98, 89);
            this.labelQuery.Name = "labelQuery";
            this.labelQuery.Size = new System.Drawing.Size(16, 13);
            this.labelQuery.TabIndex = 7;
            this.labelQuery.Text = "...";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(39, 89);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Response:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.buttonInitializeConnection);
            this.groupBox2.Controls.Add(this.buttonSubscribeTodo);
            this.groupBox2.Controls.Add(this.labelMessage);
            this.groupBox2.Controls.Add(this.buttonSubscribe);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(21, 177);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(767, 214);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "WebSocket";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 405);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "GraphQL Subscriptions";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button buttonGetTodos;
        private System.Windows.Forms.Button buttonSubscribe;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelMessage;
        private System.Windows.Forms.Button buttonInitializeConnection;
        private System.Windows.Forms.Button buttonSubscribeTodo;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label labelQuery;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}

