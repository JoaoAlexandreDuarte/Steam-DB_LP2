﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Steam_DB {
    public partial class Form1 : Form {
        private ICollection<Game> database;
        CSVParser csvParser;

        public Form1() {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) {
            database = new HashSet<Game>();
            csvParser = new CSVParser();
        }

        private void btnReadFile_Click(object sender, EventArgs e) {
            OpenFileDialog file = new OpenFileDialog();

            if (file.ShowDialog() == DialogResult.OK) {
                string filePath = file.FileName;

                csvParser.ReadCSVFile(database, filePath);

                var source = new BindingSource();
                source.DataSource = database;
                dataGridView1.DataSource = source;
            } else {
                MessageBox.Show("Error! Please confirm it's the correct file" +
                    " and it's of type .csv");
            }
        }
    }
}
