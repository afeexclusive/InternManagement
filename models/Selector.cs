using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagment.models
{
    public class Selector
    {

        public enum ProjectStatus
        {
            Completed,
            Incomplete,
            Abandoned
        }

        public enum ProgramDuration
        {
            One_Month,
            Two_Month,
            Three_Month,
            Four_Month,
            Five_Month,
            Six_Month,
            Seven_Month

        }


        public enum ProgrammeNames
        {
            Graphics,
            FrontEnd,
            FullStackWeb,
            FullStackMobile,
            WebDesign,
            UI_UX
        }

        public enum CourseLevel
        {
            Beginner,
            Intermidiate,
            Advanced
        }

        public enum CourseName
        {
            Html,
            Css,
            C_Sharp,
            AspNet,
            Xamarin,
            Angular,
            PhotoShop,
            Adobe_Illustrator,
            JavaScript,
            React
        }

        
        public enum Batch
        {
            [Display(Name ="Batch A")]
            Batch_A,
            [Display(Name = "Batch B")]
            Batch_B,
            [Display(Name = "Batch C")]
            Batch_C,
            [Display(Name = "Batch D")]
            Batch_D,
            [Display(Name = "Batch E")]
            Batch_E,
            [Display(Name = "Batch F")]
            Batch_F
        }

        public enum Marital
        {
            Single,
            Married,
            Widow,
            Widower
        }

        public enum Gender
        {
            Male,
            Female,
            Other
        }

        public enum BatchYear
        {
            [Display(Name = "2015")]
            Year2015,
            [Display(Name = "2016")]
            Year2016,
            [Display(Name = "2017")]
            Year2017,
            [Display(Name = "2018")]
            Year2018,
            [Display(Name = "2019")]
            Year2019,
            [Display(Name = "2020")]
            Year2020,
            [Display(Name = "2021")]
            Year2021,
            [Display(Name = "2022")]
            Year2022,
            [Display(Name = "2023")]
            Year2023
            
        }

        public enum Nationality
        {
            Afghanistan,
            Albania,
            Algeria,
            Andorra,
            Angola,
            Antigua_Barbuda,
            Argentina,
            Armenia,
            Australia,
            Austria,
            Azerbaijan,
            Bahamas,
            Bahrain,
            Bangladesh,
            Barbados,
            Belarus,
            Belgium,
            Belize,
            Benin,
            Bhutan,
            Bolivia,
            Bosnia_and_Herzegovina,
            Botswana,
            Brazil,
            Brunei,
            Bulgaria,
            Burkina_Faso,
            Burundi,
            Cabo_Verde,
            Cambodia,
            Cameroon,
            Canada,
            Central_African_Republic,
            Chad,
            Chile,
            China,
            Colombia,
            Comoros,
            Congo_Democratic_Republic_of_the,
            Congo_Republic_of_the,
            Costa_Rica,
            Cote_d_Ivoire,
            Croatia,
            Cuba,
            Cyprus,
            Czechia,
            Denmark,
            Djibouti,
            Dominica,
            Dominican_Republic,
            Ecuador,
            Egypt,
            El_Salvador,
            Equatorial_Guinea,
            Eritrea,
            Estonia,
            Eswatini_formerly_Swaziland,
            Ethiopia,
            Fiji,
            Finland,
            France,
            Gabon,
            Gambia,
            Georgia,
            Germany,
            Ghana,
            Greece,
            Grenada,
            Guatemala,
            Guinea,
            Guinea_Bissau,
            Guyana,
            Haiti,
            Honduras,
            Hungary,
            Iceland,
            India,
            Indonesia,
            Iran,
            Iraq,
            Ireland,
            Israel,
            Italy,
            Jamaica,
            Japan,
            Jordan,
            Kazakhstan,
            Kenya,
            Kiribati,
            Kosovo,
            Kuwait,
            Kyrgyzstan,
            Laos,
            Latvia,
            Lebanon,
            Lesotho,
            Liberia,
            Libya,
            Liechtenstein,
            Lithuania,
            Luxembourg,
            Madagascar,
            Malawi,
            Malaysia,
            Maldives,
            Mali,
            Malta,
            Marshall_Islands,
            Mauritania,
            Mauritius,
            Mexico,
            Micronesia,
            Moldova,
            Monaco,
            Mongolia,
            Montenegro,
            Morocco,
            Mozambique,
            Myanmar_formerly_Burma,
            Namibia,
            Nauru,
            Nepal,
            Netherlands,
            New_Zealand,
            Nicaragua,
            Niger,
            Nigeria,
            North_Korea,
            North_Macedonia_formerly_Macedonia,
            Norway,
            Oman,
            Pakistan,
            Palau,
            Palestine,
            Panama,
            Papua_New_Guinea,
            Paraguay,
            Peru,
            Philippines,
            Poland,
            Portugal,
            Qatar,
            Romania,
            Russia,
            Rwanda,
            Saint_Kitts_and_Nevis,
            Saint_Lucia,
            Saint_Vincent_and_the_Grenadines,
            Samoa,
            San_Marino,
            Sao_Tome_and_Principe,
            Saudi_Arabia,
            Senegal,
            Serbia,
            Seychelles,
            Sierra_Leone,
            Singapore,
            Slovakia,
            Slovenia,
            Solomon_Islands,
            Somalia,
            South_Africa,
            South_Korea,
            South_Sudan,
            Spain,
            Sri_Lanka,
            Sudan,
            Suriname,
            Sweden,
            Switzerland,
            Syria,
            Taiwan,
            Tajikistan,
            Tanzania,
            Thailand,
            Timor_Leste,
            Togo,
            Tonga,
            Trinidad_and_Tobago,
            Tunisia,
            Turkey,
            Turkmenistan,
            Tuvalu,
            Uganda,
            Ukraine,
            United_Arab_Emirates_UAE,
            United_Kingdom_UK,
            United_States_of_America_USA,
            Uruguay,
            Uzbekistan,
            Vanuatu,
            Vatican_City_Holy_See,
            Venezuel,
            Vietnam,
            Yemen,
            Zambia,
            Zimbabwe
        }

        public enum Status
        {
            InTraining,
            Left,
            Graduated,
            Disqualify,
            Deffered,
            Fresher
        }

        public enum AddmissionType
        {
            Paid,
            IncomeSharing
        }

        public enum Grade
        {
            A,
            B,
            C,
            D
        }

        public enum PayMethod
        {
            BankTransfer,
            MobileTransfer,
            POSTransfer,
            CashPayment
        }
    }
}
