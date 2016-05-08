using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Kleps.Engine.Events;
using Kleps.Engine.Game;
using LiteDB;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace EventEditor
{
    public partial class MainForm : Form {
        private string _path;
        private LiteDatabase _db;
        private BindingList<GameEventData> _eventsList;
        private LiteCollection<GameEventData> _eventsCollection; 

        public MainForm()
        {
            InitializeComponent();
            SelectDb();
            InitDb();
            InitFormData();
        }

        private void InitFormData()
        {
            _eventsCollection = _db.GetCollection<GameEventData>("events");

            _eventsList = _eventsCollection.FindAll().ToBindingList();

           EventsListBox.SelectedIndexChanged += (s, e) => {
                var item = EventsListBox.SelectedItem as GameEventData;
                EventTextBox.Text = item.text;
                AnswersListBox.DataSource = new BindingSource {DataSource = item.answers};
                RightAnswerBox.Text = item.rightAnswer;
            };

            AddAnswerButton.Click += (s, e) => {
                if (NewAnswerBox.Text.Length > 0) {
                    var answers = (BindingList<string>)((BindingSource)AnswersListBox.DataSource).DataSource;
                    answers.Add(NewAnswerBox.Text);
                }
            };

            NewEventButton.Click += (s, e) => {
                _eventsList.Add(new GameEventData {
                    text = "new",
                    rightAnswer = "",
                    answers = new List<string>()
                });
            };

            EventsListBox.DataSource = new BindingSource {DataSource = _eventsList};
            EventsListBox.ValueMember = "text";
        }

        private void SelectDb()
        {
            using (var ofd = new OpenFileDialog()) {
                if (ofd.ShowDialog() == DialogResult.OK) {
                    _path = ofd.FileName;
                }
            }
        }

        private void InitDb()
        {
            try {
                _db = new LiteDatabase(_path);
            }
            catch (Exception) {
                MessageBox.Show("Cannot open the database.");
                Environment.Exit(1);
            }
        }

        private void MegaOmegaParser_Click(object sender, EventArgs e)
        {
            var d = new Deserializer(namingConvention: new CamelCaseNamingConvention());
            var config = d.Deserialize<List<GameEventData>>(new StreamReader(new FileStream("omega.yaml", FileMode.Open)));

        }
    }
}
