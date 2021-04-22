using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Listboxes
{
    public partial class lists : Form
    {
        List<int> numbers = new List<int>();
        List<string> heroes = new List<string>();
        Random generator = new Random();
        int numIndex, counter;
        string removeHero, addHero;
        public lists()
        {
            InitializeComponent();
        }

        private void lists_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < 20; i++)
                numbers.Add(generator.Next(100));
            lstNumbers.DataSource = numbers;

            heroes.Add("Superman");
            heroes.Add("Batman");
            lstHeroes.DataSource = heroes;
        }

        private void btnSortNumbers_Click(object sender, EventArgs e)
        {
            numbers.Sort();
            lstNumbers.DataSource = null;
            lstNumbers.DataSource = numbers;
            lblStatus.Text = "Status: numbers sorted";
        }

        private void btnSortHeroes_Click(object sender, EventArgs e)
        {
            heroes.Sort();
            lstHeroes.DataSource = null;
            lstHeroes.DataSource = heroes;
            lblStatus.Text = "Status: heroes sorted";
        }

        private void btnNewNumbers_Click(object sender, EventArgs e)
        {
            numbers.Clear();
            for (int i = 0; i < 20; i++)
                numbers.Add(generator.Next(100));
            lstNumbers.DataSource = null;
            lstNumbers.DataSource = numbers;
            lblStatus.Text = "Status: new numbers list";
        }

        private void btnNewHeroes_Click(object sender, EventArgs e)
        {
            heroes.Clear();
            heroes.Add("Superman");
            heroes.Add("Batman");
            lstHeroes.DataSource = null;
            lstHeroes.DataSource = heroes;
            lblStatus.Text = "Status: new hero list";
        }

        private void btnRemoveNumber_Click(object sender, EventArgs e)
        {
            if (lstNumbers.SelectedIndex >= 0)
            {
                numIndex = lstNumbers.SelectedIndex;
                numbers.RemoveAt(numIndex);
                lstNumbers.DataSource = null;
                lstNumbers.DataSource = numbers;
                lblStatus.Text = "Status: number removed";
            }
        }

        private void btnRemoveAllNumbers_Click(object sender, EventArgs e)
        {
            if (lstNumbers.SelectedIndex >= 0)
            {
                numIndex = lstNumbers.SelectedIndex;
                int number = numbers[numIndex];
                counter = 0;
                 while(numbers.Remove(number))
                {
                    counter++;
                }

                lstNumbers.DataSource = null;
                lstNumbers.DataSource = numbers;
                lblStatus.Text = $"Status: {counter} numbers removed";
            }
        }
        private void btnRemoveHero_Click(object sender, EventArgs e)
        {
            removeHero = txtRemoveHero.Text.Trim();
            bool result = heroes.Remove(removeHero);
            lstHeroes.DataSource = null;
            lstHeroes.DataSource = heroes;
            if (result)
            {
                lblStatus.Text = $"Status: {removeHero} removed";
            }
            else
            {
                lblStatus.Text = $"Status: Unsuccessful removal";
            }
        }

        private void btnAddHero_Click(object sender, EventArgs e)
        {
            addHero = txtAddHero.Text.Trim();
            if (addHero == "")
            {
                return;
            }
            
            if (heroes.Contains(addHero))
            {
                return;
            }

            heroes.Add(addHero);
            lstHeroes.DataSource = null;
            lstHeroes.DataSource = heroes;
            lblStatus.Text = $"Status: {addHero} added";
            txtAddHero.Text = "";
        }

    }
}
