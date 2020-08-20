using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialUserPosts.Controllers
{
    public  class CrypDecryp
    {
        public string Cryp(string _data)
        {
            string result = string.Empty;
            byte[] encryted = System.Text.Encoding.Unicode.GetBytes(_data);
            result = Convert.ToBase64String(encryted);
            return result;
        }


        public string DesEncriptar(string _data)
        {
            string result = string.Empty;
            byte[] decryted = Convert.FromBase64String(_data);
            result = System.Text.Encoding.Unicode.GetString(decryted);
            return result;
        }
    }

}
