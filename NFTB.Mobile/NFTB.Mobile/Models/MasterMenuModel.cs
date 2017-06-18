﻿using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;
using NFTB.Mobile.UI.Pages;
using Xamarin.Forms;

namespace NFTB.Mobile.Models
{
    public class MasterMenuModel
    {
        protected MasterDetailPage MasterPage;
        private ContentPage TermListPage = new TermList();
        private ContentPage PlayerListPage = new PlayerList();
        private ContentPage AttendanceEditorPage = new AttendanceEditor();



        public ICommand OnTermList
        {
            get
            {
                return new Command(() => this.TermList());
            }
        }

        public ICommand OnPlayerList
        {
            get
            {
                return new Command(() => this.PlayerList());
            }
        }

        public MasterMenuModel(MasterDetailPage masterPage)
        {
            this.MasterPage = masterPage;
            this.TermList();
        }

        public void TermList()
        {
            this.MasterPage.Detail = this.TermListPage;
            this.MasterPage.Title = this.TermListPage.Title;
            this.MasterPage.IsPresented = false;
        }

        public void PlayerList()
        {
            this.MasterPage.Detail = this.PlayerListPage;
            this.MasterPage.IsPresented = false;
        }

        public void AttendanceList()
        {
            this.MasterPage.Detail = AttendanceEditorPage;
            this.MasterPage.IsPresented = false;
        }

    }

}
