// © 2007 Michele Leroux Bustamante. All rights reserved 
// Book: Learning WCF, O'Reilly
// Book Blog: www.thatindigogirl.com
// Michele's Blog: www.dasblonde.net
// IDesign: www.idesign.net
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.ServiceModel;

namespace ExternalClient
{
    public partial class Form1 : Form
    {
        ServiceA.ServiceAClient m_proxyA;
        ServiceB.ServiceBClient m_proxyB;
        public Form1()
        {
            InitializeComponent();

            //Below way to initialize proxy is also OK.
            //ChannelFactory<ExternalClient.ServiceA.ServiceAClient> factoryA = new ChannelFactory<ExternalClient.ServiceA.ServiceAClient>();
            //m_proxyA = factoryA.CreateChannel();


            m_proxyA = new ExternalClient.ServiceA.ServiceAClient("BasicHttpBinding_IServiceA");
            m_proxyB = new ExternalClient.ServiceB.ServiceBClient("BasicHttpBinding_IServiceB");
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.m_proxyA.State == CommunicationState.Faulted)
                this.m_proxyA.Abort();
            else
                this.m_proxyA.Close();
            if (this.m_proxyB.State == CommunicationState.Faulted)
                this.m_proxyB.Abort();
            else
                this.m_proxyB.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string s = m_proxyA.Operation1( );
            MessageBox.Show("24234234324");
        }
        private void button2_Click(object sender, EventArgs e)
        {
            string s = m_proxyA.Operation2();
            MessageBox.Show(s);
        }
        private void button3_Click(object sender, EventArgs e)
        {
            string s = m_proxyB.Operation3();
            MessageBox.Show(s);
        }
    }
}