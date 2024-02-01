using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quanlybanhang
{
    class KhachHang
    {
        private String code;
        private String name;
        private String address;
        private String phoneNumber;

        public KhachHang()
        {

        }
        public KhachHang(String code, String name, String address, String phoneNumber)
        {
            this.code= code;
            this.name= name;
            this.address= address;
            this.phoneNumber= phoneNumber;
        }
        public String getCode() { return code; }
        public String getName() { return name; }
        public String getAddress() { return address; }
        public String getPhoneNumber() { return phoneNumber; }
        public void setCode(String code) { this.code = code;}
        public void setName(String name) { this.name = name;}
        public void setAddress(String address) { this.address = address;}
        public void setPhoneNumber(String phoneNumber) { this.phoneNumber = phoneNumber;}
    }
}
