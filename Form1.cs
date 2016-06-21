using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication2
{
    public partial class Form1 : Form
    {

        #region Constructors...

        #region Form1     
        public Form1()
        {
            InitializeComponent();
            Initialize();
        }
        #endregion Form1 

        #endregion Constructors...

        #region Methods...
        
        #region Initialize     
        private void Initialize()
        {
            TeamMember[] Data = InitializeData();

            //Data Grid View
            dataGridView1.DataSource = Data;

            //Ultra Grid
            ultraGrid1.DataSource = Data;

            //List Box
            Dictionary<string, TeamMember> TeamMemberByName = new Dictionary<string, TeamMember>();
            foreach(TeamMember member in Data)
            {
                string FullName = string.Format("{0} {1}. {2}", member.FirstName, member.MiddleInitial, member.LastName);
                TeamMemberByName.Add(FullName, member);
            }
            listBox1.DataSource = TeamMemberByName.Keys.ToArray();
            listBox1.MultiColumn = true;
            listBox1.SelectionMode = SelectionMode.MultiExtended;

            //Flow Layout Panel
            foreach(TeamMember member in Data)
            {
                CheckBox TeamMemberCheckBox = new CheckBox();
                TeamMemberCheckBox.Text = string.Format("{0} {1}. {2}", member.FirstName, member.MiddleInitial, member.LastName);
                TeamMemberCheckBox.Tag = member;
                TeamMemberCheckBox.AutoSize = true;

                flowLayoutPanel1.Controls.Add(TeamMemberCheckBox);
            }
        }
        #endregion Initialize
        
        #region InitializeData     
        private TeamMember[] InitializeData()
        {
            List<TeamMember> Result = new List<TeamMember>();
            Result.Add(new TeamMember("Julia", "B", "Winegeart"));
            Result.Add(new TeamMember("Harry", "J", "Potter"));
            Result.Add(new TeamMember("Ronald", "B", "Weasely"));
            Result.Add(new TeamMember("Hermione", "J", "Granger"));
            return Result.ToArray();
        }
        #endregion InitializeData

        #endregion Methods...

    }

    #region TeamMember
    public class TeamMember
    {
        public bool Select { get; set; }
        public string FirstName { get; set; }
        public string MiddleInitial { get; set; }
        public string LastName { get; set; }

        public TeamMember()
        {
            FirstName = "John";
            MiddleInitial = "Q";
            LastName = "Public";
        }

        public TeamMember(string firstname, string middleinitial, string lastname)
        {
            FirstName = firstname;
            MiddleInitial = middleinitial;
            LastName = lastname;
        }
    }
    #endregion TeamMember
}
