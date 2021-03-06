﻿using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Flenergy.Data.Migrations
{
    public partial class init13 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AdmStates",
                columns: table => new
                {
                    StateId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    StateName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdmStates", x => x.StateId);
                });

            migrationBuilder.CreateTable(
                name: "LocalGovernments",
                columns: table => new
                {
                    LocalGovernmentId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    LocalGovernmentName = table.Column<string>(nullable: true),
                    StateId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocalGovernments", x => x.LocalGovernmentId);
                    table.ForeignKey(
                        name: "FK_LocalGovernments_AdmStates_StateId",
                        column: x => x.StateId,
                        principalTable: "AdmStates",
                        principalColumn: "StateId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AdmStates",
                columns: new[] { "StateId", "StateName" },
                values: new object[,]
                {
                    { 1, "Abia" },
                    { 21, "Katsina" },
                    { 22, "Kebbi" },
                    { 23, "Kogi" },
                    { 24, "Kwara" },
                    { 25, "Lagos" },
                    { 26, "Nassarawa" },
                    { 27, "Niger" },
                    { 28, "Ogun" },
                    { 29, "Ondo" },
                    { 30, "Osun" },
                    { 31, "Oyo" },
                    { 32, "Plateau" },
                    { 33, "Rivers" },
                    { 34, "Sokoto" },
                    { 35, "Taraba" },
                    { 20, "Kano" },
                    { 36, "Yobe" },
                    { 19, "Kaduna" },
                    { 17, "Imo" },
                    { 2, "Adamawa" },
                    { 3, "Akwa-Ibom" },
                    { 4, "Anambra" },
                    { 5, "Bauchi" },
                    { 6, "Bayelsa" },
                    { 7, "Benue" },
                    { 8, "Borno" },
                    { 9, "Cross River" },
                    { 10, "Delta" },
                    { 11, "Ebonyi" },
                    { 12, "Edo" },
                    { 13, "Ekiti" },
                    { 14, "Enugu" },
                    { 15, "FCT" },
                    { 16, "Gombe" },
                    { 18, "Jigawa" },
                    { 37, "Zamfara" }
                });

            migrationBuilder.InsertData(
                table: "LocalGovernments",
                columns: new[] { "LocalGovernmentId", "LocalGovernmentName", "StateId" },
                values: new object[,]
                {
                    { 1, "Aba North", 1 },
                    { 511, "Alimosho", 25 },
                    { 512, "Amuwo-Odofin", 25 },
                    { 513, "Badagry", 25 },
                    { 514, "Epe", 25 },
                    { 515, "Eti Osa", 25 },
                    { 516, "Ibeju-Lekki", 25 },
                    { 517, "Ifako-Ijaiye", 25 },
                    { 518, "Ikeja", 25 },
                    { 519, "Ikorodu", 25 },
                    { 510, "Ajeromi-Ifelodun", 25 },
                    { 520, "Kosofe", 25 },
                    { 522, "Lagos Mainland", 25 },
                    { 523, "Mushin", 25 },
                    { 524, "Ojo", 25 },
                    { 525, "Oshodi-Isolo", 25 },
                    { 526, "Shomolu", 25 },
                    { 527, "Surulere", 25 },
                    { 528, "Akwanga", 26 },
                    { 529, "Awe", 26 },
                    { 530, "Doma", 26 },
                    { 521, "Lagos Island", 25 },
                    { 531, "Karu", 26 },
                    { 509, "Agege", 25 },
                    { 507, "Oyun", 24 },
                    { 487, "Okehi", 23 },
                    { 488, "Okene", 23 },
                    { 489, "Olamaboro", 23 },
                    { 490, "Omala", 23 },
                    { 491, "Yagba East", 23 },
                    { 492, "Yagba West", 23 },
                    { 493, "Asa", 24 },
                    { 494, "Baruten", 24 },
                    { 495, "Edu", 24 },
                    { 508, "Pategi", 24 },
                    { 496, "Ekiti", 24 },
                    { 498, "Ilorin East", 24 },
                    { 499, "Ilorin West", 24 },
                    { 500, "Ilorin South", 24 },
                    { 501, "Irepodun", 24 },
                    { 502, "Isin", 24 },
                    { 503, "Kaiama", 24 },
                    { 504, "Moro", 24 },
                    { 505, "Offa", 24 },
                    { 506, "Oke Ero", 24 },
                    { 497, "Ifelodun", 24 },
                    { 486, "Ogori Magongo", 23 },
                    { 532, "Keana", 26 },
                    { 534, "Kokona", 26 },
                    { 559, "Paikoro", 27 },
                    { 560, "Rafi", 27 },
                    { 561, "Rijau", 27 },
                    { 562, "Shiroro", 27 },
                    { 563, "Suleja", 27 },
                    { 564, "Tafa", 27 },
                    { 565, "Wushishi", 27 },
                    { 566, "Abeokuta North", 28 },
                    { 567, "Abeokuta South", 28 },
                    { 558, "Moya", 27 },
                    { 568, "Ado-Odo Ota", 28 },
                    { 570, "Egbado South", 28 },
                    { 571, "Ewekoro", 28 },
                    { 572, "Ifo", 28 },
                    { 573, "Ijebu East", 28 },
                    { 574, "Ijebu North", 28 },
                    { 575, "Ijebu North-East", 28 },
                    { 576, "Ijebu Ode", 28 },
                    { 577, "Ikenne", 28 },
                    { 578, "Imeko Afon", 28 },
                    { 569, "Egbado North", 28 },
                    { 533, "Keffi", 26 },
                    { 557, "Mokwa", 27 },
                    { 555, "Mariga", 27 },
                    { 535, "Lafia", 26 },
                    { 536, "Nasarawa", 26 },
                    { 537, "Nasarawa Egon", 26 },
                    { 538, "Obi", 26 },
                    { 539, "Toto", 26 },
                    { 540, "Wamba", 26 },
                    { 541, "Agaie", 27 },
                    { 542, "Agwara", 27 },
                    { 543, "Bida", 27 },
                    { 556, "Mashegu", 27 },
                    { 544, "Borgu", 27 },
                    { 546, "Chanchaga", 27 },
                    { 547, "Edati", 27 },
                    { 548, "Gbako", 27 },
                    { 549, "Gurara", 27 },
                    { 550, "Katcha", 27 },
                    { 551, "Kontagora", 27 },
                    { 552, "Lapai", 27 },
                    { 553, "Lavun", 27 },
                    { 554, "Magama", 27 },
                    { 545, "Bosso", 27 },
                    { 485, "Ofu", 23 },
                    { 484, "Mopa Muro", 23 },
                    { 483, "Lokoja", 23 },
                    { 414, "Ungogo", 20 },
                    { 415, "Warawa", 20 },
                    { 416, "Wudil", 20 },
                    { 417, "Bakori", 21 },
                    { 418, "Batagarawa", 21 },
                    { 419, "Batsari", 21 },
                    { 420, "Baure", 21 },
                    { 421, "Bindawa", 21 },
                    { 422, "Charanchi", 21 },
                    { 413, "Tudun Wada", 20 },
                    { 423, "Dandume", 21 },
                    { 425, "Dan Musa", 21 },
                    { 426, "Daura", 21 },
                    { 427, "Dutsi", 21 },
                    { 428, "Dutsin Ma", 21 },
                    { 429, "Faskari", 21 },
                    { 430, "Funtua", 21 },
                    { 431, "Ingawa", 21 },
                    { 432, "Jibia", 21 },
                    { 433, "Kafur", 21 },
                    { 424, "Danja", 21 },
                    { 434, "Kaita", 21 },
                    { 412, "Tsanyawa", 20 },
                    { 410, "Tarauni", 20 },
                    { 390, "Gwale", 20 },
                    { 391, "Gwarzo", 20 },
                    { 392, "Kabo", 20 },
                    { 393, "Kano Municipal", 20 },
                    { 394, "Karaye", 20 },
                    { 395, "Kibiya", 20 },
                    { 396, "Kiru", 20 },
                    { 397, "Kumbotso", 20 },
                    { 398, "Kunchi", 20 },
                    { 411, "Tofa", 20 },
                    { 399, "Kura", 20 },
                    { 401, "Makoda", 20 },
                    { 402, "Minjibir", 20 },
                    { 403, "Nasarawa", 20 },
                    { 404, "Rano", 20 },
                    { 405, "Rimin Gado", 20 },
                    { 406, "Rogo", 20 },
                    { 407, "Shanono", 20 },
                    { 408, "Sumaila", 20 },
                    { 409, "Takai", 20 },
                    { 400, "Madobi", 20 },
                    { 435, "Kankara", 21 },
                    { 436, "Kankia", 21 },
                    { 437, "Katsina", 21 },
                    { 463, "Koko Besse", 22 },
                    { 464, "Maiyama", 22 },
                    { 465, "Ngaski", 22 },
                    { 466, "Sakaba", 22 },
                    { 467, "Shanga", 22 },
                    { 468, "Suru", 22 },
                    { 469, "Wasagu Danko", 22 },
                    { 470, "Yauri", 22 },
                    { 471, "Zuru", 22 },
                    { 462, "Kalgo", 22 },
                    { 472, "Adavi", 23 },
                    { 474, "Ankpa", 23 },
                    { 475, "Bassa", 23 },
                    { 476, "Dekina", 23 },
                    { 477, "Ibaji", 23 },
                    { 478, "Idah", 23 },
                    { 479, "Igalamela Odolu", 23 },
                    { 480, "Ijumu", 23 },
                    { 481, "Kabba Bunu", 23 },
                    { 482, "Kogi", 23 },
                    { 473, "Ajaokuta", 23 },
                    { 461, "Jega", 22 },
                    { 460, "Gwandu", 22 },
                    { 459, "Fakai", 22 },
                    { 438, "Kurfi", 21 },
                    { 439, "Kusada", 21 },
                    { 440, "Mai Adua", 21 },
                    { 441, "Malumfashi", 21 },
                    { 442, "Mani", 21 },
                    { 443, "Mashi", 21 },
                    { 444, "Matazu", 21 },
                    { 445, "Musawa", 21 },
                    { 446, "Rimi", 21 },
                    { 447, "Sabuwa", 21 },
                    { 448, "Safana", 21 },
                    { 449, "Sandamu", 21 },
                    { 450, "Zango", 21 },
                    { 451, "Aleiro", 22 },
                    { 452, "Arewa Dandi", 22 },
                    { 453, "Argungu", 22 },
                    { 454, "Augie", 22 },
                    { 455, "Bagudo", 22 },
                    { 456, "Birnin Kebbi", 22 },
                    { 457, "Bunza", 22 },
                    { 458, "Dandi", 22 },
                    { 579, "Ipokia", 28 },
                    { 580, "Obafemi Owode", 28 },
                    { 581, "Odeda", 28 },
                    { 582, "Odogbolu", 28 },
                    { 704, "Omuma", 33 },
                    { 705, "Binji", 34 },
                    { 706, "Bodinga", 34 },
                    { 707, "Dange Shuni", 34 },
                    { 708, "Gada", 34 },
                    { 709, "Goronyo", 34 },
                    { 710, "Gudu", 34 },
                    { 711, "Gwadabawa", 34 },
                    { 712, "Illela", 34 },
                    { 703, "Etche", 33 },
                    { 713, "Isa", 34 },
                    { 715, "Kware", 34 },
                    { 716, "Rabah", 34 },
                    { 717, "Sabon Birni", 34 },
                    { 718, "Shagari", 34 },
                    { 719, "Silame", 34 },
                    { 720, "Sokoto North", 34 },
                    { 721, "Sokoto South", 34 },
                    { 722, "Tambuwal", 34 },
                    { 723, "Tangaza", 34 },
                    { 714, "Kebbe", 34 },
                    { 724, "Tureta", 34 },
                    { 702, "Ikwerre", 33 },
                    { 700, "Ogba–Egbema–Ndoni", 33 },
                    { 680, "Riyom", 32 },
                    { 681, "Shendam", 32 },
                    { 682, "Wase", 32 },
                    { 683, "Port Harcourt", 33 },
                    { 684, "Obio-Akpor", 33 },
                    { 685, "Okrika", 33 },
                    { 686, "Ogu–Bolo", 33 },
                    { 687, "Eleme", 33 },
                    { 688, "Tai", 33 },
                    { 701, "Emohua", 33 },
                    { 689, "Gokana", 33 },
                    { 691, "Oyigbo", 33 },
                    { 692, "Opobo–Nkoro", 33 },
                    { 693, "Andoni", 33 },
                    { 694, "Bonny", 33 },
                    { 695, "Degema", 33 },
                    { 696, "Asari-Toru", 33 },
                    { 697, "Abua–Odual", 33 },
                    { 698, "Ahoada West", 33 },
                    { 699, "Ahoada East", 33 },
                    { 690, "Khana", 33 },
                    { 725, "Wamako", 34 },
                    { 726, "Wurno", 34 },
                    { 727, "Yabo", 34 },
                    { 753, "Machina", 36 },
                    { 754, "Nangere", 36 },
                    { 755, "Wukari", 36 },
                    { 756, "Nguru", 36 },
                    { 757, "Potiskum", 36 },
                    { 758, "Tarmuwa", 36 },
                    { 759, "Yunusari", 36 },
                    { 760, "Yusufari", 36 },
                    { 761, "Anka", 37 },
                    { 752, "Karasuwa", 36 },
                    { 762, "Bakura", 37 },
                    { 764, "Bukkuyum", 37 },
                    { 765, "Bungudu", 37 },
                    { 766, "Gummi", 37 },
                    { 767, "Gusau", 37 },
                    { 768, "Kaura Namoda',", 37 },
                    { 769, "Maradun", 37 },
                    { 770, "Maru", 37 },
                    { 771, "Shinkafi", 37 },
                    { 772, "Talata Mafara", 37 },
                    { 763, "Birnin Magaji Kiyaw',", 37 },
                    { 751, "Jakusko", 36 },
                    { 750, "Gulani", 36 },
                    { 749, "Gujba", 36 },
                    { 728, "Ardo Kola", 35 },
                    { 729, "Bali", 35 },
                    { 730, "Donga", 35 },
                    { 731, "Gashaka", 35 },
                    { 732, "Gassol", 35 },
                    { 733, "Ibi", 35 },
                    { 734, "Jalingo", 35 },
                    { 735, "Karim Lamido", 35 },
                    { 736, "Kumi", 35 },
                    { 737, "Lau", 35 },
                    { 738, "Takum", 35 },
                    { 739, "Ussa", 35 },
                    { 740, "Wukari", 35 },
                    { 741, "Yorro", 35 },
                    { 742, "Zing", 35 },
                    { 743, "Bade", 36 },
                    { 744, "Bursari", 36 },
                    { 745, "Damaturu", 36 },
                    { 746, "Fika", 36 },
                    { 747, "Fune", 36 },
                    { 748, "Geidam", 36 },
                    { 679, "Qua an Pan", 32 },
                    { 389, "Gezawa", 20 },
                    { 678, "Pankshin", 32 },
                    { 676, "Mangu", 32 },
                    { 607, "Aiyedire", 30 },
                    { 608, "Boluwaduro", 30 },
                    { 609, "Boripe", 30 },
                    { 610, "Ede North", 30 },
                    { 611, "Ede South", 30 },
                    { 612, "Ife Central", 30 },
                    { 613, "Ife East", 30 },
                    { 614, "Ife North", 30 },
                    { 615, "Ife South", 30 },
                    { 606, "Aiyedaade", 30 },
                    { 616, "Egbedore", 30 },
                    { 618, "Ifedayo", 30 },
                    { 619, "Ifelodun", 30 },
                    { 620, "Ila", 30 },
                    { 621, "Ilesa East", 30 },
                    { 622, "Ilesa West", 30 },
                    { 623, "Irepodun", 30 },
                    { 624, "Irewole", 30 },
                    { 625, "Isokan", 30 },
                    { 626, "Iwo", 30 },
                    { 617, "Ejigbo", 30 },
                    { 627, "Obokun", 30 },
                    { 605, "Atakunmosa West", 30 },
                    { 603, "Owo", 29 },
                    { 583, "Ogun Waterside", 28 },
                    { 584, "Remo North", 28 },
                    { 585, "Shagamu", 28 },
                    { 586, "Akoko North-East", 29 },
                    { 587, "Akoko North-West", 29 },
                    { 588, "Akoko South-West", 29 },
                    { 589, "Akoko South-East", 29 },
                    { 590, "Akure North", 29 },
                    { 591, "Akure South", 29 },
                    { 604, "Atakunmosa East", 30 },
                    { 592, "Ese Odo", 29 },
                    { 594, "Ifedore", 29 },
                    { 595, "Ilaje", 29 },
                    { 596, "Ile Oluji-Okeigbo", 29 },
                    { 597, "Irele", 29 },
                    { 598, "Odigbo", 29 },
                    { 599, "Okitipupa", 29 },
                    { 600, "Ondo East", 29 },
                    { 601, "Ondo West", 29 },
                    { 602, "Ose", 29 },
                    { 593, "Idanre", 29 },
                    { 628, "Odo Otin", 30 },
                    { 629, "Ola Oluwa", 30 },
                    { 630, "Olorunda", 30 },
                    { 656, "Olorunsogo", 31 },
                    { 657, "Oluyole", 31 },
                    { 658, "Ona Ara", 31 },
                    { 659, "Orelope", 31 },
                    { 660, "Ori Ire", 31 },
                    { 661, "Oyo", 31 },
                    { 662, "Oyo East", 31 },
                    { 663, "Saki East", 31 },
                    { 664, "Saki West", 31 },
                    { 655, "Ogbomosho South", 31 },
                    { 665, "Surulere", 31 },
                    { 667, "Barkin Ladi", 32 },
                    { 668, "Bassa", 32 },
                    { 669, "Jos East", 32 },
                    { 670, "Jos South", 32 },
                    { 671, "Jos North", 32 },
                    { 672, "Kanam", 32 },
                    { 673, "Kanke", 32 },
                    { 674, "Langtang South", 32 },
                    { 675, "Langtang North", 32 },
                    { 666, "Bokkos", 32 },
                    { 654, "Ogbomosho North", 31 },
                    { 653, "Lagelu", 31 },
                    { 652, "Kajola", 31 },
                    { 631, "Oriade", 30 },
                    { 632, "Orolu", 30 },
                    { 633, "Osogbo", 30 },
                    { 634, "Afijio", 31 },
                    { 635, "Akinyele", 31 },
                    { 636, "Atiba", 31 },
                    { 637, "Atisbo", 31 },
                    { 638, "Egbeda", 31 },
                    { 639, "Ibadan North", 31 },
                    { 640, "Ibadan North-East", 31 },
                    { 641, "Ibadan North-West", 31 },
                    { 642, "Ibadan South-East", 31 },
                    { 643, "Ibadan South-West", 31 },
                    { 644, "Ibarapa Central", 31 },
                    { 645, "Ibarapa East", 31 },
                    { 646, "Ibarapa North", 31 },
                    { 647, "Ido", 31 },
                    { 648, "Irepo", 31 },
                    { 649, "Iseyin", 31 },
                    { 650, "Itesiwaju", 31 },
                    { 651, "Iwajowa", 31 },
                    { 677, "Mikang", 32 },
                    { 388, "Gaya", 20 },
                    { 387, "Garun Mallam", 20 },
                    { 386, "Garko", 20 },
                    { 123, "Gboko", 7 },
                    { 124, "Guma", 7 },
                    { 125, "Gwer East", 7 },
                    { 126, "Gwer West", 7 },
                    { 127, "Katsina-Ala", 7 },
                    { 128, "Konshisha", 7 },
                    { 129, "Kwande", 7 },
                    { 130, "Logo", 7 },
                    { 131, "Makurdi", 7 },
                    { 122, "Buruku", 7 },
                    { 132, "Obi", 7 },
                    { 134, "Ohimini", 7 },
                    { 135, "Oju", 7 },
                    { 136, "Okpokwu", 7 },
                    { 137, "Oturkpo", 7 },
                    { 138, "Tarka", 7 },
                    { 139, "Ukum", 7 },
                    { 140, "Ushongo", 7 },
                    { 141, "Vandeikya", 7 },
                    { 142, "Abadam", 8 },
                    { 133, "Ogbadibo", 7 },
                    { 143, "Askira-Uba", 8 },
                    { 121, "Ado", 7 },
                    { 119, "Agatu", 7 },
                    { 99, "Giade", 5 },
                    { 100, "Itas-Gadau", 5 },
                    { 101, "Jama are", 5 },
                    { 102, "Katagum", 5 },
                    { 103, "Kirfi", 5 },
                    { 104, "Misau", 5 },
                    { 105, "Ningi", 5 },
                    { 106, "Shira", 5 },
                    { 107, "Tafawa Balewa", 5 },
                    { 120, "Apa", 7 },
                    { 108, "Toro", 5 },
                    { 110, "Zaki", 5 },
                    { 111, "Brass", 6 },
                    { 112, "Ekeremor", 6 },
                    { 113, "Kolokuma Opokuma", 6 },
                    { 114, "Nembe", 6 },
                    { 115, "Ogbia", 6 },
                    { 116, "Sagbama", 6 },
                    { 117, "Southern Ijaw", 6 },
                    { 118, "Yenagoa", 6 },
                    { 109, "Warji", 5 },
                    { 144, "Bama", 8 },
                    { 145, "Bayo", 8 },
                    { 146, "Biu", 8 },
                    { 172, "Bakassi", 9 },
                    { 173, "Bekwarra", 9 },
                    { 174, "Biase", 9 },
                    { 175, "Boki", 9 },
                    { 176, "Calabar Municipal", 9 },
                    { 177, "Calabar South", 9 },
                    { 178, "Etung", 9 },
                    { 179, "Ikom", 9 },
                    { 180, "Obanliku", 9 },
                    { 171, "Akpabuyo", 9 },
                    { 181, "Obubra", 9 },
                    { 183, "Odukpani", 9 },
                    { 184, "Ogoja", 9 },
                    { 185, "Yakuur", 9 },
                    { 186, "Yala", 9 },
                    { 187, "Aniocha North", 10 },
                    { 188, "Aniocha South", 10 },
                    { 189, "Bomadi", 10 },
                    { 190, "Burutu", 10 },
                    { 191, "Ethiope East", 10 },
                    { 182, "Obudu", 9 },
                    { 170, "Akamkpa", 9 },
                    { 169, "Abi", 9 },
                    { 168, "Shani", 8 },
                    { 147, "Chibok", 8 },
                    { 148, "Damboa", 8 },
                    { 149, "Dikwa", 8 },
                    { 150, "Gubio", 8 },
                    { 151, "Guzamala", 8 },
                    { 152, "Gwoza", 8 },
                    { 153, "Hawul", 8 },
                    { 154, "Jere", 8 },
                    { 155, "Kaga", 8 },
                    { 156, "Kala-Balge", 8 },
                    { 157, "Konduga", 8 },
                    { 158, "Kukawa", 8 },
                    { 159, "Kwaya Kusar", 8 },
                    { 160, "Mafa", 8 },
                    { 161, "Magumeri", 8 },
                    { 162, "Maiduguri", 8 },
                    { 163, "Marte", 8 },
                    { 164, "Mobbar", 8 },
                    { 165, "Monguno", 8 },
                    { 166, "Ngala", 8 },
                    { 167, "Nganzai", 8 },
                    { 98, "Ganjuwa", 5 },
                    { 192, "Ethiope West", 10 },
                    { 97, "Gamawa", 5 },
                    { 95, "Darazo", 5 },
                    { 26, "Larmurde", 2 },
                    { 27, "Madagali", 2 },
                    { 28, "Maiha", 2 },
                    { 29, "Mayo Belwa", 2 },
                    { 30, "Michika", 2 },
                    { 31, "Mubi North", 2 },
                    { 32, "Mubi South", 2 },
                    { 33, "Numan", 2 },
                    { 34, "Shelleng", 2 },
                    { 25, "Jada", 2 },
                    { 35, "Song", 2 },
                    { 37, "Yola North", 2 },
                    { 38, "Yola South", 2 },
                    { 39, "Abak", 3 },
                    { 40, "Eastern Obolo", 3 },
                    { 41, "Eket", 3 },
                    { 42, "Esit Eket", 3 },
                    { 43, "Essien Udim", 3 },
                    { 44, "Etim Ekpo", 3 },
                    { 45, "Etinan", 3 },
                    { 36, "Toungo", 2 },
                    { 46, "Ibeno", 3 },
                    { 24, "Hong", 2 },
                    { 22, "Gombi", 2 },
                    { 2, "Aba South", 1 },
                    { 3, "Arochukwu", 1 },
                    { 4, "Bende", 1 },
                    { 5, "Ikwuano", 1 },
                    { 6, "Isiala Ngwa North", 1 },
                    { 7, "Isiala Ngwa South", 1 },
                    { 8, "Isuikwuato", 1 },
                    { 9, "Obi Ngwa", 1 },
                    { 10, "Ohafia", 1 },
                    { 23, "Grie", 2 },
                    { 11, "Osisioma", 1 },
                    { 13, "Ukwa East", 1 },
                    { 14, "Ukwa West", 1 },
                    { 15, "Umuahia North", 1 },
                    { 16, "Umuahia South", 1 },
                    { 17, "Umu Nneochi", 1 },
                    { 18, "Demsa", 2 },
                    { 19, "Fufure", 2 },
                    { 20, "Ganye", 2 },
                    { 21, "Gayuk", 2 },
                    { 12, "Ugwunagbo", 1 },
                    { 47, "Ibesikpo Asutan", 3 },
                    { 48, "Ibiono-Ibom", 3 },
                    { 49, "Ika", 3 },
                    { 75, "Awka South", 4 },
                    { 76, "Ayamelum", 4 },
                    { 77, "Dunukofia", 4 },
                    { 78, "Ekwusigo", 4 },
                    { 79, "Idemili North", 4 },
                    { 80, "Idemili South", 4 },
                    { 81, "Ihiala", 4 },
                    { 82, "Njikoka", 4 },
                    { 83, "Nnewi North", 4 },
                    { 74, "Awka North", 4 },
                    { 84, "Nnewi South", 4 },
                    { 86, "Onitsha North", 4 },
                    { 87, "Onitsha South", 4 },
                    { 88, "Orumba North", 4 },
                    { 89, "Orumba South", 4 },
                    { 90, "Oyi", 4 },
                    { 91, "Alkaleri", 5 },
                    { 92, "Bauchi", 5 },
                    { 93, "Bogoro", 5 },
                    { 94, "Damban", 5 },
                    { 85, "Ogbaru", 4 },
                    { 73, "Anaocha", 4 },
                    { 72, "Anambra West", 4 },
                    { 71, "Anambra East", 4 },
                    { 50, "Ikono", 3 },
                    { 51, "Ikot Abasi", 3 },
                    { 52, "Ikot Ekpene", 3 },
                    { 53, "Ini", 3 },
                    { 54, "Itu", 3 },
                    { 55, "Mbo", 3 },
                    { 56, "Mkpat-Enin", 3 },
                    { 57, "Nsit-Atai", 3 },
                    { 58, "Nsit-Ibom", 3 },
                    { 59, "Nsit-Ubium", 3 },
                    { 60, "Obot Akara", 3 },
                    { 61, "Okobo", 3 },
                    { 62, "Onna", 3 },
                    { 63, "Oron", 3 },
                    { 64, "Oruk Anam", 3 },
                    { 65, "Udung-Uko", 3 },
                    { 66, "Ukanafun", 3 },
                    { 67, "Uruan", 3 },
                    { 68, "Urue-Offong Oruko", 3 },
                    { 69, "Uyo", 3 },
                    { 70, "Aguata", 4 },
                    { 96, "Dass", 5 },
                    { 773, "Chafe", 37 },
                    { 193, "Ika North East", 10 },
                    { 195, "Isoko North", 10 },
                    { 317, "Oru East", 17 },
                    { 318, "Oru West", 17 },
                    { 319, "Owerri Municipal", 17 },
                    { 320, "Owerri North", 17 },
                    { 321, "Owerri West", 17 },
                    { 322, "Unuimo", 17 },
                    { 323, "Auyo", 18 },
                    { 324, "Babura", 18 },
                    { 325, "Biriniwa", 18 },
                    { 316, "Orsu", 17 },
                    { 326, "Birnin Kudu", 18 },
                    { 328, "Dutse", 18 },
                    { 329, "Gagarawa", 18 },
                    { 330, "Garki", 18 },
                    { 331, "Gumel", 18 },
                    { 332, "Guri", 18 },
                    { 333, "Gwaram", 18 },
                    { 334, "Gwiwa", 18 },
                    { 335, "Hadejia", 18 },
                    { 336, "Jahun", 18 },
                    { 327, "Buji", 18 },
                    { 337, "Kafin Hausa", 18 },
                    { 315, "Orlu", 17 },
                    { 313, "Ohaji-Egbema", 17 },
                    { 293, "Shongom", 16 },
                    { 294, "Yamaltu", 16 },
                    { 295, "Deba", 16 },
                    { 296, "Aboh Mbaise", 17 },
                    { 297, "Ahiazu Mbaise", 17 },
                    { 298, "Ehime Mbano", 17 },
                    { 299, "Ezinihitte", 17 },
                    { 300, "Ideato North", 17 },
                    { 301, "Ideato South", 17 },
                    { 314, "Okigwe", 17 },
                    { 302, "Ihitte-Uboma", 17 },
                    { 304, "Isiala Mbano", 17 },
                    { 305, "Isu", 17 },
                    { 306, "Mbaitoli", 17 },
                    { 307, "Ngor Okpala", 17 },
                    { 308, "Njaba", 17 },
                    { 309, "Nkwerre", 17 },
                    { 310, "Nwangele", 17 },
                    { 311, "Obowo", 17 },
                    { 312, "Oguta", 17 },
                    { 303, "Ikeduru", 17 },
                    { 338, "Kazaure", 18 },
                    { 339, "Kiri Kasama", 18 },
                    { 340, "Kiyawa", 18 },
                    { 366, "Lere", 19 },
                    { 367, "Makarfi", 19 },
                    { 368, "Sabon Gari", 19 },
                    { 369, "Sanga", 19 },
                    { 370, "Soba", 19 },
                    { 371, "Zangon Kataf", 19 },
                    { 372, "Zaria", 19 },
                    { 373, "Ajingi", 20 },
                    { 374, "Albasu", 20 },
                    { 365, "Kudan", 19 },
                    { 375, "Bagwai", 20 },
                    { 377, "Bichi", 20 },
                    { 378, "Bunkure", 20 },
                    { 379, "Dala", 20 },
                    { 380, "Dambatta", 20 },
                    { 381, "Dawakin Kudu", 20 },
                    { 382, "Dawakin Tofa", 20 },
                    { 383, "Doguwa", 20 },
                    { 384, "Fagge", 20 },
                    { 385, "Gabasawa", 20 },
                    { 376, "Bebeji", 20 },
                    { 364, "Kubau", 19 },
                    { 363, "Kauru", 19 },
                    { 362, "Kaura", 19 },
                    { 341, "Kaugama", 18 },
                    { 342, "Maigatari", 18 },
                    { 343, "Malam Madori", 18 },
                    { 344, "Miga", 18 },
                    { 345, "Ringim", 18 },
                    { 346, "Roni", 18 },
                    { 347, "Sule Tankarkar", 18 },
                    { 348, "Taura", 18 },
                    { 349, "Yankwashi", 18 },
                    { 350, "Birnin Gwari", 19 },
                    { 351, "Chikun", 19 },
                    { 352, "Giwa", 19 },
                    { 353, "Igabi", 19 },
                    { 354, "Ikara", 19 },
                    { 355, "Jaba", 19 },
                    { 356, "Jema a", 19 },
                    { 357, "Kachia", 19 },
                    { 358, "Kaduna North", 19 },
                    { 359, "Kaduna South", 19 },
                    { 360, "Kagarko", 19 },
                    { 361, "Kajuru", 19 },
                    { 292, "Nafada", 16 },
                    { 194, "Ika South", 10 },
                    { 291, "Kwami", 16 },
                    { 289, "Gombe", 16 },
                    { 220, "Calabar South", 11 },
                    { 221, "Ivo", 11 },
                    { 222, "Izzi", 11 },
                    { 223, "Ohaozara", 11 },
                    { 224, "Ohaukwu", 11 },
                    { 225, "Onicha", 11 },
                    { 226, "Akoko-Edo", 12 },
                    { 227, "Egor", 12 },
                    { 228, "Esan Central", 12 },
                    { 219, "Ishielu", 11 },
                    { 229, "Esan North-East", 12 },
                    { 231, "Esan West", 12 },
                    { 232, "Etsako Central", 12 },
                    { 233, "Etsako East", 12 },
                    { 234, "Etsako West", 12 },
                    { 235, "Igueben", 12 },
                    { 236, "Ikpoba Okha", 12 },
                    { 237, "Orhionmwon", 12 },
                    { 238, "Oredo", 12 },
                    { 239, "Ovia North-East", 12 }
                });

            migrationBuilder.InsertData(
                table: "LocalGovernments",
                columns: new[] { "LocalGovernmentId", "LocalGovernmentName", "StateId" },
                values: new object[,]
                {
                    { 230, "Esan South-East", 12 },
                    { 240, "Ovia South-West", 12 },
                    { 218, "Ikwo", 11 },
                    { 216, "Ezza North", 11 },
                    { 196, "Isoko South", 10 },
                    { 197, "Ndokwa East", 10 },
                    { 198, "Ndokwa West", 10 },
                    { 199, "Okpe", 10 },
                    { 200, "Oshimili North", 10 },
                    { 201, "Oshimili South", 10 },
                    { 202, "Patani", 10 },
                    { 203, "Sapele", 10 },
                    { 204, "Udu", 10 },
                    { 217, "Ezza South", 11 },
                    { 205, "Ughelli North", 10 },
                    { 207, "Ukwuani", 10 },
                    { 208, "Uvwie", 10 },
                    { 209, "Warri North", 10 },
                    { 210, "Warri South", 10 },
                    { 211, "Warri South West", 10 },
                    { 212, "Abakaliki", 11 },
                    { 213, "Afikpo North", 11 },
                    { 214, "Afikpo South", 11 },
                    { 215, "Ebonyi", 11 },
                    { 206, "Ughelli South", 10 },
                    { 241, "Owan East", 12 },
                    { 242, "Owan East", 12 },
                    { 243, "Uhunmwonde", 12 },
                    { 269, "Igbo Eze South", 14 },
                    { 270, "Isi Uzo", 14 },
                    { 271, "Nkanu East", 14 },
                    { 272, "Nkanu West", 14 },
                    { 273, "Nsukka", 14 },
                    { 274, "Oji River", 14 },
                    { 275, "Udenu", 14 },
                    { 276, "Udi", 14 },
                    { 277, "Uzo Uwani", 14 },
                    { 268, "Igbo Eze North", 14 },
                    { 278, "Abaji", 15 },
                    { 280, "Gwagwalada", 15 },
                    { 281, "Kuje", 15 },
                    { 282, "Kwali", 15 },
                    { 283, "Municipal Area Council", 15 },
                    { 284, "Akko", 16 },
                    { 285, "Balanga", 16 },
                    { 286, "Billiri", 16 },
                    { 287, "Dukku", 16 },
                    { 288, "Funakaye", 16 },
                    { 279, "Bwari", 15 },
                    { 267, "Igbo Etiti", 14 },
                    { 266, "Ezeagu", 14 },
                    { 265, "Enugu South", 14 },
                    { 244, "Ado Ekiti", 13 },
                    { 245, "Efon", 13 },
                    { 246, "Ekiti East", 13 },
                    { 247, "Ekiti South-West", 13 },
                    { 248, "Esan South-East", 13 },
                    { 249, "Ekiti West", 13 },
                    { 250, "Emure", 13 },
                    { 251, "Gbonyin", 13 },
                    { 252, "Ido Osi", 13 },
                    { 253, "Ijero", 13 },
                    { 254, "Ikere", 13 },
                    { 255, "Ikole", 13 },
                    { 256, "Ilejemeje", 13 },
                    { 257, "Irepodun-Ifelodun", 13 },
                    { 258, "Ise-Orun", 13 },
                    { 259, "Moba", 13 },
                    { 260, "Oye", 13 },
                    { 261, "Aninri", 14 },
                    { 262, "Awgu", 14 },
                    { 263, "Enugu East", 14 },
                    { 264, "Enugu North", 14 },
                    { 290, "Kaltungo", 16 },
                    { 774, "Zurmi", 37 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_LocalGovernments_StateId",
                table: "LocalGovernments",
                column: "StateId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LocalGovernments");

            migrationBuilder.DropTable(
                name: "AdmStates");
        }
    }
}
