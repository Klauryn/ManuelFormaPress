//using DevExpress.XtraEditors.Design;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Csharp.Pages.SAP_Production
{
    internal class ShoppingCard
    {
        public Tuple<string, string, string, string> recete;
        public Tuple<string, string, string, string> Recete
        {
            get { return recete; }
            set { recete = value; }
        }

        private string malzemeBilgisi;
        public string MalzemeBilgisi
        {
            get { return malzemeBilgisi; }
            set { malzemeBilgisi = value; }
        }

        private string formYuksekligi;
        public string FormYuksekligi
        {
            get { return formYuksekligi; }
            set { formYuksekligi = value; }
        }

        private string formGenisligi;
        public string FormGenisligi
        {
            get { return formGenisligi; }
            set { formGenisligi = value; }
        }

        private string formKalinligi;
        public string FormKalinligi
        {
            get { return formKalinligi; }
            set { formKalinligi = value; }
        }

        private int adet;
        public int Adet
        {
            get { return adet; }
            set { adet = value; }
        }

        private int uretilenAdet;
        public int UretilenAdet
        {
            get { return uretilenAdet; }
            set { uretilenAdet = value; }
        }

        private int kullanilanAdet;
        public int KullanilanAdet
        {
            get { return kullanilanAdet; }
            set { kullanilanAdet = value; }
        }


        private int qrCode;
        public int QrCode
        {
            get { return qrCode; }
            set { qrCode = value; }
        }

        private string urunAciklama;
        public string UrunAciklama
        {
            get { return urunAciklama; }
            set { urunAciklama = value; }
        }

        private string dateTime;
        public string DateTime
        {
            get { return dateTime; }
            set { dateTime = value; }
        }

        public string GetRecipeName()
        {
            string selectedRecipeFromSAP = recete.Item1 + "_" + recete.Item2 + "_" + recete.Item3 + "_" + recete.Item4;
            return selectedRecipeFromSAP;
        }
        
        public ShoppingCard(string _malzemeBilgisi, string _formYuksekligi, string _formGenisligi, string _formKalinligi, int _adet, int _qrCode, string _urunAcikama)
        {
            recete = new Tuple<string, string, string, string>(_malzemeBilgisi, _formYuksekligi, _formGenisligi, _formKalinligi);
            adet = _adet;
            qrCode = _qrCode;
            urunAciklama = _urunAcikama;
        }
        
    }

    
}
