#define GitHub_Markus_Drache_Creator

using Microsoft.VisualBasic.Devices;
using System;
using System.Drawing;
using System.IO;
using System.Numerics;
using System.Reflection;
using System.Reflection.Emit;
using System.Reflection.PortableExecutable;
using System.Runtime.ConstrainedExecution;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static System.Windows.Forms.LinkLabel;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;


namespace Kostenaufstellung
{
    public partial class Form1 : Form
    {
        bool O_one_T = false, Stromberechnung_off = false;
        const string s_Schrott = "Schrott", s_Schlacke = "Schlacke", s_Wasser = "Wasser", s_Kryoflüssigkeit = "Kryoflüssigkeit", s_Öl = "Öl",
                     s_Kupfer = "Kupfer", s_Blei = "Blei", s_Kohle = "Kohle", s_Titan = "Titan", s_Thorium = "Thorium",
                     s_SporenPod = "Sporen - Pod", s_Metaglas = "Metaglas", s_Grafit = "Grafit", s_Silizium = "Silizium", s_Pyratit = "Pyratit",
                     s_ExplosiveMischung = "Explosive - Mischung", s_Plastanium = "Plastanium", s_Phasengewebe = "Phasengewebe",
                     s_Spannungslegierung = "Spannungslegierung", s_Keine_Kühlung = "Keine Kühlung", s_Keine_Versterkung = "Keine Verstärkung";
        string Error_s = "";

        uint R_count = 0, B_count = 0, P_count = 1, G_count = 0;

        public Form1()
        {
            InitializeComponent();

            Switch_Awelebles();
            Switch_Awelebles();
        }

        void Reset_All()
        {
            //Inizialisierung = 0
            {
                //Rohstoffe
                Schrott_Wunsch.Value = 0;
                Kupfer_Wunsch.Value = 0;
                Blei_Wunsch.Value = 0;
                Sand_Wunsch.Value = 0;
                Kohle_Wunsch.Value = 0;
                Titan_Wunsch.Value = 0;
                Thorium_Wunsch.Value = 0;

                //Flüssigkeiten
                Schlacke_Wunsch.Value = 0;
                Wasser_Wunsch.Value = 0;
                Kryoflüssigkeit_Wunsch.Value = 0;
                Öl_Wunsch.Value = 0;

                //secundär Rohstoffe
                WasserExtractor_Zu.Value = 0;
                Kultivierer_Zu.Value = 0;
                ÖlExtractor_Zu.Value = 0;
                Sporenpresse_Zu.Value = 0;
                Pulverisierer_Zu.Value = 0;
                Kohlenzentriefuge_Zu.Value = 0;
                Kryoflüssigkeitsmixer_Zu.Value = 0;
                Schmelzer_Zu.Value = 0;
                Trenner_Zu.Value = 0;
                GroßerTrenner_Zu.Value = 0;

                //Fabriken
                GrafitPresse_Zu.Value = 0;
                MultiPresse_Zu.Value = 0;
                SiliziumSchmelzer_Zu.Value = 0;
                SiliziumSchmelztiegel_Zu.Value = 0;
                Brennofen_Zu.Value = 0;
                PlastaniumVerdichter_Zu.Value = 0;
                Phasenweber_Zu.Value = 0;
                Legierungsschmelze_Zu.Value = 0;
                PyratitMixer_Zu.Value = 0;
                Sprengmixer_Zu.Value = 0;

                //Produkte
                SporenPod_Wunsch.Value = 0;
                Metaglas_Wunsch.Value = 0;
                Grafit_Wunsch.Value = 0;
                Silizium_Wunsch.Value = 0;
                Pyratit_Wunsch.Value = 0;
                ExplosiveMischung_Wunsch.Value = 0;
                Plastanium_Wunsch.Value = 0;
                Phasengewebe_Wunsch.Value = 0;
                Spannungslegierung_Wunsch.Value = 0;
                Strom_Wunsch.Value = 0;

                //Bohrer
                Kupfer_MBohrer_OW_Zu.Value = 0; Kupfer_MBohrer_MW_Zu.Value = 0;
                Blei_MBohrer_OW_Zu.Value = 0; Blei_MBohrer_MW_Zu.Value = 0;
                Sand_MBohrer_OW_Zu.Value = 0; Sand_MBohrer_MW_Zu.Value = 0;
                Kohle_MBohrer_OW_Zu.Value = 0; Kohle_MBohrer_MW_Zu.Value = 0;
                Schrott_MBohrer_OW_Zu.Value = 0; Schrott_MBohrer_MW_Zu.Value = 0;
                Kupfer_PBohrer_OW_Zu.Value = 0; Kupfer_PBohrer_MW_Zu.Value = 0;
                Blei_PBohrer_OW_Zu.Value = 0; Blei_PBohrer_MW_Zu.Value = 0;
                Sand_PBohrer_OW_Zu.Value = 0; Sand_PBohrer_MW_Zu.Value = 0;
                Kohle_PBohrer_OW_Zu.Value = 0; Kohle_PBohrer_MW_Zu.Value = 0;
                Titan_PBohrer_OW_Zu.Value = 0; Titan_PBohrer_MW_Zu.Value = 0;
                Schrott_PBohrer_OW_Zu.Value = 0; Schrott_PBohrer_MW_Zu.Value = 0;
                Kupfer_LBohrer_OW_Zu.Value = 0; Kupfer_LBohrer_MW_Zu.Value = 0;
                Blei_LBohrer_OW_Zu.Value = 0; Blei_LBohrer_MW_Zu.Value = 0;
                Sand_LBohrer_OW_Zu.Value = 0; Sand_LBohrer_MW_Zu.Value = 0;
                Kohle_LBohrer_OW_Zu.Value = 0; Kohle_LBohrer_MW_Zu.Value = 0;
                Titan_LBohrer_OW_Zu.Value = 0; Titan_LBohrer_MW_Zu.Value = 0;
                Thorium_LBohrer_OW_Zu.Value = 0; Thorium_LBohrer_MW_Zu.Value = 0;
                Schrott_LBohrer_OW_Zu.Value = 0; Schrott_LBohrer_MW_Zu.Value = 0;
                Kupfer_SBohrer_OW_Zu.Value = 0; Kupfer_SBohrer_MW_Zu.Value = 0;
                Blei_SBohrer_OW_Zu.Value = 0; Blei_SBohrer_MW_Zu.Value = 0;
                Sand_SBohrer_OW_Zu.Value = 0; Sand_SBohrer_MW_Zu.Value = 0;
                Kohle_SBohrer_OW_Zu.Value = 0; Kohle_SBohrer_MW_Zu.Value = 0;
                Titan_SBohrer_OW_Zu.Value = 0; Titan_SBohrer_MW_Zu.Value = 0;
                Thorium_SBohrer_OW_Zu.Value = 0; Thorium_SBohrer_MW_Zu.Value = 0;
                Schrott_SBohrer_OW_Zu.Value = 0; Schrott_SBohrer_MW_Zu.Value = 0;

                Wasser_MP_Zu.Value = 0;
                Kryoflüssigkeit_MP_Zu.Value = 0;
                Öl_MP_Zu.Value = 0;
                Schlacke_MP_Zu.Value = 0;
                Wasser_RP_Zu.Value = 0;
                Kryoflüssigkeit_RP_Zu.Value = 0;
                Öl_RP_Zu.Value = 0;
                Schlacke_RP_Zu.Value = 0;
                Wasser_TP_Zu.Value = 0;
                Kryoflüssigkeit_TP_Zu.Value = 0;
                Öl_TP_Zu.Value = 0;
                Schlacke_TP_Zu.Value = 0;

                //Generatoren
                Verbrennungsgenerator_Zu.Value = 0;
                ThermischerGenerator_Zu.Value = 0;
                Turbinengenerator_Zu.Value = 0;
                Differenzialgenerator_Zu.Value = 0;
                RTGGenerator_Zu.Value = 0;
                Solarpanel_Zu.Value = 0;
                GroßesSolarpanel_Zu.Value = 0;
                ThoriumReaktor_Zu.Value = 0;
                Schlaggenerator_Zu.Value = 0;

                //Mauern
                Kupfermauer_Zu.Value = 0;
                GroßeKupfermauer_Zu.Value = 0;
                Titanmauer_Zu.Value = 0;
                GroßeTitanmauer_Zu.Value = 0;
                Thoriummauer_Zu.Value = 0;
                GroßeThoriummauer_Zu.Value = 0;
                Phasenmauer_Zu.Value = 0;
                GroßePhasenmauer_Zu.Value = 0;
                Spannungsmauer_Zu.Value = 0;
                GroßeSpannungsmauer_Zu.Value = 0;
                Plastaniummauer_Zu.Value = 0;
                GroßePlastaniummauer_Zu.Value = 0;
                Tor_Zu.Value = 0;
                GroßesTor_Zu.Value = 0;

                //Schutzeinrichtungen
                Batterie_Zu.Value = 0;
                GroßeBatterie_Zu.Value = 0;
                Behälter_Zu.Value = 0;
                Tresor_Zu.Value = 0;
                Reparateur_Zu.Value = 0;
                Reparaturprojektor_Zu.Value = 0;
                BeschleunigungsProjektor_Zu.Value = 0;
                BeschleunigungsMaschine_Zu.Value = 0;
                KraftfeldProjektor_Zu.Value = 0;
                SchockMine_Zu.Value = 0;
                Reparaturpunkt_Zu.Value = 0;
                Reparaturstation_Zu.Value = 0;

                //Geschütze
                Doppelgeschütz_Zu.Value = 0;
                Luftgeschütz_Zu.Value = 0;
                Scatter_Zu.Value = 0;
                Hail_Zu.Value = 0;
                Welle_Zu.Value = 0;
                Lancer_Zu.Value = 0;
                Arcus_Zu.Value = 0;
                Parallax_Zu.Value = 0;
                Schwärmer_Zu.Value = 0;
                Salve_Zu.Value = 0;
                Segment_Zu.Value = 0;
                Tsunami_Zu.Value = 0;
                Zünder_Zu.Value = 0;
                Zerstörer_Zu.Value = 0;
                Zyklon_Zu.Value = 0;
                Foreshadow_Zu.Value = 0;
                Phantom_Zu.Value = 0;
                Meltdown_Zu.Value = 0;

                //Truppen Produktion
                Bodenfabrik_Zu.Value = 0;
                Luftfabrik_Zu.Value = 0;
                Wasserfabrik_Zu.Value = 0;
                HinzufügenderRekonstrukeur_Zu.Value = 0;
                MultiplikativerRekonstrukeur_Zu.Value = 0;
                ExponenziellerRekonstrukeur_Zu.Value = 0;
                TretrativerRekonstrukeur_Zu.Value = 0;

                //Truppen Land
                Dagger_Zu.Value = 0;
                Mace_Zu.Value = 0;
                Fortress_Zu.Value = 0;
                Scepter_Zu.Value = 0;
                Reign_Zu.Value = 0;

                Nova_Zu.Value = 0;
                Pulsar_Zu.Value = 0;
                Quasar_Zu.Value = 0;
                Vela_Zu.Value = 0;
                Korvus_Zu.Value = 0;

                Crawler_Zu.Value = 0;
                Atrax_Zu.Value = 0;
                Spirokt_Zu.Value = 0;
                Arkyid_Zu.Value = 0;
                Toxopid_Zu.Value = 0;

                //Truppen Wasser
                Risso_Zu.Value = 0;
                Minke_Zu.Value = 0;
                Bryde_Zu.Value = 0;
                Sei_Zu.Value = 0;
                Omura_Zu.Value = 0;

                Retusa_Zu.Value = 0;
                Oxynoe_Zu.Value = 0;
                Cyerce_Zu.Value = 0;
                Aegires_Zu.Value = 0;
                Navanax_Zu.Value = 0;

                //Truppen Luft
                Flare_Zu.Value = 0;
                Horizont_Zu.Value = 0;
                Zenit_Zu.Value = 0;
                Antumbra_Zu.Value = 0;
                Eclipse_Zu.Value = 0;

                Mono_Zu.Value = 0;
                Poly_Zu.Value = 0;
                Mega_Zu.Value = 0;
                Quad_Zu.Value = 0;
                Okt_Zu.Value = 0;
            }
            //Set all Text-Values = 0
            {
                //final Truppen Resurses
                Bodenfabrik_Be.Text = "0";
                Wasserfabrik_Be.Text = "0";
                Luftfabrik_Be.Text = "0";
                HinzufügenderRekonstrukeur_Be.Text = "0";
                MultiplikativerRekonstrukeur_Be.Text = "0";
                ExponenziellerRekonstrukeur_Be.Text = "0";
                TretrativerRekonstrukeur_Be.Text = "0";

                //final Rohstoff Resurses
                //Reale Kernzufur
                Kupfer_Real.Text = "0";
                Schrott_Real.Text = "0";
                Blei_Real.Text = "0";
                Sand_Real.Text = "0";
                Kohle_Real.Text = "0";
                Titan_Real.Text = "0";
                Thorium_Real.Text = "0";
                //Produktionkosten
                Kupfer_Produktionskosten.Text = "0";
                Schrott_Produktionskosten.Text = "0";
                Blei_Produktionskosten.Text = "0";
                Sand_Produktionskosten.Text = "0";
                Kohle_Produktionskosten.Text = "0";
                Titan_Produktionskosten.Text = "0";
                Thorium_Produktionskosten.Text = "0";
                //Erzeugung
                Kupfer_Erzeugung.Text = "0";
                Schrott_Erzeugung.Text = "0";
                Blei_Erzeugung.Text = "0";
                Sand_Erzeugung.Text = "0";
                Kohle_Erzeugung.Text = "0";
                Titan_Erzeugung.Text = "0";
                Thorium_Erzeugung.Text = "0";
                //Baukosten
                Kupfer_Baukosten.Text = "0";
                Schrott_Baukosten.Text = "0";
                Blei_Baukosten.Text = "0";
                Sand_Baukosten.Text = "0";
                Kohle_Baukosten.Text = "0";
                Titan_Baukosten.Text = "0";
                Thorium_Baukosten.Text = "0";
                //Flüssigkeiten
                //Reale Kernzufur
                Schlacke_Real.Text = "0";
                Wasser_Real.Text = "0";
                Kryoflüssigkeit_Real.Text = "0";
                Öl_Real.Text = "0";
                //Produktionkosten
                Schlacke_Produktionskosten.Text = "0";
                Wasser_Produktionskosten.Text = "0";
                Kryoflüssigkeit_Produktionskosten.Text = "0";
                Öl_Produktionskosten.Text = "0";
                //Erzeugung
                Schlacke_Erzeugung.Text = "0";
                Wasser_Erzeugung.Text = "0";
                Kryoflüssigkeit_Erzeugung.Text = "0";
                Öl_Erzeugung.Text = "0";
                //Baukosten
                Schlacke_Baukosten.Text = "0";
                Wasser_Baukosten.Text = "0";
                Kryoflüssigkeit_Baukosten.Text = "0";
                Öl_Baukosten.Text = "0";

                //Produkte
                //Reale Kernzufur
                SporenPod_Real.Text = "0";
                Metaglas_Real.Text = "0";
                Grafit_Real.Text = "0";
                Silizium_Real.Text = "0";
                Pyratit_Real.Text = "0";
                ExplosiveMischung_Real.Text = "0";
                Plastanium_Real.Text = "0";
                Phasengewebe_Real.Text = "0";
                Spannungslegierung_Real.Text = "0";
                Strom_Real.Text = "0";
                //Produktionkosten
                SporenPod_Produktionskosten.Text = "0";
                Metaglas_Produktionskosten.Text = "0";
                Grafit_Produktionskosten.Text = "0";
                Silizium_Produktionskosten.Text = "0";
                Pyratit_Produktionskosten.Text = "0";
                ExplosiveMischung_Produktionskosten.Text = "0";
                Plastanium_Produktionskosten.Text = "0";
                Phasengewebe_Produktionskosten.Text = "0";
                Spannungslegierung_Produktionskosten.Text = "0";
                Strom_Produktionskosten.Text = "0";
                //Erzeugung
                SporenPod_Erzeugung.Text = "0";
                Metaglas_Erzeugung.Text = "0";
                Grafit_Erzeugung.Text = "0";
                Silizium_Erzeugung.Text = "0";
                Pyratit_Erzeugung.Text = "0";
                ExplosiveMischung_Erzeugung.Text = "0";
                Plastanium_Erzeugung.Text = "0";
                Phasengewebe_Erzeugung.Text = "0";
                Spannungslegierung_Erzeugung.Text = "0";
                Strom_Erzeugung.Text = "0";
                //Baukosten
                SporenPod_Baukosten.Text = "0";
                Metaglas_Baukosten.Text = "0";
                Grafit_Baukosten.Text = "0";
                Silizium_Baukosten.Text = "0";
                Pyratit_Baukosten.Text = "0";
                ExplosiveMischung_Baukosten.Text = "0";
                Plastanium_Baukosten.Text = "0";
                Phasengewebe_Baukosten.Text = "0";
                Spannungslegierung_Baukosten.Text = "0";
                Strom_Baukosten.Text = "0";

                //Fabriken
                GrafitPresse_Be.Text = "0";
                MultiPresse_Be.Text = "0";
                SiliziumSchmelzer_Be.Text = "0";
                SiliziumSchmelztiegel_Be.Text = "0";
                Brennofen_Be.Text = "0";
                PlastaniumVerdichter_Be.Text = "0";
                Phasenweber_Be.Text = "0";
                Legierungsschmelze_Be.Text = "0";
                PyratitMixer_Be.Text = "0";
                Sprengmixer_Be.Text = "0";

                //Generatoren
                Verbrennungsgenerator_Be.Text = "0";
                ThermischerGenerator_Be.Text = "0";
                Turbinengenerator_Be.Text = "0";
                Differenzialgenerator_Be.Text = "0";
                RTGGenerator_Be.Text = "0";
                Solarpanel_Be.Text = "0";
                GroßesSolarpanel_Be.Text = "0";
                ThoriumReaktor_Be.Text = "0";
                Schlaggenerator_Be.Text = "0";

                //Bohrer
                Kupfer_MBohrer_OW_Be.Text = "0"; Kupfer_MBohrer_MW_Be.Text = "0";
                Blei_MBohrer_OW_Be.Text = "0"; Blei_MBohrer_MW_Be.Text = "0";
                Sand_MBohrer_OW_Be.Text = "0"; Sand_MBohrer_MW_Be.Text = "0";
                Kohle_MBohrer_OW_Be.Text = "0"; Kohle_MBohrer_MW_Be.Text = "0";
                Schrott_MBohrer_OW_Be.Text = "0"; Schrott_MBohrer_MW_Be.Text = "0";
                Kupfer_PBohrer_OW_Be.Text = "0"; Kupfer_PBohrer_MW_Be.Text = "0";
                Blei_PBohrer_OW_Be.Text = "0"; Blei_PBohrer_MW_Be.Text = "0";
                Sand_PBohrer_OW_Be.Text = "0"; Sand_PBohrer_MW_Be.Text = "0";
                Kohle_PBohrer_OW_Be.Text = "0"; Kohle_PBohrer_MW_Be.Text = "0";
                Titan_PBohrer_OW_Be.Text = "0"; Titan_PBohrer_MW_Be.Text = "0";
                Schrott_PBohrer_OW_Be.Text = "0"; Schrott_PBohrer_MW_Be.Text = "0";
                Kupfer_LBohrer_OW_Be.Text = "0"; Kupfer_LBohrer_MW_Be.Text = "0";
                Blei_LBohrer_OW_Be.Text = "0"; Blei_LBohrer_MW_Be.Text = "0";
                Sand_LBohrer_OW_Be.Text = "0"; Sand_LBohrer_MW_Be.Text = "0";
                Kohle_LBohrer_OW_Be.Text = "0"; Kohle_LBohrer_MW_Be.Text = "0";
                Titan_LBohrer_OW_Be.Text = "0"; Titan_LBohrer_MW_Be.Text = "0";
                Thorium_LBohrer_OW_Be.Text = "0"; Thorium_LBohrer_MW_Be.Text = "0";
                Schrott_LBohrer_OW_Be.Text = "0"; Schrott_LBohrer_MW_Be.Text = "0";
                Kupfer_SBohrer_OW_Be.Text = "0"; Kupfer_SBohrer_MW_Be.Text = "0";
                Blei_SBohrer_OW_Be.Text = "0"; Blei_SBohrer_MW_Be.Text = "0";
                Sand_SBohrer_OW_Be.Text = "0"; Sand_SBohrer_MW_Be.Text = "0";
                Kohle_SBohrer_OW_Be.Text = "0"; Kohle_SBohrer_MW_Be.Text = "0";
                Titan_SBohrer_OW_Be.Text = "0"; Titan_SBohrer_MW_Be.Text = "0";
                Thorium_SBohrer_OW_Be.Text = "0"; Thorium_SBohrer_MW_Be.Text = "0";
                Schrott_SBohrer_OW_Be.Text = "0"; Schrott_SBohrer_MW_Be.Text = "0";

                //Pumpe
                Wasser_MP_Be.Text = "0";
                Kryoflüssigkeit_MP_Be.Text = "0";
                Öl_MP_Be.Text = "0";
                Schlacke_MP_Be.Text = "0";
                Wasser_RP_Be.Text = "0";
                Kryoflüssigkeit_RP_Be.Text = "0";
                Öl_RP_Be.Text = "0";
                Schlacke_RP_Be.Text = "0";
                Wasser_TP_Be.Text = "0";
                Kryoflüssigkeit_TP_Be.Text = "0";
                Öl_TP_Be.Text = "0";
                Schlacke_TP_Be.Text = "0";

                //secundär Rohstoffe
                WasserExtractor_Be.Text = "0";
                Kultivierer_Be.Text = "0";
                ÖlExtractor_Be.Text = "0";
                Sporenpresse_Be.Text = "0";
                Pulverisierer_Be.Text = "0";
                Kohlenzentriefuge_Be.Text = "0";
                Kryoflüssigkeitsmixer_Be.Text = "0";
                Schmelzer_Be.Text = "0";
                Trenner_Be.Text = "0";
                GroßerTrenner_Be.Text = "0";

            }
        }

        //Funktion für die inizialisation Herstellbaren/abbaubaren Materialien
        void Switch_Awelebles()
        {
            bool Schrott, Schlacke, Wasser, Kryoflüssigkeit, Öl,
                Kupfer, Blei, Sand, Kohle, Titan, Thorium,
                SporenPod, Metaglas, Grafit, Silizium, Pyratit, ExplosiveMischung, Plastanium, Phasengewebe,
                Spannungslegierung, Strom = !Strom_Wunsch.ReadOnly;

            // Schrott = Schlacke = Wasser = Kryoflüssigkeit = Öl =
            //     Kupfer = Blei = Sand = Kohle = Titan = Thorium =
            //     SporenPod = Metaglas = Grafit = Silizium = Pyratit = ExplosiveMischung = Plastanium = Phasengewebe =
            //     Spannungslegierung = false;

            //Rohstoff Verfügbarkeit
            {
                //Schrott
                if (Schrott_aweleble.Checked)
                {
                    Schrott_Wunsch.ReadOnly = false;
                    Schrott_Wunsch.Enabled = true;
                    Schrott = true;
                }
                else
                {
                    Schrott_Wunsch.Value = 0;
                    Schrott_Wunsch.ReadOnly = true;
                    Schrott_Wunsch.Enabled = false;
                    Schrott = false;
                }

                //Schlacke
                if (Schlacke_aweleble.Checked || Schrott_aweleble.Checked)
                {
                    Schlacke_Wunsch.ReadOnly = false;
                    Schlacke_Wunsch.Enabled = true;
                    Schlacke = true;
                }
                else
                {
                    Schlacke_Wunsch.Value = 0;
                    Schlacke_Wunsch.ReadOnly = true;
                    Schlacke_Wunsch.Enabled = false;
                    Schlacke = false;
                }

                //Wasser
                if (Wasser_aweleble.Checked || Strom)
                {
                    Wasser_Wunsch.ReadOnly = false;
                    Wasser_Wunsch.Enabled = true;
                    Wasser = true;

                    if (Wasser_aweleble.Checked)
                    {
                        //MPumpe_Div.Value = 0;
                        //MPumpe_Div.ReadOnly = false;
                        //MPumpe_Div.Enabled = true;
                        //
                        //RPumpe_Div.Value = 0;
                        //RPumpe_Div.ReadOnly = false;
                        //RPumpe_Div.Enabled = true;
                        //
                        //TPumpe_Div.Value = 100;
                        //TPumpe_Div.ReadOnly = false;
                        //TPumpe_Div.Enabled = true;

                        Wasser_Extraktor_Div.Value = 0;
                        Wasser_Extraktor_Div.ReadOnly = false;
                        Wasser_Extraktor_Div.Enabled = true;
                    }
                    else
                    {
                        //MPumpe_Div.Value = 0;
                        //MPumpe_Div.ReadOnly = true;
                        //MPumpe_Div.Enabled = false;
                        //
                        //RPumpe_Div.Value = 0;
                        //RPumpe_Div.ReadOnly = true;
                        //RPumpe_Div.Enabled = false;
                        //
                        //TPumpe_Div.Value = 0;
                        //TPumpe_Div.ReadOnly = true;
                        //TPumpe_Div.Enabled = false;

                        Wasser_Extraktor_Div.Value = 0;
                        Wasser_Extraktor_Div.ReadOnly = true;
                        Wasser_Extraktor_Div.Enabled = false;
                    }



                }
                else
                {
                    Wasser_Wunsch.Value = 0;
                    Wasser_Wunsch.ReadOnly = false;
                    Wasser_Wunsch.Enabled = false;
                    Wasser = false;
                }

                //Kupfer
                if (Kupfer_aweleble.Checked || (Schlacke_Wunsch.ReadOnly == false && Strom))
                {
                    Kupfer_Wunsch.ReadOnly = false;
                    Kupfer_Wunsch.Enabled = true;
                    Kupfer = true;
                }
                else
                {
                    Kupfer_Wunsch.Value = 0;
                    Kupfer_Wunsch.ReadOnly = true;
                    Kupfer_Wunsch.Enabled = false;
                    Kupfer = false;
                }

                //Blei
                if (Blei_aweleble.Checked || (Schlacke_Wunsch.ReadOnly == false && Strom))
                {
                    Blei_Wunsch.ReadOnly = false;
                    Blei_Wunsch.Enabled = true;
                    Blei = true;
                }
                else
                {
                    Blei_Wunsch.Value = 0;
                    Blei_Wunsch.ReadOnly = true;
                    Blei_Wunsch.Enabled = false;
                    Blei = false;
                }

                //Sand
                if (Sand_aweleble.Checked || (Schlacke_Wunsch.ReadOnly == false && Strom))
                {
                    Sand_Wunsch.ReadOnly = false;
                    Sand_Wunsch.Enabled = true;
                    Sand = true;
                }
                else
                {
                    Sand_Wunsch.Value = 0;
                    Sand_Wunsch.ReadOnly = true;
                    Sand_Wunsch.Enabled = false;
                    Sand = false;
                }

                //Kohle
                if (Kohle_aweleble.Checked || Wasser)
                {
                    Kohle_Wunsch.ReadOnly = false;
                    Kohle_Wunsch.Enabled = true;
                    Kohle = true;
                }
                else
                {
                    Kohle_Wunsch.Value = 0;
                    Kohle_Wunsch.ReadOnly = true;
                    Kohle_Wunsch.Enabled = false;
                    Kohle = false;
                }



                //Titan
                if ((Titan_aweleble.Checked || (Schlacke_Wunsch.ReadOnly == false && Strom)) &&
                    (PBohrer_OW_Div.Value > 0 || PBohrer_MW_Div.Value > 0 ||
                    LBohrer_OW_Div.Value > 0 || LBohrer_MW_Div.Value > 0 ||
                    SBohrer_OW_Div.Value > 0 || SBohrer_MW_Div.Value > 0))
                {
                    Titan_Wunsch.ReadOnly = false;
                    Titan_Wunsch.Enabled = true;
                    Titan = true;
                }
                else
                {
                    Titan_Wunsch.Value = 0;
                    Titan_Wunsch.ReadOnly = true;
                    Titan_Wunsch.Enabled = false;
                    Titan = false;
                }

                //Thorium
                if (((Thorium_aweleble.Checked && Strom) || (Schlacke_Wunsch.ReadOnly == false && Strom)) &&
                    (LBohrer_OW_Div.Value > 0 || LBohrer_MW_Div.Value > 0 ||
                    SBohrer_OW_Div.Value > 0 || SBohrer_MW_Div.Value > 0))
                {
                    Thorium_Wunsch.ReadOnly = false;
                    Thorium_Wunsch.Enabled = true;
                    Thorium = true;
                }
                else
                {
                    Thorium_Wunsch.Value = 0;
                    Thorium_Wunsch.ReadOnly = true;
                    Thorium_Wunsch.Enabled = false;
                    Thorium = false;
                }

                //Kryoflüssigkeit
                if (Kryoflüssigkeit_aweleble.Checked || (Titan_Wunsch.ReadOnly == false && Wasser))
                {
                    Kryoflüssigkeit_Wunsch.ReadOnly = false;
                    Kryoflüssigkeit_Wunsch.Enabled = true;
                    Kryoflüssigkeit = true;
                }
                else
                {
                    Kryoflüssigkeit_Wunsch.Value = 0;
                    Kryoflüssigkeit_Wunsch.ReadOnly = true;
                    Kryoflüssigkeit_Wunsch.Enabled = false;
                    Kryoflüssigkeit = false;
                }

                //Sporen-Pod
                if (Wasser && Strom)
                {
                    SporenPod_Wunsch.ReadOnly = false;
                    SporenPod_Wunsch.Enabled = true;
                    SporenPod = true;
                }
                else
                {
                    SporenPod_Wunsch.Value = 0;
                    SporenPod_Wunsch.ReadOnly = true;
                    SporenPod_Wunsch.Enabled = false;
                    SporenPod = false;
                }

                //Öl
                if (Öl_aweleble.Checked || SporenPod_Wunsch.ReadOnly == false || (Sand_Wunsch.ReadOnly == false && Wasser))
                {
                    Öl_Wunsch.ReadOnly = false;
                    Öl_Wunsch.Enabled = true;
                    Öl = true;
                }
                else
                {
                    Öl_Wunsch.Value = 0;
                    Öl_Wunsch.ReadOnly = true;
                    Öl_Wunsch.Enabled = false;
                    Öl = false;
                }

                //Metaglas
                if (Blei_Wunsch.ReadOnly == false && Sand_Wunsch.ReadOnly == false && Strom)
                {
                    Metaglas_Wunsch.ReadOnly = false;
                    Metaglas_Wunsch.Enabled = true;
                    Metaglas = true;
                }
                else
                {
                    Metaglas_Wunsch.Value = 0;
                    Metaglas_Wunsch.ReadOnly = true;
                    Metaglas_Wunsch.Enabled = false;
                    Metaglas = false;
                }

                //Grafit
                if (Kohle_Wunsch.ReadOnly == false)
                {
                    Grafit_Wunsch.ReadOnly = false;
                    Grafit_Wunsch.Enabled = true;
                    Grafit = true;
                }
                else
                {
                    Grafit_Wunsch.Value = 0;
                    Grafit_Wunsch.ReadOnly = true;
                    Grafit_Wunsch.Enabled = false;
                    Grafit = false;
                }

                //Silizium
                if (Kohle_Wunsch.ReadOnly == false && Sand_Wunsch.ReadOnly == false && Strom)
                {
                    Silizium_Wunsch.ReadOnly = false;
                    Silizium_Wunsch.Enabled = true;
                    Silizium = true;
                }
                else
                {
                    Silizium_Wunsch.Value = 0;
                    Silizium_Wunsch.ReadOnly = true;
                    Silizium_Wunsch.Enabled = false;
                    Silizium = false;
                }

                //Pyratit
                if (Kohle_Wunsch.ReadOnly == false && Sand_Wunsch.ReadOnly == false && Strom && Kohle_Wunsch.ReadOnly == false)
                {
                    Pyratit_Wunsch.ReadOnly = false;
                    Pyratit_Wunsch.Enabled = true;
                    Pyratit = true;
                }
                else
                {
                    Pyratit_Wunsch.Value = 0;
                    Pyratit_Wunsch.ReadOnly = true;
                    Pyratit_Wunsch.Enabled = false;
                    Pyratit = false;
                }

                //Explosive Mischung
                if (Pyratit_Wunsch.ReadOnly == false && SporenPod_Wunsch.ReadOnly == false && Strom)
                {
                    ExplosiveMischung_Wunsch.ReadOnly = false;
                    ExplosiveMischung_Wunsch.Enabled = true;
                    ExplosiveMischung = true;
                }
                else
                {
                    ExplosiveMischung_Wunsch.Value = 0;
                    ExplosiveMischung_Wunsch.ReadOnly = true;
                    ExplosiveMischung_Wunsch.Enabled = false;
                    ExplosiveMischung = false;
                }

                //Plastanium
                if (Titan_Wunsch.ReadOnly == false && Öl_Wunsch.ReadOnly == false && Strom)
                {
                    Plastanium_Wunsch.ReadOnly = false;
                    Plastanium_Wunsch.Enabled = true;
                    Plastanium = true;
                }
                else
                {
                    Plastanium_Wunsch.Value = 0;
                    Plastanium_Wunsch.ReadOnly = true;
                    Plastanium_Wunsch.Enabled = false;
                    Plastanium = false;
                }

                //Phasengewebe
                if (Sand_Wunsch.ReadOnly == false && Thorium_Wunsch.ReadOnly == false && Strom)
                {
                    Phasengewebe_Wunsch.ReadOnly = false;
                    Phasengewebe_Wunsch.Enabled = true;
                    Phasengewebe = true;
                }
                else
                {
                    Phasengewebe_Wunsch.Value = 0;
                    Phasengewebe_Wunsch.ReadOnly = true;
                    Phasengewebe_Wunsch.Enabled = false;
                    Phasengewebe = false;
                }

                //Spannungslegierung
                if (Kupfer_Wunsch.ReadOnly == false && Blei_Wunsch.ReadOnly == false && Titan_Wunsch.ReadOnly == false && Silizium_Wunsch.ReadOnly == false && Strom)
                {
                    Spannungslegierung_Wunsch.ReadOnly = false;
                    Spannungslegierung_Wunsch.Enabled = true;
                    Spannungslegierung = true;
                }
                else
                {
                    Spannungslegierung_Wunsch.Value = 0;
                    Spannungslegierung_Wunsch.ReadOnly = true;
                    Spannungslegierung_Wunsch.Enabled = false;
                    Spannungslegierung = false;
                }
            }

            //Rohstoff - Abbau
            {
                //Kupfer - Bohrer
                if (Kupfer_aweleble.Checked)
                {
                    //Mechanischer - Bohrer
                    Kupfer_MBohrer_OW_Zu.ReadOnly = false;
                    Kupfer_MBohrer_OW_Zu.Enabled = true;

                    //Pneumatischer - Bohrer
                    Kupfer_PBohrer_OW_Zu.ReadOnly = false;
                    Kupfer_PBohrer_OW_Zu.Enabled = true;

                    if (Strom)
                    {
                        //Laser - Bohrer
                        Kupfer_LBohrer_OW_Zu.ReadOnly = false;
                        Kupfer_LBohrer_OW_Zu.Enabled = true;

                        //Sprengluftbohrer
                        Kupfer_SBohrer_OW_Zu.ReadOnly = false;
                        Kupfer_SBohrer_OW_Zu.Enabled = true;
                    }
                    else
                    {
                        //Laser - Bohrer
                        Kupfer_LBohrer_OW_Zu.ReadOnly = true;
                        Kupfer_LBohrer_OW_Zu.Enabled = false;

                        //Sprengluftbohrer
                        Kupfer_SBohrer_OW_Zu.ReadOnly = true;
                        Kupfer_SBohrer_OW_Zu.Enabled = false;
                    }
                }
                else
                {
                    //Mechanischer - Bohrer
                    Kupfer_MBohrer_OW_Zu.ReadOnly = true;
                    Kupfer_MBohrer_OW_Zu.Enabled = false;

                    //Pneumatischer - Bohrer
                    Kupfer_PBohrer_OW_Zu.ReadOnly = true;
                    Kupfer_PBohrer_OW_Zu.Enabled = false;

                    //Laser - Bohrer
                    Kupfer_LBohrer_OW_Zu.ReadOnly = true;
                    Kupfer_LBohrer_OW_Zu.Enabled = false;

                    //Sprengluftbohrer
                    Kupfer_SBohrer_OW_Zu.ReadOnly = true;
                    Kupfer_SBohrer_OW_Zu.Enabled = false;
                }

                //Kupfer - Bohrer + Wasser
                if (Kupfer_aweleble.Checked && Wasser)
                {
                    //Mechanischer - Bohrer
                    Kupfer_MBohrer_MW_Zu.ReadOnly = false;
                    Kupfer_MBohrer_MW_Zu.Enabled = true;

                    //Pneumatischer - Bohrer
                    Kupfer_PBohrer_MW_Zu.ReadOnly = false;
                    Kupfer_PBohrer_MW_Zu.Enabled = true;

                    if (Strom)
                    {
                        //Laser - Bohrer
                        Kupfer_LBohrer_MW_Zu.ReadOnly = false;
                        Kupfer_LBohrer_MW_Zu.Enabled = true;

                        //Sprengluftbohrer
                        Kupfer_SBohrer_MW_Zu.ReadOnly = false;
                        Kupfer_SBohrer_MW_Zu.Enabled = true;

                    }
                    else
                    {
                        //Laser - Bohrer
                        Kupfer_LBohrer_MW_Zu.ReadOnly = true;
                        Kupfer_LBohrer_MW_Zu.Enabled = false;

                        //Sprengluftbohrer
                        Kupfer_SBohrer_MW_Zu.ReadOnly = true;
                        Kupfer_SBohrer_MW_Zu.Enabled = false;
                    }
                }
                else
                {
                    //Mechanischer - Bohrer
                    Kupfer_MBohrer_MW_Zu.ReadOnly = true;
                    Kupfer_MBohrer_MW_Zu.Enabled = false;

                    //Pneumatischer - Bohrer
                    Kupfer_PBohrer_MW_Zu.ReadOnly = true;
                    Kupfer_PBohrer_MW_Zu.Enabled = false;

                    //Laser - Bohrer
                    Kupfer_LBohrer_MW_Zu.ReadOnly = true;
                    Kupfer_LBohrer_MW_Zu.Enabled = false;

                    //Sprengluftbohrer
                    Kupfer_SBohrer_MW_Zu.ReadOnly = true;
                    Kupfer_SBohrer_MW_Zu.Enabled = false;
                }

                //Blei - Bohrer
                if (Blei_aweleble.Checked)
                {
                    //Mechanischer - Bohrer
                    Blei_MBohrer_OW_Zu.ReadOnly = false;
                    Blei_MBohrer_OW_Zu.Enabled = true;

                    //Pneumatischer - Bohrer
                    Blei_PBohrer_OW_Zu.ReadOnly = false;
                    Blei_PBohrer_OW_Zu.Enabled = true;

                    if (Strom)
                    {
                        //Laser - Bohrer
                        Blei_LBohrer_OW_Zu.ReadOnly = false;
                        Blei_LBohrer_OW_Zu.Enabled = true;

                        //Sprengluftbohrer
                        Blei_SBohrer_OW_Zu.ReadOnly = false;
                        Blei_SBohrer_OW_Zu.Enabled = true;
                    }
                    else
                    {
                        //Laser - Bohrer
                        Blei_LBohrer_OW_Zu.ReadOnly = true;
                        Blei_LBohrer_OW_Zu.Enabled = false;

                        //Sprengluftbohrer
                        Blei_SBohrer_OW_Zu.ReadOnly = true;
                        Blei_SBohrer_OW_Zu.Enabled = false;
                    }
                }
                else
                {
                    //Mechanischer - Bohrer
                    Blei_MBohrer_OW_Zu.ReadOnly = true;
                    Blei_MBohrer_OW_Zu.Enabled = false;

                    //Pneumatischer - Bohrer
                    Blei_PBohrer_OW_Zu.ReadOnly = true;
                    Blei_PBohrer_OW_Zu.Enabled = false;

                    //Laser - Bohrer
                    Blei_LBohrer_OW_Zu.ReadOnly = true;
                    Blei_LBohrer_OW_Zu.Enabled = false;

                    //Sprengluftbohrer
                    Blei_SBohrer_OW_Zu.ReadOnly = true;
                    Blei_SBohrer_OW_Zu.Enabled = false;
                }

                //Blei - Bohrer + Wasser
                if (Blei_aweleble.Checked && Wasser)
                {
                    //Mechanischer - Bohrer
                    Blei_MBohrer_MW_Zu.ReadOnly = false;
                    Blei_MBohrer_MW_Zu.Enabled = true;

                    //Pneumatischer - Bohrer
                    Blei_PBohrer_MW_Zu.ReadOnly = false;
                    Blei_PBohrer_MW_Zu.Enabled = true;

                    if (Strom)
                    {
                        //Laser - Bohrer
                        Blei_LBohrer_MW_Zu.ReadOnly = false;
                        Blei_LBohrer_MW_Zu.Enabled = true;

                        //Sprengluftbohrer
                        Blei_SBohrer_MW_Zu.ReadOnly = false;
                        Blei_SBohrer_MW_Zu.Enabled = true;

                    }
                    else
                    {
                        //Laser - Bohrer
                        Blei_LBohrer_MW_Zu.ReadOnly = true;
                        Blei_LBohrer_MW_Zu.Enabled = false;

                        //Sprengluftbohrer
                        Blei_SBohrer_MW_Zu.ReadOnly = true;
                        Blei_SBohrer_MW_Zu.Enabled = false;
                    }
                }
                else
                {
                    //Mechanischer - Bohrer
                    Blei_MBohrer_MW_Zu.ReadOnly = true;
                    Blei_MBohrer_MW_Zu.Enabled = false;

                    //Pneumatischer - Bohrer
                    Blei_PBohrer_MW_Zu.ReadOnly = true;
                    Blei_PBohrer_MW_Zu.Enabled = false;

                    //Laser - Bohrer
                    Blei_LBohrer_MW_Zu.ReadOnly = true;
                    Blei_LBohrer_MW_Zu.Enabled = false;

                    //Sprengluftbohrer
                    Blei_SBohrer_MW_Zu.ReadOnly = true;
                    Blei_SBohrer_MW_Zu.Enabled = false;
                }

                //Sand - Bohrer
                if (Sand_aweleble.Checked)
                {
                    //Mechanischer - Bohrer
                    Sand_MBohrer_OW_Zu.ReadOnly = false;
                    Sand_MBohrer_OW_Zu.Enabled = true;

                    //Pneumatischer - Bohrer
                    Sand_PBohrer_OW_Zu.ReadOnly = false;
                    Sand_PBohrer_OW_Zu.Enabled = true;

                    if (Strom)
                    {
                        //Laser - Bohrer
                        Sand_LBohrer_OW_Zu.ReadOnly = false;
                        Sand_LBohrer_OW_Zu.Enabled = true;

                        //Sprengluftbohrer
                        Sand_SBohrer_OW_Zu.ReadOnly = false;
                        Sand_SBohrer_OW_Zu.Enabled = true;
                    }
                    else
                    {
                        //Laser - Bohrer
                        Sand_LBohrer_OW_Zu.ReadOnly = true;
                        Sand_LBohrer_OW_Zu.Enabled = false;

                        //Sprengluftbohrer
                        Sand_SBohrer_OW_Zu.ReadOnly = true;
                        Sand_SBohrer_OW_Zu.Enabled = false;
                    }
                }
                else
                {
                    //Mechanischer - Bohrer
                    Sand_MBohrer_OW_Zu.ReadOnly = true;
                    Sand_MBohrer_OW_Zu.Enabled = false;

                    //Pneumatischer - Bohrer
                    Sand_PBohrer_OW_Zu.ReadOnly = true;
                    Sand_PBohrer_OW_Zu.Enabled = false;

                    //Laser - Bohrer
                    Sand_LBohrer_OW_Zu.ReadOnly = true;
                    Sand_LBohrer_OW_Zu.Enabled = false;

                    //Sprengluftbohrer
                    Sand_SBohrer_OW_Zu.ReadOnly = true;
                    Sand_SBohrer_OW_Zu.Enabled = false;
                }

                //Sand - Bohrer + Wasser
                if (Sand_aweleble.Checked && Wasser)
                {
                    //Mechanischer - Bohrer
                    Sand_MBohrer_MW_Zu.ReadOnly = false;
                    Sand_MBohrer_MW_Zu.Enabled = true;

                    //Pneumatischer - Bohrer
                    Sand_PBohrer_MW_Zu.ReadOnly = false;
                    Sand_PBohrer_MW_Zu.Enabled = true;

                    if (Strom)
                    {
                        //Laser - Bohrer
                        Sand_LBohrer_MW_Zu.ReadOnly = false;
                        Sand_LBohrer_MW_Zu.Enabled = true;

                        //Sprengluftbohrer
                        Sand_SBohrer_MW_Zu.ReadOnly = false;
                        Sand_SBohrer_MW_Zu.Enabled = true;

                    }
                    else
                    {
                        //Laser - Bohrer
                        Sand_LBohrer_MW_Zu.ReadOnly = true;
                        Sand_LBohrer_MW_Zu.Enabled = false;

                        //Sprengluftbohrer
                        Sand_SBohrer_MW_Zu.ReadOnly = true;
                        Sand_SBohrer_MW_Zu.Enabled = false;
                    }
                }
                else
                {
                    //Mechanischer - Bohrer
                    Sand_MBohrer_MW_Zu.ReadOnly = true;
                    Sand_MBohrer_MW_Zu.Enabled = false;

                    //Pneumatischer - Bohrer
                    Sand_PBohrer_MW_Zu.ReadOnly = true;
                    Sand_PBohrer_MW_Zu.Enabled = false;

                    //Laser - Bohrer
                    Sand_LBohrer_MW_Zu.ReadOnly = true;
                    Sand_LBohrer_MW_Zu.Enabled = false;

                    //Sprengluftbohrer
                    Sand_SBohrer_MW_Zu.ReadOnly = true;
                    Sand_SBohrer_MW_Zu.Enabled = false;
                }

                //Kohle - Bohrer
                if (Kohle_aweleble.Checked)
                {
                    //Mechanischer - Bohrer
                    Kohle_MBohrer_OW_Zu.ReadOnly = false;
                    Kohle_MBohrer_OW_Zu.Enabled = true;

                    //Pneumatischer - Bohrer
                    Kohle_PBohrer_OW_Zu.ReadOnly = false;
                    Kohle_PBohrer_OW_Zu.Enabled = true;

                    if (Strom)
                    {
                        //Laser - Bohrer
                        Kohle_LBohrer_OW_Zu.ReadOnly = false;
                        Kohle_LBohrer_OW_Zu.Enabled = true;

                        //Sprengluftbohrer
                        Kohle_SBohrer_OW_Zu.ReadOnly = false;
                        Kohle_SBohrer_OW_Zu.Enabled = true;
                    }
                    else
                    {
                        //Laser - Bohrer
                        Kohle_LBohrer_OW_Zu.ReadOnly = true;
                        Kohle_LBohrer_OW_Zu.Enabled = false;

                        //Sprengluftbohrer
                        Kohle_SBohrer_OW_Zu.ReadOnly = true;
                        Kohle_SBohrer_OW_Zu.Enabled = false;
                    }
                }
                else
                {
                    //Mechanischer - Bohrer
                    Kohle_MBohrer_OW_Zu.ReadOnly = true;
                    Kohle_MBohrer_OW_Zu.Enabled = false;

                    //Pneumatischer - Bohrer
                    Kohle_PBohrer_OW_Zu.ReadOnly = true;
                    Kohle_PBohrer_OW_Zu.Enabled = false;

                    //Laser - Bohrer
                    Kohle_LBohrer_OW_Zu.ReadOnly = true;
                    Kohle_LBohrer_OW_Zu.Enabled = false;

                    //Sprengluftbohrer
                    Kohle_SBohrer_OW_Zu.ReadOnly = true;
                    Kohle_SBohrer_OW_Zu.Enabled = false;
                }

                //Kohle - Bohrer + Wasser
                if (Kohle_aweleble.Checked && Wasser)
                {
                    //Mechanischer - Bohrer
                    Kohle_MBohrer_MW_Zu.ReadOnly = false;
                    Kohle_MBohrer_MW_Zu.Enabled = true;

                    //Pneumatischer - Bohrer
                    Kohle_PBohrer_MW_Zu.ReadOnly = false;
                    Kohle_PBohrer_MW_Zu.Enabled = true;

                    if (Strom)
                    {
                        //Laser - Bohrer
                        Kohle_LBohrer_MW_Zu.ReadOnly = false;
                        Kohle_LBohrer_MW_Zu.Enabled = true;

                        //Sprengluftbohrer
                        Kohle_SBohrer_MW_Zu.ReadOnly = false;
                        Kohle_SBohrer_MW_Zu.Enabled = true;

                    }
                    else
                    {
                        //Laser - Bohrer
                        Kohle_LBohrer_MW_Zu.ReadOnly = true;
                        Kohle_LBohrer_MW_Zu.Enabled = false;

                        //Sprengluftbohrer
                        Kohle_SBohrer_MW_Zu.ReadOnly = true;
                        Kohle_SBohrer_MW_Zu.Enabled = false;
                    }
                }
                else
                {
                    //Mechanischer - Bohrer
                    Kohle_MBohrer_MW_Zu.ReadOnly = true;
                    Kohle_MBohrer_MW_Zu.Enabled = false;

                    //Pneumatischer - Bohrer
                    Kohle_PBohrer_MW_Zu.ReadOnly = true;
                    Kohle_PBohrer_MW_Zu.Enabled = false;

                    //Laser - Bohrer
                    Kohle_LBohrer_MW_Zu.ReadOnly = true;
                    Kohle_LBohrer_MW_Zu.Enabled = false;

                    //Sprengluftbohrer
                    Kohle_SBohrer_MW_Zu.ReadOnly = true;
                    Kohle_SBohrer_MW_Zu.Enabled = false;
                }

                //Titan - Bohrer
                if (Titan_aweleble.Checked)
                {
                    //Pneumatischer - Bohrer
                    Titan_PBohrer_OW_Zu.ReadOnly = false;
                    Titan_PBohrer_OW_Zu.Enabled = true;

                    if (Strom)
                    {
                        //Laser - Bohrer
                        Titan_LBohrer_OW_Zu.ReadOnly = false;
                        Titan_LBohrer_OW_Zu.Enabled = true;

                        //Sprengluftbohrer
                        Titan_SBohrer_OW_Zu.ReadOnly = false;
                        Titan_SBohrer_OW_Zu.Enabled = true;
                    }
                    else
                    {
                        //Laser - Bohrer
                        Titan_LBohrer_OW_Zu.ReadOnly = true;
                        Titan_LBohrer_OW_Zu.Enabled = false;

                        //Sprengluftbohrer
                        Titan_SBohrer_OW_Zu.ReadOnly = true;
                        Titan_SBohrer_OW_Zu.Enabled = false;
                    }
                }
                else
                {
                    //Pneumatischer - Bohrer
                    Titan_PBohrer_OW_Zu.ReadOnly = true;
                    Titan_PBohrer_OW_Zu.Enabled = false;

                    //Laser - Bohrer
                    Titan_LBohrer_OW_Zu.ReadOnly = true;
                    Titan_LBohrer_OW_Zu.Enabled = false;

                    //Sprengluftbohrer
                    Titan_SBohrer_OW_Zu.ReadOnly = true;
                    Titan_SBohrer_OW_Zu.Enabled = false;
                }

                //Titan - Bohrer + Wasser
                if (Titan_aweleble.Checked && Wasser)
                {
                    //Pneumatischer - Bohrer
                    Titan_PBohrer_MW_Zu.ReadOnly = false;
                    Titan_PBohrer_MW_Zu.Enabled = true;

                    if (Strom)
                    {
                        //Laser - Bohrer
                        Titan_LBohrer_MW_Zu.ReadOnly = false;
                        Titan_LBohrer_MW_Zu.Enabled = true;

                        //Sprengluftbohrer
                        Titan_SBohrer_MW_Zu.ReadOnly = false;
                        Titan_SBohrer_MW_Zu.Enabled = true;

                    }
                    else
                    {
                        //Laser - Bohrer
                        Titan_LBohrer_MW_Zu.ReadOnly = true;
                        Titan_LBohrer_MW_Zu.Enabled = false;

                        //Sprengluftbohrer
                        Titan_SBohrer_MW_Zu.ReadOnly = true;
                        Titan_SBohrer_MW_Zu.Enabled = false;
                    }
                }
                else
                {
                    //Pneumatischer - Bohrer
                    Titan_PBohrer_MW_Zu.ReadOnly = true;
                    Titan_PBohrer_MW_Zu.Enabled = false;

                    //Laser - Bohrer
                    Titan_LBohrer_MW_Zu.ReadOnly = true;
                    Titan_LBohrer_MW_Zu.Enabled = false;

                    //Sprengluftbohrer
                    Titan_SBohrer_MW_Zu.ReadOnly = true;
                    Titan_SBohrer_MW_Zu.Enabled = false;
                }

                //Thorium - Bohrer
                if (Thorium_aweleble.Checked && Strom)
                {
                    //Laser - Bohrer
                    Thorium_LBohrer_OW_Zu.ReadOnly = false;
                    Thorium_LBohrer_OW_Zu.Enabled = true;

                    //Sprengluftbohrer
                    Thorium_SBohrer_OW_Zu.ReadOnly = false;
                    Thorium_SBohrer_OW_Zu.Enabled = true;
                }
                else
                {
                    //Laser - Bohrer
                    Thorium_LBohrer_OW_Zu.ReadOnly = true;
                    Thorium_LBohrer_OW_Zu.Enabled = false;

                    //Sprengluftbohrer
                    Thorium_SBohrer_OW_Zu.ReadOnly = true;
                    Thorium_SBohrer_OW_Zu.Enabled = false;
                }

                //Thorium - Bohrer + Wasser
                if (Thorium_aweleble.Checked && Wasser && Strom)
                {
                    //Laser - Bohrer
                    Thorium_LBohrer_MW_Zu.ReadOnly = false;
                    Thorium_LBohrer_MW_Zu.Enabled = true;

                    //Sprengluftbohrer
                    Thorium_SBohrer_MW_Zu.ReadOnly = false;
                    Thorium_SBohrer_MW_Zu.Enabled = true;
                }
                else
                {
                    //Laser - Bohrer
                    Thorium_LBohrer_MW_Zu.ReadOnly = true;
                    Thorium_LBohrer_MW_Zu.Enabled = false;

                    //Sprengluftbohrer
                    Thorium_SBohrer_MW_Zu.ReadOnly = true;
                    Thorium_SBohrer_MW_Zu.Enabled = false;
                }

                //Schrott - Bohrer
                if (Schrott_aweleble.Checked)
                {
                    //Mechanischer - Bohrer
                    Schrott_MBohrer_OW_Zu.ReadOnly = false;
                    Schrott_MBohrer_OW_Zu.Enabled = true;

                    //Pneumatischer - Bohrer
                    Schrott_PBohrer_OW_Zu.ReadOnly = false;
                    Schrott_PBohrer_OW_Zu.Enabled = true;

                    if (Strom)
                    {
                        //Laser - Bohrer
                        Schrott_LBohrer_OW_Zu.ReadOnly = false;
                        Schrott_LBohrer_OW_Zu.Enabled = true;

                        //Sprengluftbohrer
                        Schrott_SBohrer_OW_Zu.ReadOnly = false;
                        Schrott_SBohrer_OW_Zu.Enabled = true;
                    }
                    else
                    {
                        //Laser - Bohrer
                        Schrott_LBohrer_OW_Zu.ReadOnly = true;
                        Schrott_LBohrer_OW_Zu.Enabled = false;

                        //Sprengluftbohrer
                        Schrott_SBohrer_OW_Zu.ReadOnly = true;
                        Schrott_SBohrer_OW_Zu.Enabled = false;
                    }
                }
                else
                {
                    //Mechanischer - Bohrer
                    Schrott_MBohrer_OW_Zu.ReadOnly = true;
                    Schrott_MBohrer_OW_Zu.Enabled = false;

                    //Pneumatischer - Bohrer
                    Schrott_PBohrer_OW_Zu.ReadOnly = true;
                    Schrott_PBohrer_OW_Zu.Enabled = false;

                    //Laser - Bohrer
                    Schrott_LBohrer_OW_Zu.ReadOnly = true;
                    Schrott_LBohrer_OW_Zu.Enabled = false;

                    //Sprengluftbohrer
                    Schrott_SBohrer_OW_Zu.ReadOnly = true;
                    Schrott_SBohrer_OW_Zu.Enabled = false;
                }

                //Schrott - Bohrer + Wasser
                if (Schrott_aweleble.Checked && Wasser)
                {
                    //Mechanischer - Bohrer
                    Schrott_MBohrer_MW_Zu.ReadOnly = false;
                    Schrott_MBohrer_MW_Zu.Enabled = true;

                    //Pneumatischer - Bohrer
                    Schrott_PBohrer_MW_Zu.ReadOnly = false;
                    Schrott_PBohrer_MW_Zu.Enabled = true;

                    if (Strom)
                    {
                        //Laser - Bohrer
                        Schrott_LBohrer_MW_Zu.ReadOnly = false;
                        Schrott_LBohrer_MW_Zu.Enabled = true;

                        //Sprengluftbohrer
                        Schrott_SBohrer_MW_Zu.ReadOnly = false;
                        Schrott_SBohrer_MW_Zu.Enabled = true;

                    }
                    else
                    {
                        //Laser - Bohrer
                        Schrott_LBohrer_MW_Zu.ReadOnly = true;
                        Schrott_LBohrer_MW_Zu.Enabled = false;

                        //Sprengluftbohrer
                        Schrott_SBohrer_MW_Zu.ReadOnly = true;
                        Schrott_SBohrer_MW_Zu.Enabled = false;
                    }
                }
                else
                {
                    //Mechanischer - Bohrer
                    Schrott_MBohrer_MW_Zu.ReadOnly = true;
                    Schrott_MBohrer_MW_Zu.Enabled = false;

                    //Pneumatischer - Bohrer
                    Schrott_PBohrer_MW_Zu.ReadOnly = true;
                    Schrott_PBohrer_MW_Zu.Enabled = false;

                    //Laser - Bohrer
                    Schrott_LBohrer_MW_Zu.ReadOnly = true;
                    Schrott_LBohrer_MW_Zu.Enabled = false;

                    //Sprengluftbohrer
                    Schrott_SBohrer_MW_Zu.ReadOnly = true;
                    Schrott_SBohrer_MW_Zu.Enabled = false;
                }


                //Wasser - Pumpe
                if (Wasser_aweleble.Checked)
                {
                    //Mechanische - Pumpe
                    Wasser_MP_Zu.ReadOnly = false;
                    Wasser_MP_Zu.Enabled = true;

                    if (Strom)
                    {
                        //Rotierende - Pumpe
                        Wasser_RP_Zu.ReadOnly = false;
                        Wasser_RP_Zu.Enabled = true;

                        //Thermische - Pumpe
                        Wasser_TP_Zu.ReadOnly = false;
                        Wasser_TP_Zu.Enabled = true;
                    }
                    else
                    {
                        //Rotierende - Pumpe
                        Wasser_RP_Zu.ReadOnly = true;
                        Wasser_RP_Zu.Enabled = false;

                        //Thermische - Pumpe
                        Wasser_TP_Zu.ReadOnly = true;
                        Wasser_TP_Zu.Enabled = false;
                    }
                }
                else
                {
                    //Mechanische - Pumpe
                    Wasser_MP_Zu.ReadOnly = true;
                    Wasser_MP_Zu.Enabled = false;

                    //Rotierende - Pumpe
                    Wasser_RP_Zu.ReadOnly = true;
                    Wasser_RP_Zu.Enabled = false;

                    //Thermische - Pumpe
                    Wasser_TP_Zu.ReadOnly = true;
                    Wasser_TP_Zu.Enabled = false;
                }

                //Kryoflüssigkeit - Pumpe
                if (Kryoflüssigkeit_aweleble.Checked)
                {
                    //Mechanische - Pumpe
                    Kryoflüssigkeit_MP_Zu.ReadOnly = false;
                    Kryoflüssigkeit_MP_Zu.Enabled = true;

                    if (Strom)
                    {
                        //Rotierende - Pumpe
                        Kryoflüssigkeit_RP_Zu.ReadOnly = false;
                        Kryoflüssigkeit_RP_Zu.Enabled = true;

                        //Thermische - Pumpe
                        Kryoflüssigkeit_TP_Zu.ReadOnly = false;
                        Kryoflüssigkeit_TP_Zu.Enabled = true;
                    }
                    else
                    {
                        //Rotierende - Pumpe
                        Kryoflüssigkeit_RP_Zu.ReadOnly = true;
                        Kryoflüssigkeit_RP_Zu.Enabled = false;

                        //Thermische - Pumpe
                        Kryoflüssigkeit_TP_Zu.ReadOnly = true;
                        Kryoflüssigkeit_TP_Zu.Enabled = false;
                    }
                }
                else
                {
                    //Mechanische - Pumpe
                    Kryoflüssigkeit_MP_Zu.ReadOnly = true;
                    Kryoflüssigkeit_MP_Zu.Enabled = false;

                    //Rotierende - Pumpe
                    Kryoflüssigkeit_RP_Zu.ReadOnly = true;
                    Kryoflüssigkeit_RP_Zu.Enabled = false;

                    //Thermische - Pumpe
                    Kryoflüssigkeit_TP_Zu.ReadOnly = true;
                    Kryoflüssigkeit_TP_Zu.Enabled = false;
                }

                //Öl - Pumpe
                if (Öl_aweleble.Checked)
                {
                    //Mechanische - Pumpe
                    Öl_MP_Zu.ReadOnly = false;
                    Öl_MP_Zu.Enabled = true;

                    if (Strom)
                    {
                        //Rotierende - Pumpe
                        Öl_RP_Zu.ReadOnly = false;
                        Öl_RP_Zu.Enabled = true;

                        //Thermische - Pumpe
                        Öl_TP_Zu.ReadOnly = false;
                        Öl_TP_Zu.Enabled = true;
                    }
                    else
                    {
                        //Rotierende - Pumpe
                        Öl_RP_Zu.ReadOnly = true;
                        Öl_RP_Zu.Enabled = false;

                        //Thermische - Pumpe
                        Öl_TP_Zu.ReadOnly = true;
                        Öl_TP_Zu.Enabled = false;
                    }
                }
                else
                {
                    //Mechanische - Pumpe
                    Öl_MP_Zu.ReadOnly = true;
                    Öl_MP_Zu.Enabled = false;

                    //Rotierende - Pumpe
                    Öl_RP_Zu.ReadOnly = true;
                    Öl_RP_Zu.Enabled = false;

                    //Thermische - Pumpe
                    Öl_TP_Zu.ReadOnly = true;
                    Öl_TP_Zu.Enabled = false;
                }

                //Schlacke - Pumpe
                if (Schlacke_aweleble.Checked)
                {
                    //Mechanische - Pumpe
                    Schlacke_MP_Zu.ReadOnly = false;
                    Schlacke_MP_Zu.Enabled = true;

                    if (Strom)
                    {
                        //Rotierende - Pumpe
                        Schlacke_RP_Zu.ReadOnly = false;
                        Schlacke_RP_Zu.Enabled = true;

                        //Thermische - Pumpe
                        Schlacke_TP_Zu.ReadOnly = false;
                        Schlacke_TP_Zu.Enabled = true;
                    }
                    else
                    {
                        //Rotierende - Pumpe
                        Schlacke_RP_Zu.ReadOnly = true;
                        Schlacke_RP_Zu.Enabled = false;

                        //Thermische - Pumpe
                        Schlacke_TP_Zu.ReadOnly = true;
                        Schlacke_TP_Zu.Enabled = false;
                    }
                }
                else
                {
                    //Mechanische - Pumpe
                    Schlacke_MP_Zu.ReadOnly = true;
                    Schlacke_MP_Zu.Enabled = false;

                    //Rotierende - Pumpe
                    Schlacke_RP_Zu.ReadOnly = true;
                    Schlacke_RP_Zu.Enabled = false;

                    //Thermische - Pumpe
                    Schlacke_TP_Zu.ReadOnly = true;
                    Schlacke_TP_Zu.Enabled = false;
                }
            }

            //Producktion
            {
                //Grafit
                if (Kohle)
                {
                    //Grafit - Presse
                    GrafitPresse_Zu.ReadOnly = false;
                    GrafitPresse_Zu.Enabled = true;

                    //MultiPresse
                    if (Kohle && Strom && Wasser)
                    {
                        MultiPresse_Zu.ReadOnly = false;
                        MultiPresse_Zu.Enabled = true;
                    }
                    else
                    {
                        MultiPresse_Zu.ReadOnly = true;
                        MultiPresse_Zu.Enabled = false;
                    }
                }
                else
                {
                    //Grafit - Presse
                    GrafitPresse_Zu.ReadOnly = true;
                    GrafitPresse_Zu.Enabled = false;
                    //MultiPresse
                    MultiPresse_Zu.ReadOnly = true;
                    MultiPresse_Zu.Enabled = false;
                }

                //Silizium
                if (Sand && Kohle && Strom)
                {
                    //Silizium - Schmelzer
                    SiliziumSchmelzer_Zu.ReadOnly = false;
                    SiliziumSchmelzer_Zu.Enabled = true;

                    //Silizium - Schmelztiegel
                    if (Sand && Kohle && Pyratit && Strom)
                    {
                        SiliziumSchmelztiegel_Zu.ReadOnly = false;
                        SiliziumSchmelztiegel_Zu.Enabled = true;
                    }
                    else
                    {
                        SiliziumSchmelztiegel_Zu.ReadOnly = true;
                        SiliziumSchmelztiegel_Zu.Enabled = false;
                    }
                }
                else
                {
                    //Silizium - Schmelzer
                    SiliziumSchmelzer_Zu.ReadOnly = true;
                    SiliziumSchmelzer_Zu.Enabled = false;
                    //Silizium - Schmelztiegel
                    SiliziumSchmelztiegel_Zu.ReadOnly = true;
                    SiliziumSchmelztiegel_Zu.Enabled = false;
                }

                //Brennofen
                if (Sand && Blei && Strom)
                {
                    Brennofen_Zu.ReadOnly = false;
                    Brennofen_Zu.Enabled = true;
                }
                else
                {
                    Brennofen_Zu.ReadOnly = true;
                    Brennofen_Zu.Enabled = false;
                }

                //Plastanium - Verdichter
                if (Titan && Öl && Strom)
                {
                    PlastaniumVerdichter_Zu.ReadOnly = false;
                    PlastaniumVerdichter_Zu.Enabled = true;
                }
                else
                {
                    PlastaniumVerdichter_Zu.ReadOnly = true;
                    PlastaniumVerdichter_Zu.Enabled = false;
                }

                //Phasenweber
                if (Thorium && Sand && Strom)
                {
                    Phasenweber_Zu.ReadOnly = false;
                    Phasenweber_Zu.Enabled = true;
                }
                else
                {
                    Phasenweber_Zu.ReadOnly = true;
                    Phasenweber_Zu.Enabled = false;
                }

                //Legierungsschmelze
                if (Kupfer && Blei && Titan && Silizium && Strom)
                {
                    Legierungsschmelze_Zu.ReadOnly = false;
                    Legierungsschmelze_Zu.Enabled = true;
                }
                else
                {
                    Legierungsschmelze_Zu.ReadOnly = true;
                    Legierungsschmelze_Zu.Enabled = false;
                }

                //Pyatit - Mixer
                if (Sand && Kohle && Blei && Strom)
                {
                    PyratitMixer_Zu.ReadOnly = false;
                    PyratitMixer_Zu.Enabled = true;
                }
                else
                {
                    PyratitMixer_Zu.ReadOnly = true;
                    PyratitMixer_Zu.Enabled = false;
                }

                //Sprengmixer
                if (Pyratit && SporenPod && Strom)
                {
                    Sprengmixer_Zu.ReadOnly = false;
                    Sprengmixer_Zu.Enabled = true;
                }
                else
                {
                    Sprengmixer_Zu.ReadOnly = true;
                    Sprengmixer_Zu.Enabled = false;
                }


                //Wasser - Extractor
                if (Strom)
                {
                    WasserExtractor_Zu.ReadOnly = false;
                    WasserExtractor_Zu.Enabled = true;
                }
                else
                {
                    WasserExtractor_Zu.ReadOnly = true;
                    WasserExtractor_Zu.Enabled = false;
                }

                //Kultivierer
                if (Wasser && Strom)
                {
                    Kultivierer_Zu.ReadOnly = false;
                    Kultivierer_Zu.Enabled = true;
                }
                else
                {
                    Kultivierer_Zu.ReadOnly = true;
                    Kultivierer_Zu.Enabled = false;
                }

                //Öl - Extractor
                if (Sand && Wasser && Strom)
                {
                    ÖlExtractor_Zu.ReadOnly = false;
                    ÖlExtractor_Zu.Enabled = true;
                }
                else
                {
                    ÖlExtractor_Zu.ReadOnly = true;
                    ÖlExtractor_Zu.Enabled = false;
                }

                //Sporenpresse
                if (SporenPod && Strom)
                {
                    Sporenpresse_Zu.ReadOnly = false;
                    Sporenpresse_Zu.Enabled = true;
                }
                else
                {
                    Sporenpresse_Zu.ReadOnly = true;
                    Sporenpresse_Zu.Enabled = false;
                }

                //Pulverisierer
                if (Schrott && Strom)
                {
                    Pulverisierer_Zu.ReadOnly = false;
                    Pulverisierer_Zu.Enabled = true;
                }
                else
                {
                    Pulverisierer_Zu.ReadOnly = true;
                    Pulverisierer_Zu.Enabled = false;
                }

                //Kohlenzentriefuge
                if (Öl && Strom)
                {
                    Kohlenzentriefuge_Zu.ReadOnly = false;
                    Kohlenzentriefuge_Zu.Enabled = true;
                }
                else
                {
                    Kohlenzentriefuge_Zu.ReadOnly = true;
                    Kohlenzentriefuge_Zu.Enabled = false;
                }

                //Kryoflüssigkeitsmixer
                if (Titan && Wasser && Strom)
                {
                    Kryoflüssigkeitsmixer_Zu.ReadOnly = false;
                    Kryoflüssigkeitsmixer_Zu.Enabled = true;
                }
                else
                {
                    Kryoflüssigkeitsmixer_Zu.ReadOnly = true;
                    Kryoflüssigkeitsmixer_Zu.Enabled = false;
                }

                //Schmelzer
                if (Schrott && Strom)
                {
                    Schmelzer_Zu.ReadOnly = false;
                    Schmelzer_Zu.Enabled = true;
                }
                else
                {
                    Schmelzer_Zu.ReadOnly = true;
                    Schmelzer_Zu.Enabled = false;
                }

                //Trenner
                if (Schrott && Strom)
                {
                    Trenner_Zu.ReadOnly = false;
                    Trenner_Zu.Enabled = true;
                }
                else
                {
                    Trenner_Zu.ReadOnly = true;
                    Trenner_Zu.Enabled = false;
                }

                //Großer - Trenner
                if (Schrott && Strom)
                {
                    GroßerTrenner_Zu.ReadOnly = false;
                    GroßerTrenner_Zu.Enabled = true;
                }
                else
                {
                    GroßerTrenner_Zu.ReadOnly = true;
                    GroßerTrenner_Zu.Enabled = false;
                }


                //Verbrennungsgenerator
                if (Kohle || SporenPod || Pyratit || ExplosiveMischung)
                {
                    Verbrennungsgenerator_Zu.ReadOnly = false;
                    Verbrennungsgenerator_Zu.Enabled = true;
                    //Energie
                    Verbrennungsgenerator_Energie.Items.Clear();
                    if (Kohle)
                    {
                        Verbrennungsgenerator_Energie.Items.Add(s_Kohle);
                    }
                    if (SporenPod)
                    {
                        Verbrennungsgenerator_Energie.Items.Add(s_SporenPod);
                    }
                    if (Pyratit)
                    {
                        Verbrennungsgenerator_Energie.Items.Add(s_Pyratit);
                    }
                    if (ExplosiveMischung)
                    {
                        Verbrennungsgenerator_Energie.Items.Add(s_ExplosiveMischung);
                    }
                }
                else
                {
                    Verbrennungsgenerator_Zu.ReadOnly = true;
                    Verbrennungsgenerator_Zu.Enabled = false;
                    Verbrennungsgenerator_Energie.Items.Clear();
                }

                //Turbinengenerator
                if ((Kohle || SporenPod || Pyratit || ExplosiveMischung) && Wasser)
                {
                    Turbinengenerator_Zu.ReadOnly = false;
                    Turbinengenerator_Zu.Enabled = true;
                    //Energie
                    Turbinengenerator_Energie.Items.Clear();
                    if (Kohle)
                    {
                        Turbinengenerator_Energie.Items.Add(s_Kohle);
                    }
                    if (SporenPod)
                    {
                        Turbinengenerator_Energie.Items.Add(s_SporenPod);
                    }
                    if (Pyratit)
                    {
                        Turbinengenerator_Energie.Items.Add(s_Pyratit);
                    }
                    if (ExplosiveMischung)
                    {
                        Turbinengenerator_Energie.Items.Add(s_ExplosiveMischung);
                    }
                }
                else
                {
                    Turbinengenerator_Zu.ReadOnly = true;
                    Turbinengenerator_Zu.Enabled = false;
                    Turbinengenerator_Energie.Items.Clear();
                }

                //Differenzialgenerator
                if (Pyratit && Kryoflüssigkeit)
                {
                    Differenzialgenerator_Zu.ReadOnly = false;
                    Differenzialgenerator_Zu.Enabled = true;
                }
                else
                {
                    Differenzialgenerator_Zu.ReadOnly = true;
                    Differenzialgenerator_Zu.Enabled = false;
                }

                //RTG - Generator
                if (Thorium || Phasengewebe)
                {
                    RTGGenerator_Zu.ReadOnly = false;
                    RTGGenerator_Zu.Enabled = true;
                    RTGGenerator_Energie.Items.Clear();
                    if (Thorium)
                    {
                        RTGGenerator_Energie.Items.Add(s_Thorium);
                    }
                    if (Phasengewebe)
                    {
                        RTGGenerator_Energie.Items.Add(s_Phasengewebe);
                    }
                }
                else
                {
                    RTGGenerator_Zu.ReadOnly = true;
                    RTGGenerator_Zu.Enabled = false;
                    RTGGenerator_Energie.Items.Clear();
                }

                //Thorium - Reaktor
                if (Thorium && Kryoflüssigkeit)
                {
                    ThoriumReaktor_Zu.ReadOnly = false;
                    ThoriumReaktor_Zu.Enabled = true;
                }
                else
                {
                    ThoriumReaktor_Zu.ReadOnly = true;
                    ThoriumReaktor_Zu.Enabled = false;
                }

                //Schlaggenerator
                if (ExplosiveMischung && Kryoflüssigkeit && Strom)
                {
                    Schlaggenerator_Zu.ReadOnly = false;
                    Schlaggenerator_Zu.Enabled = true;
                }
                else
                {
                    Schlaggenerator_Zu.ReadOnly = true;
                    Schlaggenerator_Zu.Enabled = false;
                }

            }

            //Schutzmaßnahmen
            {
                //Reparateur
                if (Silizium && Strom)
                {
                    Reparateur_Zu.ReadOnly = false;
                    Reparateur_Zu.Enabled = true;
                }
                else
                {
                    Reparateur_Zu.ReadOnly = true;
                    Reparateur_Zu.Enabled = false;
                }

                //Reparaturprojektor
                if (Phasengewebe && Strom)
                {
                    Reparaturprojektor_Zu.ReadOnly = false;
                    Reparaturprojektor_Zu.Enabled = true;
                }
                else
                {
                    Reparaturprojektor_Zu.ReadOnly = true;
                    Reparaturprojektor_Zu.Enabled = false;
                }

                //Beschleunigungs - Projektor
                if (Phasengewebe && Strom)
                {
                    BeschleunigungsProjektor_Zu.ReadOnly = false;
                    BeschleunigungsProjektor_Zu.Enabled = true;
                }
                else
                {
                    BeschleunigungsProjektor_Zu.ReadOnly = true;
                    BeschleunigungsProjektor_Zu.Enabled = false;
                }

                //Beschleunigungs - Maschine
                if (Silizium && Phasengewebe && Strom)
                {
                    BeschleunigungsMaschine_Zu.ReadOnly = false;
                    BeschleunigungsMaschine_Zu.Enabled = true;
                }
                else
                {
                    BeschleunigungsMaschine_Zu.ReadOnly = true;
                    BeschleunigungsMaschine_Zu.Enabled = false;
                }

                //Kraftfeld - Projektor
                if (Phasengewebe && Strom)// && (Wasser || Kryoflüssigkeit))
                {
                    KraftfeldProjektor_Zu.ReadOnly = false;
                    KraftfeldProjektor_Zu.Enabled = true;
                    //Versterkung
                    KraftfeldProjektor_Versterkung.Items.Clear();
                    KraftfeldProjektor_Versterkung.Items.Add(s_Keine_Versterkung);
                    if (Phasengewebe)
                    {
                        KraftfeldProjektor_Versterkung.Items.Add("Verstärkung");
                    }
                    //Kühlung
                    KraftfeldProjektor_Kühlung.Items.Clear();
                    KraftfeldProjektor_Kühlung.Items.Add(s_Keine_Kühlung);
                    if (Wasser)
                    {
                        KraftfeldProjektor_Kühlung.Items.Add(s_Wasser);
                    }
                    if (Kryoflüssigkeit)
                    {
                        KraftfeldProjektor_Kühlung.Items.Add(s_Kryoflüssigkeit);
                    }
                }
                else
                {
                    KraftfeldProjektor_Zu.ReadOnly = true;
                    KraftfeldProjektor_Zu.Enabled = false;
                    //Versterkung
                    KraftfeldProjektor_Versterkung.Items.Clear();
                    //Kühlung
                    KraftfeldProjektor_Kühlung.Items.Clear();
                }

                //Kupfermauer
                if (Kupfer)
                {
                    Kupfermauer_Zu.ReadOnly = false;
                    Kupfermauer_Zu.Enabled = true;
                }
                else
                {
                    Kupfermauer_Zu.ReadOnly = true;
                    Kupfermauer_Zu.Enabled = false;
                }

                //Große - Kupfermauer
                if (Kupfer)
                {
                    GroßeKupfermauer_Zu.ReadOnly = false;
                    GroßeKupfermauer_Zu.Enabled = true;
                }
                else
                {
                    GroßeKupfermauer_Zu.ReadOnly = true;
                    GroßeKupfermauer_Zu.Enabled = false;
                }

                //Titanmauer
                if (Titan)
                {
                    Titanmauer_Zu.ReadOnly = false;
                    Titanmauer_Zu.Enabled = true;
                }
                else
                {
                    Titanmauer_Zu.ReadOnly = true;
                    Titanmauer_Zu.Enabled = false;
                }

                //Große - Titanmauer
                if (Titan)
                {
                    GroßeTitanmauer_Zu.ReadOnly = false;
                    GroßeTitanmauer_Zu.Enabled = true;
                }
                else
                {
                    GroßeTitanmauer_Zu.ReadOnly = true;
                    GroßeTitanmauer_Zu.Enabled = false;
                }

                //Thoriummauer
                if (Thorium)
                {
                    Thoriummauer_Zu.ReadOnly = false;
                    Thoriummauer_Zu.Enabled = true;
                }
                else
                {
                    Thoriummauer_Zu.ReadOnly = true;
                    Thoriummauer_Zu.Enabled = false;
                }

                //Große - Thoriummauer
                if (Thorium)
                {
                    GroßeThoriummauer_Zu.ReadOnly = false;
                    GroßeThoriummauer_Zu.Enabled = true;
                }
                else
                {
                    GroßeThoriummauer_Zu.ReadOnly = true;
                    GroßeThoriummauer_Zu.Enabled = false;
                }

                //Phasenmauer
                if (Phasengewebe)
                {
                    Phasenmauer_Zu.ReadOnly = false;
                    Phasenmauer_Zu.Enabled = true;
                }
                else
                {
                    Phasenmauer_Zu.ReadOnly = true;
                    Phasenmauer_Zu.Enabled = false;
                }

                //Große - Phasenmauer
                if (Phasengewebe)
                {
                    GroßePhasenmauer_Zu.ReadOnly = false;
                    GroßePhasenmauer_Zu.Enabled = true;
                }
                else
                {
                    GroßePhasenmauer_Zu.ReadOnly = true;
                    GroßePhasenmauer_Zu.Enabled = false;
                }

                //Spannungsmauer
                if (Spannungslegierung)
                {
                    Spannungsmauer_Zu.ReadOnly = false;
                    Spannungsmauer_Zu.Enabled = true;
                }
                else
                {
                    Spannungsmauer_Zu.ReadOnly = true;
                    Spannungsmauer_Zu.Enabled = false;
                }

                //Große - Spannungsmauer
                if (Spannungslegierung)
                {
                    GroßeSpannungsmauer_Zu.ReadOnly = false;
                    GroßeSpannungsmauer_Zu.Enabled = true;
                }
                else
                {
                    GroßeSpannungsmauer_Zu.ReadOnly = true;
                    GroßeSpannungsmauer_Zu.Enabled = false;
                }

                //Plastaniummauer
                if (Plastanium && Metaglas)
                {
                    Plastaniummauer_Zu.ReadOnly = false;
                    Plastaniummauer_Zu.Enabled = true;
                }
                else
                {
                    Plastaniummauer_Zu.ReadOnly = true;
                    Plastaniummauer_Zu.Enabled = false;
                }

                //Große - Plastaniummauer
                if (Plastanium && Metaglas)
                {
                    GroßePlastaniummauer_Zu.ReadOnly = false;
                    GroßePlastaniummauer_Zu.Enabled = true;
                }
                else
                {
                    GroßePlastaniummauer_Zu.ReadOnly = true;
                    GroßePlastaniummauer_Zu.Enabled = false;
                }

                //Tor
                if (Titan && Silizium)
                {
                    Tor_Zu.ReadOnly = false;
                    Tor_Zu.Enabled = true;
                }
                else
                {
                    Tor_Zu.ReadOnly = true;
                    Tor_Zu.Enabled = false;
                }

                //Großes - Tor
                if (Titan && Silizium)
                {
                    GroßesTor_Zu.ReadOnly = false;
                    GroßesTor_Zu.Enabled = true;
                }
                else
                {
                    GroßesTor_Zu.ReadOnly = true;
                    GroßesTor_Zu.Enabled = false;
                }


                //Doppelgeschütz
                if (Kupfer || Grafit || Silizium)
                {
                    Doppelgeschütz_Zu.ReadOnly = false;
                    Doppelgeschütz_Zu.Enabled = true;
                    //Munition
                    Doppelgeschütz_Munition.Items.Clear();
                    if (Kupfer)
                    {
                        Doppelgeschütz_Munition.Items.Add(s_Kupfer);
                    }
                    if (Grafit)
                    {
                        Doppelgeschütz_Munition.Items.Add(s_Grafit);
                    }
                    if (Silizium)
                    {
                        Doppelgeschütz_Munition.Items.Add(s_Silizium);
                    }
                    //Kühlung
                    Doppelgeschütz_Kühlung.Items.Clear();
                    Doppelgeschütz_Kühlung.Items.Add(s_Keine_Kühlung);
                    if (Wasser)
                    {
                        Doppelgeschütz_Kühlung.Items.Add(s_Wasser);
                    }
                    if (Kryoflüssigkeit)
                    {
                        Doppelgeschütz_Kühlung.Items.Add(s_Kryoflüssigkeit);
                    }
                }
                else
                {
                    Doppelgeschütz_Zu.ReadOnly = true;
                    Doppelgeschütz_Zu.Enabled = false;
                    Doppelgeschütz_Munition.Items.Clear();
                    Doppelgeschütz_Kühlung.Items.Clear();
                }

                //Luftgeschütz
                if (Blei || Schrott || Metaglas)
                {
                    Luftgeschütz_Zu.ReadOnly = false;
                    Luftgeschütz_Zu.Enabled = true;
                    //Munition
                    Luftgeschütz_Munition.Items.Clear();
                    if (Blei)
                    {
                        Luftgeschütz_Munition.Items.Add(s_Blei);
                    }
                    if (Schrott)
                    {
                        Luftgeschütz_Munition.Items.Add("Schrott");
                    }
                    if (Metaglas)
                    {
                        Luftgeschütz_Munition.Items.Add(s_Metaglas);
                    }
                    //Kühlung
                    Luftgeschütz_Kühlung.Items.Clear();
                    Luftgeschütz_Kühlung.Items.Add(s_Keine_Kühlung);
                    if (Wasser)
                    {
                        Luftgeschütz_Kühlung.Items.Add(s_Wasser);
                    }
                    if (Kryoflüssigkeit)
                    {
                        Luftgeschütz_Kühlung.Items.Add(s_Kryoflüssigkeit);
                    }
                }
                else
                {
                    Luftgeschütz_Zu.ReadOnly = true;
                    Luftgeschütz_Zu.Enabled = false;
                    Luftgeschütz_Munition.Items.Clear();
                    Luftgeschütz_Kühlung.Items.Clear();
                }

                //Scatter
                if (Kohle || Pyratit)
                {
                    Scatter_Zu.ReadOnly = false;
                    Scatter_Zu.Enabled = true;
                    //Munition
                    Scatter_Munition.Items.Clear();
                    if (Kohle)
                    {
                        Scatter_Munition.Items.Add(s_Kohle);
                    }
                    if (Pyratit)
                    {
                        Scatter_Munition.Items.Add(s_Pyratit);
                    }
                    //Kühlung
                    Scatter_Kühlung.Items.Clear();
                    Scatter_Kühlung.Items.Add(s_Keine_Kühlung);
                    if (Wasser)
                    {
                        Scatter_Kühlung.Items.Add(s_Wasser);
                    }
                    if (Kryoflüssigkeit)
                    {
                        Scatter_Kühlung.Items.Add(s_Kryoflüssigkeit);
                    }
                }
                else
                {
                    Scatter_Zu.ReadOnly = true;
                    Scatter_Zu.Enabled = false;
                    Scatter_Munition.Items.Clear();
                    Scatter_Kühlung.Items.Clear();
                }


                //Hail
                if (Grafit || Silizium || Pyratit)
                {
                    Hail_Zu.ReadOnly = false;
                    Hail_Zu.Enabled = true;
                    //Munition
                    Hail_Munition.Items.Clear();
                    if (Grafit)
                    {
                        Hail_Munition.Items.Add(s_Grafit);
                    }
                    if (Silizium)
                    {
                        Hail_Munition.Items.Add(s_Silizium);
                    }
                    if (Pyratit)
                    {
                        Hail_Munition.Items.Add(s_Pyratit);
                    }
                    //Kühlung
                    Hail_Kühlung.Items.Clear();
                    Hail_Kühlung.Items.Add(s_Keine_Kühlung);
                    if (Wasser)
                    {
                        Hail_Kühlung.Items.Add(s_Wasser);
                    }
                    if (Kryoflüssigkeit)
                    {
                        Hail_Kühlung.Items.Add(s_Kryoflüssigkeit);
                    }
                }
                else
                {
                    Hail_Zu.ReadOnly = true;
                    Hail_Zu.Enabled = false;
                    Hail_Munition.Items.Clear();
                    Hail_Kühlung.Items.Clear();
                }

                //Welle
                if (Wasser || Kryoflüssigkeit || Öl || Schlacke)
                {
                    Welle_Zu.ReadOnly = false;
                    Welle_Zu.Enabled = true;
                    //Munition
                    Welle_Munition.Items.Clear();
                    if (Wasser)
                    {
                        Welle_Munition.Items.Add(s_Wasser);
                    }
                    if (Kryoflüssigkeit)
                    {
                        Welle_Munition.Items.Add(s_Kryoflüssigkeit);
                    }
                    if (Öl)
                    {
                        Welle_Munition.Items.Add(s_Öl);
                    }
                    if (Schlacke)
                    {
                        Welle_Munition.Items.Add(s_Schlacke);
                    }
                }
                else
                {
                    Welle_Zu.ReadOnly = true;
                    Welle_Zu.Enabled = false;
                    Welle_Munition.Items.Clear();
                }

                //Lancer
                if (Strom)
                {
                    Lancer_Zu.ReadOnly = false;
                    Lancer_Zu.Enabled = true;
                    //Kühlung
                    Lancer_Kühlung.Items.Clear();
                    Lancer_Kühlung.Items.Add(s_Keine_Kühlung);
                    if (Wasser)
                    {
                        Lancer_Kühlung.Items.Add(s_Wasser);
                    }
                    if (Kryoflüssigkeit)
                    {
                        Lancer_Kühlung.Items.Add(s_Kryoflüssigkeit);
                    }
                }
                else
                {
                    Lancer_Zu.ReadOnly = true;
                    Lancer_Zu.Enabled = false;
                    Lancer_Kühlung.Items.Clear();
                }

                //Arcus
                if (Strom)
                {
                    Arcus_Zu.ReadOnly = false;
                    Arcus_Zu.Enabled = true;
                    //Kühlung
                    Arcus_Kühlung.Items.Clear();
                    Arcus_Kühlung.Items.Add(s_Keine_Kühlung);
                    if (Wasser)
                    {
                        Arcus_Kühlung.Items.Add(s_Wasser);
                    }
                    if (Kryoflüssigkeit)
                    {
                        Arcus_Kühlung.Items.Add(s_Kryoflüssigkeit);
                    }
                }
                else
                {
                    Arcus_Zu.ReadOnly = true;
                    Arcus_Zu.Enabled = false;
                    Arcus_Kühlung.Items.Clear();
                }

                //Parallax
                if (Strom)
                {
                    Parallax_Zu.ReadOnly = false;
                    Parallax_Zu.Enabled = true;
                }
                else
                {
                    Parallax_Zu.ReadOnly = true;
                    Parallax_Zu.Enabled = false;
                }

                //Schwärmer
                if (Pyratit || ExplosiveMischung || Spannungslegierung)
                {
                    Schwärmer_Zu.ReadOnly = false;
                    Schwärmer_Zu.Enabled = true;
                    //Munition
                    Schwärmer_Munition.Items.Clear();
                    if (Pyratit)
                    {
                        Schwärmer_Munition.Items.Add(s_Pyratit);
                    }
                    if (ExplosiveMischung)
                    {
                        Schwärmer_Munition.Items.Add(s_ExplosiveMischung);
                    }
                    if (Spannungslegierung)
                    {
                        Schwärmer_Munition.Items.Add(s_Spannungslegierung);
                    }
                    //Kühlung
                    Schwärmer_Kühlung.Items.Clear();
                    Schwärmer_Kühlung.Items.Add(s_Keine_Kühlung);
                    if (Wasser)
                    {
                        Schwärmer_Kühlung.Items.Add(s_Wasser);
                    }
                    if (Kryoflüssigkeit)
                    {
                        Schwärmer_Kühlung.Items.Add(s_Kryoflüssigkeit);
                    }
                }
                else
                {
                    Schwärmer_Zu.ReadOnly = true;
                    Schwärmer_Zu.Enabled = false;
                    Schwärmer_Munition.Items.Clear();
                    Schwärmer_Kühlung.Items.Clear();
                }

                //Salve
                if (Kupfer || Thorium || Grafit || Silizium || Pyratit)
                {
                    Salve_Zu.ReadOnly = false;
                    Salve_Zu.Enabled = true;
                    //Munition
                    Salve_Munition.Items.Clear();
                    if (Kupfer)
                    {
                        Salve_Munition.Items.Add(s_Kupfer);
                    }
                    if (Thorium)
                    {
                        Salve_Munition.Items.Add(s_Thorium);
                    }
                    if (Grafit)
                    {
                        Salve_Munition.Items.Add(s_Grafit);
                    }
                    if (Silizium)
                    {
                        Salve_Munition.Items.Add(s_Silizium);
                    }
                    if (Pyratit)
                    {
                        Salve_Munition.Items.Add(s_Pyratit);
                    }
                    //Kühlung
                    Salve_Kühlung.Items.Clear();
                    Salve_Kühlung.Items.Add(s_Keine_Kühlung);
                    if (Wasser)
                    {
                        Salve_Kühlung.Items.Add(s_Wasser);
                    }
                    if (Kryoflüssigkeit)
                    {
                        Salve_Kühlung.Items.Add(s_Kryoflüssigkeit);
                    }
                }
                else
                {
                    Salve_Zu.ReadOnly = true;
                    Salve_Zu.Enabled = false;
                    Salve_Munition.Items.Clear();
                    Salve_Kühlung.Items.Clear();
                }

                //Segment
                if (Strom)
                {
                    Segment_Zu.ReadOnly = false;
                    Segment_Zu.Enabled = true;
                }
                else
                {
                    Segment_Zu.ReadOnly = true;
                    Segment_Zu.Enabled = false;
                }

                //Tsunami
                if (Wasser || Kryoflüssigkeit || Öl || Schlacke)
                {
                    Tsunami_Zu.ReadOnly = false;
                    Tsunami_Zu.Enabled = true;
                    //Munition
                    Tsunami_Munition.Items.Clear();
                    if (Wasser)
                    {
                        Tsunami_Munition.Items.Add(s_Wasser);
                    }
                    if (Kryoflüssigkeit)
                    {
                        Tsunami_Munition.Items.Add(s_Kryoflüssigkeit);
                    }
                    if (Öl)
                    {
                        Tsunami_Munition.Items.Add(s_Öl);
                    }
                    if (Schlacke)
                    {
                        Tsunami_Munition.Items.Add(s_Schlacke);
                    }
                }
                else
                {
                    Tsunami_Zu.ReadOnly = true;
                    Tsunami_Zu.Enabled = false;
                }

                //Zünder
                if (Thorium || Titan)
                {
                    Zünder_Zu.ReadOnly = false;
                    Zünder_Zu.Enabled = true;
                    //Munition
                    Zünder_Munition.Items.Clear();
                    if (Thorium)
                    {
                        Zünder_Munition.Items.Add(s_Thorium);
                    }
                    if (Titan)
                    {
                        Zünder_Munition.Items.Add(s_Titan);
                    }
                    //Kühlung
                    Zünder_Kühlung.Items.Clear();
                    Zünder_Kühlung.Items.Add(s_Keine_Kühlung);
                    if (Wasser)
                    {
                        Zünder_Kühlung.Items.Add(s_Wasser);
                    }
                    if (Kryoflüssigkeit)
                    {
                        Zünder_Kühlung.Items.Add(s_Kryoflüssigkeit);
                    }
                }
                else
                {
                    Zünder_Zu.ReadOnly = true;
                    Zünder_Zu.Enabled = false;
                    Zünder_Munition.Items.Clear();
                    Zünder_Kühlung.Items.Clear();
                }

                //Zerstörer
                if (Grafit || Silizium || Pyratit || ExplosiveMischung || Plastanium)
                {
                    Zerstörer_Zu.ReadOnly = false;
                    Zerstörer_Zu.Enabled = true;
                    //Munition
                    Zerstörer_Munition.Items.Clear();
                    if (Grafit)
                    {
                        Zerstörer_Munition.Items.Add(s_Grafit);
                    }
                    if (Silizium)
                    {
                        Zerstörer_Munition.Items.Add(s_Silizium);
                    }
                    if (Pyratit)
                    {
                        Zerstörer_Munition.Items.Add(s_Pyratit);
                    }
                    if (ExplosiveMischung)
                    {
                        Zerstörer_Munition.Items.Add(s_ExplosiveMischung);
                    }
                    if (Plastanium)
                    {
                        Zerstörer_Munition.Items.Add(s_Plastanium);
                    }
                    //Kühlung
                    Zerstörer_Kühlung.Items.Clear();
                    Zerstörer_Kühlung.Items.Add(s_Keine_Kühlung);
                    if (Wasser)
                    {
                        Zerstörer_Kühlung.Items.Add(s_Wasser);
                    }
                    if (Kryoflüssigkeit)
                    {
                        Zerstörer_Kühlung.Items.Add(s_Kryoflüssigkeit);
                    }
                }
                else
                {
                    Zerstörer_Zu.ReadOnly = true;
                    Zerstörer_Zu.Enabled = false;
                    Zerstörer_Munition.Items.Clear();
                    Zerstörer_Kühlung.Items.Clear();
                }

                //Zyklon
                if (Metaglas || ExplosiveMischung || Plastanium || Spannungslegierung)
                {
                    Zyklon_Zu.ReadOnly = false;
                    Zyklon_Zu.Enabled = true;
                    //Munition
                    Zyklon_Munition.Items.Clear();
                    if (Metaglas)
                    {
                        Zyklon_Munition.Items.Add(s_Metaglas);
                    }
                    if (ExplosiveMischung)
                    {
                        Zyklon_Munition.Items.Add(s_ExplosiveMischung);
                    }
                    if (Plastanium)
                    {
                        Zyklon_Munition.Items.Add(s_Plastanium);
                    }
                    if (Spannungslegierung)
                    {
                        Zyklon_Munition.Items.Add(s_Spannungslegierung);
                    }
                    //Kühlung
                    Zyklon_Kühlung.Items.Clear();
                    Zyklon_Kühlung.Items.Add(s_Keine_Kühlung);
                    if (Wasser)
                    {
                        Zyklon_Kühlung.Items.Add(s_Wasser);
                    }
                    if (Kryoflüssigkeit)
                    {
                        Zyklon_Kühlung.Items.Add(s_Kryoflüssigkeit);
                    }
                }
                else
                {
                    Zyklon_Zu.ReadOnly = true;
                    Zyklon_Zu.Enabled = false;
                    Zyklon_Munition.Items.Clear();
                    Zyklon_Kühlung.Items.Clear();
                }

                //Foreshadow
                if (Spannungslegierung && Strom)
                {
                    Foreshadow_Zu.ReadOnly = false;
                    Foreshadow_Zu.Enabled = true;
                    //Kühlung
                    Foreshadow_Kühlung.Items.Clear();
                    Foreshadow_Kühlung.Items.Add(s_Keine_Kühlung);
                    if (Wasser)
                    {
                        Foreshadow_Kühlung.Items.Add(s_Wasser);
                    }
                    if (Kryoflüssigkeit)
                    {
                        Foreshadow_Kühlung.Items.Add(s_Kryoflüssigkeit);
                    }
                }
                else
                {
                    Foreshadow_Zu.ReadOnly = true;
                    Foreshadow_Zu.Enabled = false;
                    Foreshadow_Kühlung.Items.Clear();
                }

                //Phantom
                if (Thorium || Grafit || Pyratit)
                {
                    Phantom_Zu.ReadOnly = false;
                    Phantom_Zu.Enabled = true;
                    //Munition
                    Phantom_Munition.Items.Clear();
                    if (Thorium)
                    {
                        Phantom_Munition.Items.Add(s_Thorium);
                    }
                    if (Grafit)
                    {
                        Phantom_Munition.Items.Add(s_Grafit);
                    }
                    if (Pyratit)
                    {
                        Phantom_Munition.Items.Add(s_Pyratit);
                    }
                    //Kühlung
                    Phantom_Kühlung.Items.Clear();
                    Phantom_Kühlung.Items.Add(s_Keine_Kühlung);
                    if (Wasser)
                    {
                        Phantom_Kühlung.Items.Add(s_Wasser);
                    }
                    if (Kryoflüssigkeit)
                    {
                        Phantom_Kühlung.Items.Add(s_Kryoflüssigkeit);
                    }
                }
                else
                {
                    Phantom_Zu.ReadOnly = true;
                    Phantom_Zu.Enabled = false;
                    Phantom_Munition.Items.Clear();
                    Phantom_Kühlung.Items.Clear();
                }

                //Meltdown
                if (Strom && (Wasser || Kryoflüssigkeit))
                {
                    Meltdown_Zu.ReadOnly = false;
                    Meltdown_Zu.Enabled = true;
                    //Kühlung
                    Meltdown_Kühlung.Items.Clear();
                    if (Wasser)
                    {
                        Meltdown_Kühlung.Items.Add(s_Wasser);
                    }
                    if (Kryoflüssigkeit)
                    {
                        Meltdown_Kühlung.Items.Add(s_Kryoflüssigkeit);
                    }
                }
                else
                {
                    Meltdown_Zu.ReadOnly = true;
                    Meltdown_Zu.Enabled = false;
                    Meltdown_Kühlung.Items.Clear();
                }
            }

            //Truppen
            {
                bool Hinzufügender, Multiplikativer, Exponenzieller, Tretrativer;

                //Dagger
                if (Blei && Silizium && Strom)
                {
                    Dagger_Zu.ReadOnly = false;
                    Dagger_Zu.Enabled = true;
                }
                else
                {
                    Dagger_Zu.ReadOnly = true;
                    Dagger_Zu.Enabled = false;
                }

                //Nova
                if (Blei && Silizium && Titan && Strom)
                {
                    Nova_Zu.ReadOnly = false;
                    Nova_Zu.Enabled = true;
                }
                else
                {
                    Nova_Zu.ReadOnly = true;
                    Nova_Zu.Enabled = false;
                }

                //Crawler
                if (Kohle && Silizium && Strom)
                {
                    Crawler_Zu.ReadOnly = false;
                    Crawler_Zu.Enabled = true;
                }
                else
                {
                    Crawler_Zu.ReadOnly = true;
                    Crawler_Zu.Enabled = false;
                }

                //Bodenfabrik
                if (Strom && (Dagger_Zu.ReadOnly == false || Nova_Zu.ReadOnly == false || Crawler_Zu.ReadOnly == false))
                {
                    Bodenfabrik_Zu.ReadOnly = false;
                    Bodenfabrik_Zu.Enabled = true;
                }
                else
                {
                    Bodenfabrik_Zu.ReadOnly = true;
                    Bodenfabrik_Zu.Enabled = false;
                }

                //Flare
                if (Silizium && Strom)
                {
                    Flare_Zu.ReadOnly = false;
                    Flare_Zu.Enabled = true;
                }
                else
                {
                    Flare_Zu.ReadOnly = true;
                    Flare_Zu.Enabled = false;
                }

                //Mono
                if (Blei && Silizium && Strom)
                {
                    Mono_Zu.ReadOnly = false;
                    Mono_Zu.Enabled = true;
                }
                else
                {
                    Mono_Zu.ReadOnly = true;
                    Mono_Zu.Enabled = false;
                }

                //Luftfabrik
                if (Strom && (Flare_Zu.ReadOnly == false || Mono_Zu.ReadOnly == false))
                {
                    Luftfabrik_Zu.ReadOnly = false;
                    Luftfabrik_Zu.Enabled = true;
                }
                else
                {
                    Luftfabrik_Zu.ReadOnly = true;
                    Luftfabrik_Zu.Enabled = false;
                }

                //Risso
                if (Metaglas && Silizium && Strom)
                {
                    Risso_Zu.ReadOnly = false;
                    Risso_Zu.Enabled = true;
                }
                else
                {
                    Risso_Zu.ReadOnly = true;
                    Risso_Zu.Enabled = false;
                }

                //Retusa
                if (Metaglas && Silizium && Titan && Strom)
                {
                    Retusa_Zu.ReadOnly = false;
                    Retusa_Zu.Enabled = true;
                }
                else
                {
                    Retusa_Zu.ReadOnly = true;
                    Retusa_Zu.Enabled = false;
                }

                //Wasserfabrik
                if (Strom && (Risso_Zu.ReadOnly == false || Retusa_Zu.ReadOnly == false))
                {
                    Wasserfabrik_Zu.ReadOnly = false;
                    Wasserfabrik_Zu.Enabled = true;
                }
                else
                {
                    Wasserfabrik_Zu.ReadOnly = true;
                    Wasserfabrik_Zu.Enabled = false;
                }

                //Hinzufügender - Rekonstrukeur
                if (Bodenfabrik_Zu.ReadOnly == false || Luftfabrik_Zu.ReadOnly == false || Wasserfabrik_Zu.ReadOnly == false && Grafit)
                {
                    HinzufügenderRekonstrukeur_Zu.ReadOnly = false;
                    HinzufügenderRekonstrukeur_Zu.Enabled = true;
                    Hinzufügender = true;
                }
                else
                {
                    HinzufügenderRekonstrukeur_Zu.ReadOnly = true;
                    HinzufügenderRekonstrukeur_Zu.Enabled = false;
                    Hinzufügender = false;
                }

                //Multiplikativer - Rekonstrukeur
                if (Hinzufügender && Titan && Metaglas)
                {
                    MultiplikativerRekonstrukeur_Zu.ReadOnly = false;
                    MultiplikativerRekonstrukeur_Zu.Enabled = true;
                    Multiplikativer = true;
                }
                else
                {
                    MultiplikativerRekonstrukeur_Zu.ReadOnly = true;
                    MultiplikativerRekonstrukeur_Zu.Enabled = false;
                    Multiplikativer = false;
                }

                //Exponenzieller - Rekonstrukeur
                if (Multiplikativer && Plastanium && Kryoflüssigkeit)
                {
                    ExponenziellerRekonstrukeur_Zu.ReadOnly = false;
                    ExponenziellerRekonstrukeur_Zu.Enabled = true;
                    Exponenzieller = true;
                }
                else
                {
                    ExponenziellerRekonstrukeur_Zu.ReadOnly = true;
                    ExponenziellerRekonstrukeur_Zu.Enabled = false;
                    Exponenzieller = false;
                }

                //Tretrativer - Rekonstrukeur
                if (Exponenzieller && Phasengewebe && Spannungslegierung)
                {
                    TretrativerRekonstrukeur_Zu.ReadOnly = false;
                    TretrativerRekonstrukeur_Zu.Enabled = true;
                    Tretrativer = true;
                }
                else
                {
                    TretrativerRekonstrukeur_Zu.ReadOnly = true;
                    TretrativerRekonstrukeur_Zu.Enabled = false;
                    Tretrativer = false;
                }

                //Reparaturpunkt
                if (Strom)
                {
                    Reparaturpunkt_Zu.ReadOnly = false;
                    Reparaturpunkt_Zu.Enabled = true;
                }
                else
                {
                    Reparaturpunkt_Zu.ReadOnly = true;
                    Reparaturpunkt_Zu.Enabled = false;
                }

                //Reparaturstation
                if (Strom)
                {
                    Reparaturstation_Zu.ReadOnly = false;
                    Reparaturstation_Zu.Enabled = true;
                    Reparaturstation_Kühlung.Items.Clear();
                    Reparaturstation_Kühlung.Items.Add(s_Keine_Kühlung);
                    if (Wasser)
                    {
                        Reparaturstation_Kühlung.Items.Add(s_Wasser);
                    }
                    if (Kryoflüssigkeit)
                    {
                        Reparaturstation_Kühlung.Items.Add(s_Kryoflüssigkeit);
                    }
                }
                else
                {
                    Reparaturstation_Zu.ReadOnly = true;
                    Reparaturstation_Zu.Enabled = false;
                    Reparaturstation_Kühlung.Items.Clear();
                }

                //Mace
                if (Hinzufügender)
                {
                    Mace_Zu.ReadOnly = false;
                    Mace_Zu.Enabled = true;
                }
                else
                {
                    Mace_Zu.ReadOnly = true;
                    Mace_Zu.Enabled = false;
                }

                //Fortress
                if (Multiplikativer)
                {
                    Fortress_Zu.ReadOnly = false;
                    Fortress_Zu.Enabled = true;
                }
                else
                {
                    Fortress_Zu.ReadOnly = true;
                    Fortress_Zu.Enabled = false;
                }

                //Scepter
                if (Exponenzieller)
                {
                    Scepter_Zu.ReadOnly = false;
                    Scepter_Zu.Enabled = true;
                }
                else
                {
                    Scepter_Zu.ReadOnly = true;
                    Scepter_Zu.Enabled = false;
                }

                //Reign
                if (Tretrativer)
                {
                    Reign_Zu.ReadOnly = false;
                    Reign_Zu.Enabled = true;
                }
                else
                {
                    Reign_Zu.ReadOnly = true;
                    Reign_Zu.Enabled = false;
                }

                //Pulsar
                if (Hinzufügender)
                {
                    Pulsar_Zu.ReadOnly = false;
                    Pulsar_Zu.Enabled = true;
                }
                else
                {
                    Pulsar_Zu.ReadOnly = true;
                    Pulsar_Zu.Enabled = false;
                }

                //Quasar
                if (Multiplikativer)
                {
                    Quasar_Zu.ReadOnly = false;
                    Quasar_Zu.Enabled = true;
                }
                else
                {
                    Quasar_Zu.ReadOnly = true;
                    Quasar_Zu.Enabled = false;
                }

                //Vela
                if (Exponenzieller)
                {
                    Vela_Zu.ReadOnly = false;
                    Vela_Zu.Enabled = true;
                }
                else
                {
                    Vela_Zu.ReadOnly = true;
                    Vela_Zu.Enabled = false;
                }

                //Korvus
                if (Tretrativer)
                {
                    Korvus_Zu.ReadOnly = false;
                    Korvus_Zu.Enabled = true;
                }
                else
                {
                    Korvus_Zu.ReadOnly = true;
                    Korvus_Zu.Enabled = false;
                }


                //Atrax
                if (Hinzufügender)
                {
                    Atrax_Zu.ReadOnly = false;
                    Atrax_Zu.Enabled = true;
                }
                else
                {
                    Atrax_Zu.ReadOnly = true;
                    Atrax_Zu.Enabled = false;
                }

                //Spirokt
                if (Multiplikativer)
                {
                    Spirokt_Zu.ReadOnly = false;
                    Spirokt_Zu.Enabled = true;
                }
                else
                {
                    Spirokt_Zu.ReadOnly = true;
                    Spirokt_Zu.Enabled = false;
                }

                //Arkyid
                if (Exponenzieller)
                {
                    Arkyid_Zu.ReadOnly = false;
                    Arkyid_Zu.Enabled = true;
                }
                else
                {
                    Arkyid_Zu.ReadOnly = true;
                    Arkyid_Zu.Enabled = false;
                }

                //Toxopid
                if (Tretrativer)
                {
                    Toxopid_Zu.ReadOnly = false;
                    Toxopid_Zu.Enabled = true;
                }
                else
                {
                    Toxopid_Zu.ReadOnly = true;
                    Toxopid_Zu.Enabled = false;
                }

                //Horizont
                if (Hinzufügender)
                {
                    Horizont_Zu.ReadOnly = false;
                    Horizont_Zu.Enabled = true;
                }
                else
                {
                    Horizont_Zu.ReadOnly = true;
                    Horizont_Zu.Enabled = false;
                }

                //Zenit
                if (Multiplikativer)
                {
                    Zenit_Zu.ReadOnly = false;
                    Zenit_Zu.Enabled = true;
                }
                else
                {
                    Zenit_Zu.ReadOnly = true;
                    Zenit_Zu.Enabled = false;
                }

                //Antumbra
                if (Exponenzieller)
                {
                    Antumbra_Zu.ReadOnly = false;
                    Antumbra_Zu.Enabled = true;
                }
                else
                {
                    Antumbra_Zu.ReadOnly = true;
                    Antumbra_Zu.Enabled = false;
                }

                //Eclipse
                if (Tretrativer)
                {
                    Eclipse_Zu.ReadOnly = false;
                    Eclipse_Zu.Enabled = true;
                }
                else
                {
                    Eclipse_Zu.ReadOnly = true;
                    Eclipse_Zu.Enabled = false;
                }

                //Poly
                if (Hinzufügender)
                {
                    Poly_Zu.ReadOnly = false;
                    Poly_Zu.Enabled = true;
                }
                else
                {
                    Poly_Zu.ReadOnly = true;
                    Poly_Zu.Enabled = false;
                }

                //Mega
                if (Multiplikativer)
                {
                    Mega_Zu.ReadOnly = false;
                    Mega_Zu.Enabled = true;
                }
                else
                {
                    Mega_Zu.ReadOnly = true;
                    Mega_Zu.Enabled = false;
                }

                //Quad
                if (Exponenzieller)
                {
                    Quad_Zu.ReadOnly = false;
                    Quad_Zu.Enabled = true;
                }
                else
                {
                    Quad_Zu.ReadOnly = true;
                    Quad_Zu.Enabled = false;
                }

                //Okt
                if (Tretrativer)
                {
                    Okt_Zu.ReadOnly = false;
                    Okt_Zu.Enabled = true;
                }
                else
                {
                    Okt_Zu.ReadOnly = true;
                    Okt_Zu.Enabled = false;
                }

                //Minke
                if (Hinzufügender)
                {
                    Minke_Zu.ReadOnly = false;
                    Minke_Zu.Enabled = true;
                }
                else
                {
                    Minke_Zu.ReadOnly = true;
                    Minke_Zu.Enabled = false;
                }

                //Bryde
                if (Multiplikativer)
                {
                    Bryde_Zu.ReadOnly = false;
                    Bryde_Zu.Enabled = true;
                }
                else
                {
                    Bryde_Zu.ReadOnly = true;
                    Bryde_Zu.Enabled = false;
                }

                //Sei
                if (Exponenzieller)
                {
                    Sei_Zu.ReadOnly = false;
                    Sei_Zu.Enabled = true;
                }
                else
                {
                    Sei_Zu.ReadOnly = true;
                    Sei_Zu.Enabled = false;
                }

                //Omura
                if (Tretrativer)
                {
                    Omura_Zu.ReadOnly = false;
                    Omura_Zu.Enabled = true;
                }
                else
                {
                    Omura_Zu.ReadOnly = true;
                    Omura_Zu.Enabled = false;
                }

                //Oxynoe
                if (Hinzufügender)
                {
                    Oxynoe_Zu.ReadOnly = false;
                    Oxynoe_Zu.Enabled = true;
                }
                else
                {
                    Oxynoe_Zu.ReadOnly = true;
                    Oxynoe_Zu.Enabled = false;
                }

                //Cyerce
                if (Multiplikativer)
                {
                    Cyerce_Zu.ReadOnly = false;
                    Cyerce_Zu.Enabled = true;
                }
                else
                {
                    Cyerce_Zu.ReadOnly = true;
                    Cyerce_Zu.Enabled = false;
                }

                //Aegires
                if (Exponenzieller)
                {
                    Aegires_Zu.ReadOnly = false;
                    Aegires_Zu.Enabled = true;
                }
                else
                {
                    Aegires_Zu.ReadOnly = true;
                    Aegires_Zu.Enabled = false;
                }

                //Navanax
                if (Tretrativer)
                {
                    Navanax_Zu.ReadOnly = false;
                    Navanax_Zu.Enabled = true;
                }
                else
                {
                    Navanax_Zu.ReadOnly = true;
                    Navanax_Zu.Enabled = false;
                }
            }

            //immer Aktiv nur einmal ausgeführt!
            if (!O_one_T)
            {
                //Thermischer - Generator
                ThermischerGenerator_Zu.ReadOnly = false;
                ThermischerGenerator_Zu.Enabled = true;

                //Solarpanel
                Solarpanel_Zu.ReadOnly = false;
                Solarpanel_Zu.Enabled = true;

                //Großes - Solarpanel
                GroßesSolarpanel_Zu.ReadOnly = false;
                GroßesSolarpanel_Zu.Enabled = true;

                //Strom
                Strom_Wunsch.ReadOnly = false;
                Strom_Wunsch.Enabled = true;

                //Batterie
                Batterie_Zu.ReadOnly = false;
                Batterie_Zu.Enabled = true;

                //Große - Batterie
                GroßeBatterie_Zu.ReadOnly = false;
                GroßeBatterie_Zu.Enabled = true;

                //Behälter
                Behälter_Zu.ReadOnly = false;
                Behälter_Zu.Enabled = true;

                //Tresor
                Tresor_Zu.ReadOnly = false;
                Tresor_Zu.Enabled = true;

                //Schock - Mine
                SchockMine_Zu.ReadOnly = false;
                SchockMine_Zu.Enabled = true;

                //Set Selection
                //Rohstoffabbau_Divider.Text = "Prozent %";
                //Rohstoffproduktion_Div.Text = "Prozent %";

                //Set Value
                //Bohrer
                //MBohrer_OW_Div.Value = 0;
                //MBohrer_MW_Div.Value = 0;
                //PBohrer_OW_Div.Value = 0;
                //PBohrer_MW_Div.Value = 0;
                //LBohrer_OW_Div.Value = 0;
                //LBohrer_MW_Div.Value = 0;
                //SBohrer_OW_Div.Value = 0;
                //SBohrer_MW_Div.Value = 100;
                //Pumpen
                //MPumpe_Div.Value = 0;
                //RPumpe_Div.Value = 0;
                //TPumpe_Div.Value = 100;

                //Produktion
                //GrafitPresse_Div.Value = 100;
                //MultiPresse_Div.Value = 0;
                //SiliziumSchmelzer_Div.Value = 100;
                //SiliziumSchmelztiegel_Div.Value = 0;
                //Secundär Rohstoffe
                //Sporenpresse_Div.Value = 100;
                //ÖlExtractor_Div.Value = 0;

                //Generatoren
                //Verbrennungsgenerator_Div.Value = 100;
                //Schlaggenerator_Div.Value = 100;

                //wurde durchlaufen
                O_one_T = true;
            }

            if (!checkBox1.Checked)
            {
                Calculate_New_Values();
            }
        }

        //Starte die inizialisation Herstellbaren/abbaubaren Materialien
        private void Kupfer_aweleble_CheckedChanged(object sender, EventArgs e)
        {
            Switch_Awelebles();
            //Switch_Awelebles();
        }

        private void Blei_aweleble_CheckedChanged(object sender, EventArgs e)
        {
            Switch_Awelebles();
            //Switch_Awelebles();
        }

        private void Sand_aweleble_CheckedChanged(object sender, EventArgs e)
        {
            Switch_Awelebles();
            //Switch_Awelebles();
        }

        private void Kohle_aweleble_CheckedChanged(object sender, EventArgs e)
        {
            Switch_Awelebles();
            //Switch_Awelebles();
        }

        private void Titan_aweleble_CheckedChanged(object sender, EventArgs e)
        {
            Switch_Awelebles();
            //Switch_Awelebles();
        }

        private void Thorium_aweleble_CheckedChanged(object sender, EventArgs e)
        {
            Switch_Awelebles();
            //Switch_Awelebles();
        }

        private void Schrott_aweleble_CheckedChanged(object sender, EventArgs e)
        {
            Switch_Awelebles();
            //Switch_Awelebles();
        }

        private void Wasser_aweleble_CheckedChanged(object sender, EventArgs e)
        {
            Switch_Awelebles();
            //Switch_Awelebles();
        }

        private void Kryoflüssigkeit_aweleble_CheckedChanged(object sender, EventArgs e)
        {
            Switch_Awelebles();
            //Switch_Awelebles();
        }

        private void Öl_aweleble_CheckedChanged(object sender, EventArgs e)
        {
            Switch_Awelebles();
            //Switch_Awelebles();
        }

        private void Schlacke_aweleble_CheckedChanged(object sender, EventArgs e)
        {
            Switch_Awelebles();
            //Switch_Awelebles();
        }
        //ende der inizialisation Herstellbaren/abbaubaren Materialien liste

        //Absolut
        //Mechanischer Bohrer ohne Wasser zusammengerechnet
        private int MB_OW_all()
        {
            //Math.Ceiling() Aufrunden
            return Convert.ToInt32(Math.Ceiling(Convert.ToDouble(Kupfer_MBohrer_OW_Be.Text))) +
                   Convert.ToInt32(Math.Ceiling(Convert.ToDouble(Blei_MBohrer_OW_Be.Text))) +
                   Convert.ToInt32(Math.Ceiling(Convert.ToDouble(Sand_MBohrer_OW_Be.Text))) +
                   Convert.ToInt32(Math.Ceiling(Convert.ToDouble(Kohle_MBohrer_OW_Be.Text))) +
                   Convert.ToInt32(Math.Ceiling(Convert.ToDouble(Schrott_MBohrer_OW_Be.Text)));
        }

        //Mechanischer Bohrer mit Wasser zusammengerechnet
        private int MB_MW_all()
        {
            //Math.Ceiling() Aufrunden
            return Convert.ToInt32(Math.Ceiling(Convert.ToDouble(Kupfer_MBohrer_MW_Be.Text))) +
                   Convert.ToInt32(Math.Ceiling(Convert.ToDouble(Blei_MBohrer_MW_Be.Text))) +
                   Convert.ToInt32(Math.Ceiling(Convert.ToDouble(Sand_MBohrer_MW_Be.Text))) +
                   Convert.ToInt32(Math.Ceiling(Convert.ToDouble(Kohle_MBohrer_MW_Be.Text))) +
                   Convert.ToInt32(Math.Ceiling(Convert.ToDouble(Schrott_MBohrer_MW_Be.Text)));
        }

        //Pneumatischer Bohrer ohne Wasser zusammengerechnet
        private int PB_OW_all()
        {
            //Math.Ceiling() Aufrunden
            return Convert.ToInt32(Math.Ceiling(Convert.ToDouble(Kupfer_PBohrer_OW_Be.Text))) +
                   Convert.ToInt32(Math.Ceiling(Convert.ToDouble(Blei_PBohrer_OW_Be.Text))) +
                   Convert.ToInt32(Math.Ceiling(Convert.ToDouble(Sand_PBohrer_OW_Be.Text))) +
                   Convert.ToInt32(Math.Ceiling(Convert.ToDouble(Kohle_PBohrer_OW_Be.Text))) +
                   Convert.ToInt32(Math.Ceiling(Convert.ToDouble(Titan_PBohrer_OW_Be.Text))) +
                   Convert.ToInt32(Math.Ceiling(Convert.ToDouble(Schrott_PBohrer_OW_Be.Text)));
        }

        //Pneumatischer Bohrer mit Wasser zusammengerechnet
        private int PB_MW_all()
        {
            //Math.Ceiling() Aufrunden
            return Convert.ToInt32(Math.Ceiling(Convert.ToDouble(Kupfer_PBohrer_MW_Be.Text))) +
                   Convert.ToInt32(Math.Ceiling(Convert.ToDouble(Blei_PBohrer_MW_Be.Text))) +
                   Convert.ToInt32(Math.Ceiling(Convert.ToDouble(Sand_PBohrer_MW_Be.Text))) +
                   Convert.ToInt32(Math.Ceiling(Convert.ToDouble(Kohle_PBohrer_MW_Be.Text))) +
                   Convert.ToInt32(Math.Ceiling(Convert.ToDouble(Titan_PBohrer_MW_Be.Text))) +
                   Convert.ToInt32(Math.Ceiling(Convert.ToDouble(Schrott_PBohrer_MW_Be.Text)));
        }

        //Laser Bohrer ohne Wasser zusammengerechnet
        private int LB_OW_all()
        {
            //Math.Ceiling() Aufrunden
            return Convert.ToInt32(Math.Ceiling(Convert.ToDouble(Kupfer_LBohrer_OW_Be.Text))) +
                   Convert.ToInt32(Math.Ceiling(Convert.ToDouble(Blei_LBohrer_OW_Be.Text))) +
                   Convert.ToInt32(Math.Ceiling(Convert.ToDouble(Sand_LBohrer_OW_Be.Text))) +
                   Convert.ToInt32(Math.Ceiling(Convert.ToDouble(Kohle_LBohrer_OW_Be.Text))) +
                   Convert.ToInt32(Math.Ceiling(Convert.ToDouble(Titan_LBohrer_OW_Be.Text))) +
                   Convert.ToInt32(Math.Ceiling(Convert.ToDouble(Thorium_LBohrer_OW_Be.Text))) +
                   Convert.ToInt32(Math.Ceiling(Convert.ToDouble(Schrott_LBohrer_OW_Be.Text)));
        }

        //Laser Bohrer mit Wasser zusammengerechnet
        private int LB_MW_all()
        {
            //Math.Ceiling() Aufrunden
            return Convert.ToInt32(Math.Ceiling(Convert.ToDouble(Kupfer_LBohrer_MW_Be.Text))) +
                   Convert.ToInt32(Math.Ceiling(Convert.ToDouble(Blei_LBohrer_MW_Be.Text))) +
                   Convert.ToInt32(Math.Ceiling(Convert.ToDouble(Sand_LBohrer_MW_Be.Text))) +
                   Convert.ToInt32(Math.Ceiling(Convert.ToDouble(Kohle_LBohrer_MW_Be.Text))) +
                   Convert.ToInt32(Math.Ceiling(Convert.ToDouble(Titan_LBohrer_MW_Be.Text))) +
                   Convert.ToInt32(Math.Ceiling(Convert.ToDouble(Thorium_LBohrer_MW_Be.Text))) +
                   Convert.ToInt32(Math.Ceiling(Convert.ToDouble(Schrott_LBohrer_MW_Be.Text)));
        }

        //Sprengluftbohrer Bohrer ohne Wasser zusammengerechnet
        private int SB_OW_all()
        {
            //Math.Ceiling() Aufrunden
            return Convert.ToInt32(Math.Ceiling(Convert.ToDouble(Kupfer_SBohrer_OW_Be.Text))) +
                   Convert.ToInt32(Math.Ceiling(Convert.ToDouble(Blei_SBohrer_OW_Be.Text))) +
                   Convert.ToInt32(Math.Ceiling(Convert.ToDouble(Sand_SBohrer_OW_Be.Text))) +
                   Convert.ToInt32(Math.Ceiling(Convert.ToDouble(Kohle_SBohrer_OW_Be.Text))) +
                   Convert.ToInt32(Math.Ceiling(Convert.ToDouble(Titan_SBohrer_OW_Be.Text))) +
                   Convert.ToInt32(Math.Ceiling(Convert.ToDouble(Thorium_SBohrer_OW_Be.Text))) +
                   Convert.ToInt32(Math.Ceiling(Convert.ToDouble(Schrott_SBohrer_OW_Be.Text)));
        }

        //Sprengluftbohrer Bohrer mit Wasser zusammengerechnet
        private int SB_MW_all()
        {
            //Math.Ceiling() Aufrunden
            return Convert.ToInt32(Math.Ceiling(Convert.ToDouble(Kupfer_SBohrer_MW_Be.Text))) +
                   Convert.ToInt32(Math.Ceiling(Convert.ToDouble(Blei_SBohrer_MW_Be.Text))) +
                   Convert.ToInt32(Math.Ceiling(Convert.ToDouble(Sand_SBohrer_MW_Be.Text))) +
                   Convert.ToInt32(Math.Ceiling(Convert.ToDouble(Kohle_SBohrer_MW_Be.Text))) +
                   Convert.ToInt32(Math.Ceiling(Convert.ToDouble(Titan_SBohrer_MW_Be.Text))) +
                   Convert.ToInt32(Math.Ceiling(Convert.ToDouble(Thorium_SBohrer_MW_Be.Text))) +
                   Convert.ToInt32(Math.Ceiling(Convert.ToDouble(Schrott_SBohrer_MW_Be.Text)));
        }

        //Mechanische Pumpe zusammengerechnet
        private long MP_all()
        {
            //Math.Ceiling() Aufrunden
            return Convert.ToInt64(Math.Ceiling(Convert.ToDouble(Wasser_MP_Be.Text))) +
                   Convert.ToInt64(Math.Ceiling(Convert.ToDouble(Kryoflüssigkeit_MP_Be.Text))) +
                   Convert.ToInt64(Math.Ceiling(Convert.ToDouble(Öl_MP_Be.Text))) +
                   Convert.ToInt64(Math.Ceiling(Convert.ToDouble(Schlacke_MP_Be.Text)));
        }

        //Rotierende Pumpe zusammengerechnet
        private long RP_all()
        {
            //Math.Ceiling() Aufrunden
            return Convert.ToInt64(Math.Ceiling(Convert.ToDouble(Wasser_RP_Be.Text))) +
                   Convert.ToInt64(Math.Ceiling(Convert.ToDouble(Kryoflüssigkeit_RP_Be.Text))) +
                   Convert.ToInt64(Math.Ceiling(Convert.ToDouble(Öl_RP_Be.Text))) +
                   Convert.ToInt64(Math.Ceiling(Convert.ToDouble(Schlacke_RP_Be.Text)));
        }

        //Thermische Pumpe zusammengerechnet
        private long TP_all()
        {
            //Math.Ceiling() Aufrunden
            return Convert.ToInt64(Math.Ceiling(Convert.ToDouble(Wasser_TP_Be.Text))) +
                   Convert.ToInt64(Math.Ceiling(Convert.ToDouble(Kryoflüssigkeit_TP_Be.Text))) +
                   Convert.ToInt64(Math.Ceiling(Convert.ToDouble(Öl_TP_Be.Text))) +
                   Convert.ToInt64(Math.Ceiling(Convert.ToDouble(Schlacke_TP_Be.Text)));
        }

        ////Prozent
        ////Mechanischer Bohrer ohne Wasser zusammengerechnet
        //private double MB_OW_all_P()
        //{
        //    return Convert.ToDouble(Kupfer_MBohrer_OW_Be.Text) +
        //           Convert.ToDouble(Blei_MBohrer_OW_Be.Text) +
        //           Convert.ToDouble(Sand_MBohrer_OW_Be.Text) +
        //           Convert.ToDouble(Kohle_MBohrer_OW_Be.Text) +
        //           Convert.ToDouble(Schrott_MBohrer_OW_Be.Text);
        //}
        //
        ////Mechanischer Bohrer mit Wasser zusammengerechnet
        //private double MB_MW_all_P()
        //{
        //    return Convert.ToDouble(Kupfer_MBohrer_MW_Be.Text) +
        //           Convert.ToDouble(Blei_MBohrer_MW_Be.Text) +
        //           Convert.ToDouble(Sand_MBohrer_MW_Be.Text) +
        //           Convert.ToDouble(Kohle_MBohrer_MW_Be.Text) +
        //           Convert.ToDouble(Schrott_MBohrer_MW_Be.Text);
        //}
        //
        ////Pneumatischer Bohrer ohne Wasser zusammengerechnet
        //private double PB_OW_all_P()
        //{
        //    return Convert.ToDouble(Kupfer_PBohrer_OW_Be.Text) +
        //           Convert.ToDouble(Blei_PBohrer_OW_Be.Text) +
        //           Convert.ToDouble(Sand_PBohrer_OW_Be.Text) +
        //           Convert.ToDouble(Kohle_PBohrer_OW_Be.Text) +
        //           Convert.ToDouble(Titan_PBohrer_OW_Be.Text) +
        //           Convert.ToDouble(Schrott_PBohrer_OW_Be.Text);
        //}
        //
        ////Pneumatischer Bohrer mit Wasser zusammengerechnet
        //private double PB_MW_all_P()
        //{
        //    return Convert.ToDouble(Kupfer_PBohrer_MW_Be.Text) +
        //           Convert.ToDouble(Blei_PBohrer_MW_Be.Text) +
        //           Convert.ToDouble(Sand_PBohrer_MW_Be.Text) +
        //           Convert.ToDouble(Kohle_PBohrer_MW_Be.Text) +
        //           Convert.ToDouble(Titan_PBohrer_MW_Be.Text) +
        //           Convert.ToDouble(Schrott_PBohrer_MW_Be.Text);
        //}
        //
        ////Laser Bohrer ohne Wasser zusammengerechnet
        //private double LB_OW_all_P()
        //{
        //    return Convert.ToDouble(Kupfer_LBohrer_OW_Be.Text) +
        //           Convert.ToDouble(Blei_LBohrer_OW_Be.Text) +
        //           Convert.ToDouble(Sand_LBohrer_OW_Be.Text) +
        //           Convert.ToDouble(Kohle_LBohrer_OW_Be.Text) +
        //           Convert.ToDouble(Titan_LBohrer_OW_Be.Text) +
        //           Convert.ToDouble(Thorium_LBohrer_OW_Be.Text) +
        //           Convert.ToDouble(Schrott_LBohrer_OW_Be.Text);
        //}
        //
        ////Laser Bohrer mit Wasser zusammengerechnet
        //private double LB_MW_all_P()
        //{
        //    return Convert.ToDouble(Kupfer_LBohrer_MW_Be.Text) +
        //           Convert.ToDouble(Blei_LBohrer_MW_Be.Text) +
        //           Convert.ToDouble(Sand_LBohrer_MW_Be.Text) +
        //           Convert.ToDouble(Kohle_LBohrer_MW_Be.Text) +
        //           Convert.ToDouble(Titan_LBohrer_MW_Be.Text) +
        //           Convert.ToDouble(Thorium_LBohrer_MW_Be.Text) +
        //           Convert.ToDouble(Schrott_LBohrer_MW_Be.Text);
        //}
        //
        ////Sprengluftbohrer Bohrer ohne Wasser zusammengerechnet
        //private double SB_OW_all_P()
        //{
        //    return Convert.ToDouble(Kupfer_SBohrer_OW_Be.Text) +
        //           Convert.ToDouble(Blei_SBohrer_OW_Be.Text) +
        //           Convert.ToDouble(Sand_SBohrer_OW_Be.Text) +
        //           Convert.ToDouble(Kohle_SBohrer_OW_Be.Text) +
        //           Convert.ToDouble(Titan_SBohrer_OW_Be.Text) +
        //           Convert.ToDouble(Thorium_SBohrer_OW_Be.Text) +
        //           Convert.ToDouble(Schrott_SBohrer_OW_Be.Text);
        //}
        //
        ////Sprengluftbohrer Bohrer mit Wasser zusammengerechnet
        //private double SB_MW_all_P()
        //{
        //    return Convert.ToDouble(Kupfer_SBohrer_MW_Be.Text) +
        //           Convert.ToDouble(Blei_SBohrer_MW_Be.Text) +
        //           Convert.ToDouble(Sand_SBohrer_MW_Be.Text) +
        //           Convert.ToDouble(Kohle_SBohrer_MW_Be.Text) +
        //           Convert.ToDouble(Titan_SBohrer_MW_Be.Text) +
        //           Convert.ToDouble(Thorium_SBohrer_MW_Be.Text) +
        //           Convert.ToDouble(Schrott_SBohrer_MW_Be.Text);
        //}
        //
        ////Mechanische Pumpe zusammengerechnet
        //private double MP_all_P()
        //{
        //    //Math.Ceiling() Aufrunden
        //    return Convert.ToDouble(Wasser_MP_Be.Text) +
        //           Convert.ToDouble(Kryoflüssigkeit_MP_Be.Text) +
        //           Convert.ToDouble(Öl_MP_Be.Text) +
        //           Convert.ToDouble(Schlacke_MP_Be.Text);
        //}
        //
        ////Rotierende Pumpe zusammengerechnet
        //private double RP_all_P()
        //{
        //    //Math.Ceiling() Aufrunden
        //    return Convert.ToDouble(Wasser_RP_Be.Text) +
        //           Convert.ToDouble(Kryoflüssigkeit_RP_Be.Text) +
        //           Convert.ToDouble(Öl_RP_Be.Text) +
        //           Convert.ToDouble(Schlacke_RP_Be.Text);
        //}
        //
        ////Thermische Pumpe zusammengerechnet
        //private double TP_all_P()
        //{
        //    //Math.Ceiling() Aufrunden
        //    return Convert.ToDouble(Wasser_TP_Be.Text) +
        //           Convert.ToDouble(Kryoflüssigkeit_TP_Be.Text) +
        //           Convert.ToDouble(Öl_TP_Be.Text) +
        //           Convert.ToDouble(Schlacke_TP_Be.Text);
        //}
        //
        //
        //private void Rohstoffabbau_Divider_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    //Rohstoffabbau_Divider.Items.AddRange(new object[] { "Absolut", "Prozent %", "Absolut + Wasser Extraktor", "Prozent % + Wasser Extraktor" });
        //
        //    bool Abs = MBohrer_OW_Div.Maximum == 100000000;
        //
        //    //Bohrer
        //    uint MB_OW_alt, MB_MW_alt, PB_OW_alt, PB_MW_alt,
        //    LB_OW_alt, LB_MW_alt, SB_OW_alt, SB_MW_alt,
        //    //Pumpen
        //    MP_alt, RP_alt, TP_alt;
        //
        //    //Hilfs Variablen
        //    int New_Max_Value, New_Decimal_P;
        //
        //    double Bohrer_all, Pumpen_all;
        //
        //    //Save Value
        //    //Bohrer
        //    MB_OW_alt = Convert.ToUInt32(MBohrer_OW_Div.Value);
        //    MB_MW_alt = Convert.ToUInt32(MBohrer_MW_Div.Value);
        //    PB_OW_alt = Convert.ToUInt32(PBohrer_OW_Div.Value);
        //    PB_MW_alt = Convert.ToUInt32(PBohrer_MW_Div.Value);
        //    LB_OW_alt = Convert.ToUInt32(LBohrer_OW_Div.Value);
        //    LB_MW_alt = Convert.ToUInt32(LBohrer_MW_Div.Value);
        //    SB_OW_alt = Convert.ToUInt32(SBohrer_OW_Div.Value);
        //    SB_MW_alt = Convert.ToUInt32(SBohrer_MW_Div.Value);
        //    //Pumpen
        //    MP_alt = Convert.ToUInt32(MPumpe_Div.Value);
        //    RP_alt = Convert.ToUInt32(RPumpe_Div.Value);
        //    TP_alt = Convert.ToUInt32(TPumpe_Div.Value);
        //
        //    //Summe
        //    Bohrer_all = MB_OW_all_P() + MB_MW_all_P() + PB_OW_all_P() + PB_MW_all_P() + LB_OW_all_P() + LB_MW_all_P() + SB_OW_all_P() + SB_MW_all_P();
        //
        //    Error_s = "";
        //
        //    if (Bohrer_all == 0)
        //    {
        //        Error_s += "Bohrer-Verteilung\n";
        //    }
        //    if (SiliziumSchmelzer_Div.Value == 0 && SiliziumSchmelztiegel_Div.Value == 0)
        //    {
        //        Error_s += "Pumpen-Verteilung\n";
        //    }
        //
        //    if (Error_s.Length > 0)
        //    {
        //        Error_s = "The following values ​​preserve 0:\n" + Error_s;
        //
        //        if (Bohrer_all == 0)
        //        {
        //            Error_s += "The Sprengluftbohrer mit Wasser-Verteilung value is set to max\n";
        //            SBohrer_MW_Div.Value = 100;
        //        }
        //        if (SiliziumSchmelzer_Div.Value == 0 && SiliziumSchmelztiegel_Div.Value == 0)
        //        {
        //            Error_s += "The Thermische-Pumpe-Verteilung value is set to max\n";
        //            TPumpe_Div.Value = 100;
        //        }
        //        //Massege
        //        // Initializes the variables to pass to the MessageBox.Show method.
        //        string message = Error_s;
        //        string caption = "Error Detected in Input";
        //        MessageBoxButtons buttons = MessageBoxButtons.OK;
        //
        //        // Displays the MessageBox.
        //        MessageBox.Show(message, caption, buttons);
        //    }
        //
        //    //Reset Value
        //    //Bohrer
        //    MBohrer_OW_Div.Value = 0;
        //    MBohrer_MW_Div.Value = 0;
        //    PBohrer_OW_Div.Value = 0;
        //    PBohrer_MW_Div.Value = 0;
        //    LBohrer_OW_Div.Value = 0;
        //    LBohrer_MW_Div.Value = 0;
        //    SBohrer_OW_Div.Value = 0;
        //    SBohrer_MW_Div.Value = 0;
        //    //Pumpen
        //    MPumpe_Div.Value = 0;
        //    RPumpe_Div.Value = 0;
        //    TPumpe_Div.Value = 0;
        //
        //    //Absolut
        //    if ((Rohstoffabbau_Divider.Text == "Absolut" || Rohstoffabbau_Divider.Text == "Absolut + Wasser Extraktor") && !Abs)
        //    {
        //
        //        //Set new max Value: { 100000000, 0, 0, 0 }
        //        New_Max_Value = 100000000;
        //        //Bohrer
        //        MBohrer_OW_Div.Maximum = new decimal(new int[] { New_Max_Value, 0, 0, 0 });
        //        MBohrer_MW_Div.Maximum = new decimal(new int[] { New_Max_Value, 0, 0, 0 });
        //        PBohrer_OW_Div.Maximum = new decimal(new int[] { New_Max_Value, 0, 0, 0 });
        //        PBohrer_MW_Div.Maximum = new decimal(new int[] { New_Max_Value, 0, 0, 0 });
        //        LBohrer_OW_Div.Maximum = new decimal(new int[] { New_Max_Value, 0, 0, 0 });
        //        LBohrer_MW_Div.Maximum = new decimal(new int[] { New_Max_Value, 0, 0, 0 });
        //        SBohrer_OW_Div.Maximum = new decimal(new int[] { New_Max_Value, 0, 0, 0 });
        //        SBohrer_MW_Div.Maximum = new decimal(new int[] { New_Max_Value, 0, 0, 0 });
        //        //Pumpen
        //        MPumpe_Div.Maximum = new decimal(new int[] { New_Max_Value, 0, 0, 0 });
        //        RPumpe_Div.Maximum = new decimal(new int[] { New_Max_Value, 0, 0, 0 });
        //        TPumpe_Div.Maximum = new decimal(new int[] { New_Max_Value, 0, 0, 0 });
        //
        //        //Set new Decimal Places: 0
        //        New_Decimal_P = 0;
        //        //Bohrer
        //        MBohrer_OW_Div.DecimalPlaces = New_Decimal_P;
        //        MBohrer_MW_Div.DecimalPlaces = New_Decimal_P;
        //        PBohrer_OW_Div.DecimalPlaces = New_Decimal_P;
        //        PBohrer_MW_Div.DecimalPlaces = New_Decimal_P;
        //        LBohrer_OW_Div.DecimalPlaces = New_Decimal_P;
        //        LBohrer_MW_Div.DecimalPlaces = New_Decimal_P;
        //        SBohrer_OW_Div.DecimalPlaces = New_Decimal_P;
        //        SBohrer_MW_Div.DecimalPlaces = New_Decimal_P;
        //        //Pumpen
        //        MPumpe_Div.DecimalPlaces = New_Decimal_P;
        //        RPumpe_Div.DecimalPlaces = New_Decimal_P;
        //        TPumpe_Div.DecimalPlaces = New_Decimal_P;
        //
        //        //Adjust Value
        //        //Bohrer
        //        if (Bohrer_all > 0)
        //        {
        //            MBohrer_OW_Div.Value = Convert.ToUInt32(MB_OW_alt * Bohrer_all);
        //            MBohrer_MW_Div.Value = Convert.ToUInt32(MB_MW_alt * Bohrer_all);
        //            PBohrer_OW_Div.Value = Convert.ToUInt32(PB_OW_alt * Bohrer_all);
        //            PBohrer_MW_Div.Value = Convert.ToUInt32(PB_MW_alt * Bohrer_all);
        //            LBohrer_OW_Div.Value = Convert.ToUInt32(LB_OW_alt * Bohrer_all);
        //            LBohrer_MW_Div.Value = Convert.ToUInt32(LB_MW_alt * Bohrer_all);
        //            SBohrer_OW_Div.Value = Convert.ToUInt32(SB_OW_alt * Bohrer_all);
        //            SBohrer_MW_Div.Value = Convert.ToUInt32(SB_MW_alt * Bohrer_all);
        //        }
        //        //Pumpen
        //        if (Rohstoffabbau_Divider.Text == "Absolut")
        //        {
        //            //ohne Wasser Extraktor
        //            //Summe
        //            Pumpen_all = MP_alt + RP_alt + TP_alt;
        //            if (Pumpen_all > 0)
        //            {
        //                MPumpe_Div.Value = Convert.ToUInt32((MP_alt / Pumpen_all) * (MP_all_P() + RP_all_P() + TP_all_P() + Convert.ToDouble(WasserExtractor_Be.Text)));
        //                RPumpe_Div.Value = Convert.ToUInt32((RP_alt / Pumpen_all) * (MP_all_P() + RP_all_P() + TP_all_P() + Convert.ToDouble(WasserExtractor_Be.Text)));
        //                TPumpe_Div.Value = Convert.ToUInt32((TP_alt / Pumpen_all) * (MP_all_P() + RP_all_P() + TP_all_P() + Convert.ToDouble(WasserExtractor_Be.Text)));
        //                WasserExtractor_Be.Text = "0";
        //            }
        //        }
        //        else
        //        {
        //            //mit Wasser Extraktor
        //            //Summe
        //            Pumpen_all = MP_all_P() + RP_all_P() + TP_all_P();
        //            if (Pumpen_all > 0)
        //            {
        //                MPumpe_Div.Value = Convert.ToUInt32((MP_alt * Pumpen_all) * (MP_all_P() + RP_all_P() + TP_all_P() + Convert.ToDouble(WasserExtractor_Be.Text)));
        //                RPumpe_Div.Value = Convert.ToUInt32((RP_alt * Pumpen_all) * (MP_all_P() + RP_all_P() + TP_all_P() + Convert.ToDouble(WasserExtractor_Be.Text)));
        //                TPumpe_Div.Value = Convert.ToUInt32((TP_alt * Pumpen_all) * (MP_all_P() + RP_all_P() + TP_all_P() + Convert.ToDouble(WasserExtractor_Be.Text)));
        //                WasserExtractor_Be.Text = Convert.ToString(Pumpen_all - (MP_alt + RP_alt + TP_alt));
        //            }
        //        }
        //    }
        //
        //    //Prozent
        //    if ((Rohstoffabbau_Divider.Text == "Prozent %" || Rohstoffabbau_Divider.Text == "Prozent % + Wasser Extraktor") && Abs)
        //    {
        //        //Set new max Value: { 100, 0, 0, 0 }
        //        New_Max_Value = 100;
        //        //Bohrer
        //        MBohrer_OW_Div.Maximum = new decimal(new int[] { New_Max_Value, 0, 0, 0 });
        //        MBohrer_MW_Div.Maximum = new decimal(new int[] { New_Max_Value, 0, 0, 0 });
        //        PBohrer_OW_Div.Maximum = new decimal(new int[] { New_Max_Value, 0, 0, 0 });
        //        PBohrer_MW_Div.Maximum = new decimal(new int[] { New_Max_Value, 0, 0, 0 });
        //        LBohrer_OW_Div.Maximum = new decimal(new int[] { New_Max_Value, 0, 0, 0 });
        //        LBohrer_MW_Div.Maximum = new decimal(new int[] { New_Max_Value, 0, 0, 0 });
        //        SBohrer_OW_Div.Maximum = new decimal(new int[] { New_Max_Value, 0, 0, 0 });
        //        SBohrer_MW_Div.Maximum = new decimal(new int[] { New_Max_Value, 0, 0, 0 });
        //        //Pumpen
        //        MPumpe_Div.Maximum = new decimal(new int[] { New_Max_Value, 0, 0, 0 });
        //        RPumpe_Div.Maximum = new decimal(new int[] { New_Max_Value, 0, 0, 0 });
        //        TPumpe_Div.Maximum = new decimal(new int[] { New_Max_Value, 0, 0, 0 });
        //
        //        //Set new Decimal Places: 2
        //        New_Decimal_P = 2;
        //        //Bohrer
        //        MBohrer_OW_Div.DecimalPlaces = New_Decimal_P;
        //        MBohrer_MW_Div.DecimalPlaces = New_Decimal_P;
        //        PBohrer_OW_Div.DecimalPlaces = New_Decimal_P;
        //        PBohrer_MW_Div.DecimalPlaces = New_Decimal_P;
        //        LBohrer_OW_Div.DecimalPlaces = New_Decimal_P;
        //        LBohrer_MW_Div.DecimalPlaces = New_Decimal_P;
        //        SBohrer_OW_Div.DecimalPlaces = New_Decimal_P;
        //        SBohrer_MW_Div.DecimalPlaces = New_Decimal_P;
        //        //Pumpen
        //        MPumpe_Div.DecimalPlaces = New_Decimal_P;
        //        RPumpe_Div.DecimalPlaces = New_Decimal_P;
        //        TPumpe_Div.DecimalPlaces = New_Decimal_P;
        //
        //        //Adjust Value
        //        //Bohrer
        //        if (Bohrer_all > 0)
        //        {
        //            MBohrer_OW_Div.Value = Convert.ToUInt32(Bohrer_all / MB_OW_alt);
        //            MBohrer_MW_Div.Value = Convert.ToUInt32(Bohrer_all / MB_MW_alt);
        //            PBohrer_OW_Div.Value = Convert.ToUInt32(Bohrer_all / PB_OW_alt);
        //            PBohrer_MW_Div.Value = Convert.ToUInt32(Bohrer_all / PB_MW_alt);
        //            LBohrer_OW_Div.Value = Convert.ToUInt32(Bohrer_all / LB_OW_alt);
        //            LBohrer_MW_Div.Value = Convert.ToUInt32(Bohrer_all / LB_MW_alt);
        //            SBohrer_OW_Div.Value = Convert.ToUInt32(Bohrer_all / SB_OW_alt);
        //            SBohrer_MW_Div.Value = Convert.ToUInt32(Bohrer_all / SB_MW_alt);
        //        }
        //
        //        //Pumpen
        //        if (Rohstoffabbau_Divider.Text == "Prozent %")
        //        {
        //            //ohne Wasser Extraktor
        //            //Summe
        //            Pumpen_all = MP_alt + RP_alt + TP_alt;
        //            if (Pumpen_all > 0)
        //            {
        //                MPumpe_Div.Value = Convert.ToUInt32((MP_alt / Pumpen_all));
        //                RPumpe_Div.Value = Convert.ToUInt32((RP_alt / Pumpen_all));
        //                TPumpe_Div.Value = Convert.ToUInt32((TP_alt / Pumpen_all));
        //                WasserExtractor_Be.Text = "0";
        //            }
        //        }
        //        else
        //        {
        //            //mit Wasser Extraktor
        //            //Summe
        //            Pumpen_all = MP_all_P() + RP_all_P() + TP_all_P();
        //            if (Pumpen_all > 0)
        //            {
        //                MPumpe_Div.Value = Convert.ToUInt32(Pumpen_all * MP_alt * (MP_all_P() + RP_all_P() + TP_all_P() + Convert.ToDouble(WasserExtractor_Be.Text)));
        //                RPumpe_Div.Value = Convert.ToUInt32(Pumpen_all * RP_alt * (MP_all_P() + RP_all_P() + TP_all_P() + Convert.ToDouble(WasserExtractor_Be.Text)));
        //                TPumpe_Div.Value = Convert.ToUInt32(Pumpen_all * TP_alt * (MP_all_P() + RP_all_P() + TP_all_P() + Convert.ToDouble(WasserExtractor_Be.Text)));
        //                WasserExtractor_Be.Text = Convert.ToString(Pumpen_all - (MP_alt + RP_alt + TP_alt));
        //            }
        //        }
        //
        //    }
        //    Switch_Awelebles();
        //    if (!checkBox1.Checked)
        //    {
        //        Calculate_New_Values(false);
        //    }
        //}
        //
        //Calculate New Values for all Pages

        void Calculate_New_Values(bool changed = true)
        {
            //bool loop = false;
            int infiniti_loop = 0, infiniti_loop_2 = 0, infiniti_loop_3 = 0;

            if (changed)
            {
                //Bohrer
                double BM_OW_Div = Convert.ToDouble(MBohrer_OW_Div.Value) / 100,
                       BM_MW_Div = Convert.ToDouble(MBohrer_MW_Div.Value) / 100,
                       BP_OW_Div = Convert.ToDouble(PBohrer_OW_Div.Value) / 100,
                       BP_MW_Div = Convert.ToDouble(PBohrer_MW_Div.Value) / 100,
                       BL_OW_Div = Convert.ToDouble(LBohrer_OW_Div.Value) / 100,
                       BL_MW_Div = Convert.ToDouble(LBohrer_MW_Div.Value) / 100,
                       BS_OW_Div = Convert.ToDouble(SBohrer_OW_Div.Value) / 100,
                       BS_MW_Div = Convert.ToDouble(SBohrer_MW_Div.Value) / 100,
                //Pumpen
                       MP_Div = Convert.ToDouble(MPumpe_Div.Value) / 100,
                       RP_Div = Convert.ToDouble(RPumpe_Div.Value) / 100,
                       TP_Div = Convert.ToDouble(TPumpe_Div.Value) / 100,
                //Generatoren
                       VerG_Div,
                       TerG_Div = Convert.ToDouble(ThermischerGenerator_Div.Value) / 100,
                       TurG_Div,
                       DifG_Div = Convert.ToDouble(Differenzialgenerator_Div.Value) / 100,
                       RTGG_Div,
                       SolG_Div = Convert.ToDouble(Solarpanel_Div.Value) / 100,
                       GSG_Div = Convert.ToDouble(GroßesSolarpanel_Div.Value) / 100,
                       TorG_Div = Convert.ToDouble(ThoriumReaktor_Div.Value) / 100,
                       SchG_Div = Convert.ToDouble(Schlaggenerator_Div.Value) / 100;

                if (Verbrennungsgenerator_Energie.Text == s_Kohle || Verbrennungsgenerator_Energie.Text == s_SporenPod ||
                    Verbrennungsgenerator_Energie.Text == s_Pyratit || Verbrennungsgenerator_Energie.Text == s_ExplosiveMischung)
                {
                    VerG_Div = Convert.ToDouble(Verbrennungsgenerator_Div.Value) / 100;
                }
                else
                {
                    VerG_Div = 0.00;
                }

                if (Turbinengenerator_Energie.Text == s_Kohle || Turbinengenerator_Energie.Text == s_SporenPod ||
                    Turbinengenerator_Energie.Text == s_Pyratit || Turbinengenerator_Energie.Text == s_ExplosiveMischung)
                {
                    TurG_Div = Convert.ToDouble(Turbinengenerator_Div.Value) / 100;
                }
                else
                {
                    TurG_Div = 0.00;
                }

                if (RTGGenerator_Energie.Text == s_Thorium || RTGGenerator_Energie.Text == s_Phasengewebe)
                {
                    RTGG_Div = Convert.ToDouble(RTGGenerator_Div.Value) / 100;
                }
                else
                {
                    RTGG_Div = 0.00;
                }


                if (//(BM_OW_Div + BM_MW_Div + BP_OW_Div + BP_MW_Div + BL_OW_Div + BL_MW_Div + BS_OW_Div + BS_MW_Div) < 0.01 ||
                    //(MP_Div + RP_Div + TP_Div) < 0.01 ||
                    (VerG_Div + TerG_Div + TurG_Div + DifG_Div + RTGG_Div + SolG_Div + GSG_Div + TorG_Div + SchG_Div) < 0.01)
                {
                    //Massege
                    // Initializes the variables to pass to the MessageBox.Show method.
                    string message = "You have not selected a fuel for the generators.\n" +
                                     "So nothing can be calculated.";
                    string caption = "Error Detected in Input";
                    MessageBoxButtons buttons = MessageBoxButtons.OK;

                    // Displays the MessageBox.
                    MessageBox.Show(message, caption, buttons);

                    return;
                }

                //Gewünschte
                //Rohstoffe
                int Schrott, Kupfer, Blei, Sand, Kohle, Titan, Thorium,

                //Flüssigkeiten
                    Schlacke, Wasser, Kryoflüssigkeit, Öl,

                //Produkte
                    SporenPod, Metaglas, Grafit, Silizium, Pyratit, ExplosiveMischung, Plastanium, Phasengewebe,
                    Spannungslegierung, Strom,

                //secundär Rohstoffe
                WasserExtractor, Kultivierer, ÖlExtractor, Sporenpresse, Pulverisierer,
                    Kohlenzentriefuge, Kryoflüssigkeitsmixer, Schmelzer,
                    Trenner, GroßerTrenner,

                //Fabriken
                    GrafitPresse, MultiPresse, SiliziumSchmelzer, SiliziumSchmelztiegel, Brennofen,
                    PlastaniumVerdichter, Phasenweber, Legierungsschmelze, PyratitMixer, Sprengmixer,

                //Generatoren
                    Verbrennungsgenerator, ThermischerGenerator, Turbinengenerator, Differenzialgenerator, RTGGenerator,
                    Solarpanel, GroßesSolarpanel, ThoriumReaktor, Schlaggenerator, M_Strom,

                //Mauern
                    Kupfermauer, GroßeKupfermauer, Titanmauer, GroßeTitanmauer, Thoriummauer, GroßeThoriummauer, Phasenmauer, GroßePhasenmauer,
                    Spannungsmauer, GroßeSpannungsmauer, Plastaniummauer, GroßePlastaniummauer, Tor, GroßesTor,

                //Schutzeinrichtungen
                    Batterie, GroßeBatterie, Behälter, Tresor, Reparateur, Reparaturprojektor, BeschleunigungsProjektor, BeschleunigungsMaschine,
                    KraftfeldProjektor, SchockMine, Reparaturpunkt, Reparaturstation,

                //Geschütze
                    Doppelgeschütz, Luftgeschütz, Scatter, Hail, Welle, Lancer, Arcus, Parallax, Schwärmer, Salve, Segment,
                    Tsunami, Zünder, Zerstörer, Zyklon, Foreshadow, Phantom, Meltdown,

                    //Truppen Produktion
                    //Bodenfabrik, Luftfabrik, Wasserfabrik, 
                    HinzufügenderRekonstrukeur,
                    MultiplikativerRekonstrukeur, ExponenziellerRekonstrukeur, TretrativerRekonstrukeur;

                //Truppen Land
                double Dagger, Mace, Fortress, Scepter, Reign,
                     Nova, Pulsar, Quasar, Vela, Korvus,
                     Crawler, Atrax, Spirokt, Arkyid, Toxopid,

                //Truppen Wasser
                     Risso, Minke, Bryde, Sei, Omura,
                     Retusa, Oxynoe, Cyerce, Aegires, Navanax,

                //Truppen Luft
                     Flare, Horizont, Zenit, Antumbra, Eclipse,
                     Mono, Poly, Mega, Quad, Okt;

                //Produktion
                //Rohstoffe
                double Schrott_Pr = 0, Kupfer_Pr = 0, Blei_Pr = 0, Sand_Pr, Kohle_Pr = 0, Titan_Pr = 0, Thorium_Pr = 0,

                //Flüssigkeiten
                    Schlacke_Pr = 0, Wasser_Pr = 0, Kryoflüssigkeit_Pr = 0, Öl_Pr = 0,

                //Produkte
                    SporenPod_Pr = 0, Metaglas_Pr = 0, Grafit_Pr = 0, Silizium_Pr = 0, Pyratit_Pr = 0, ExplosiveMischung_Pr = 0, Plastanium_Pr = 0, Phasengewebe_Pr = 0,
                    Spannungslegierung_Pr = 0;

                //Bohrer
                long
                //M_Bohrer_Pr, P_Bohrer_Pr, L_Bohrer_Pr, S_Bohrer_Pr,

                //Pumpen
                // M_Pumpen_Pr, R_Pumpen_Pr, T_Pumpen_Pr,
                //Bohrer
                Kupfer_MB_OW_Wunsch, Kupfer_MB_MW_Wunsch,
                Blei_MB_OW_Wunsch, Blei_MB_MW_Wunsch,
                Sand_MB_OW_Wunsch, Sand_MB_MW_Wunsch,
                Kohle_MB_OW_Wunsch, Kohle_MB_MW_Wunsch,
                Schrott_MB_OW_Wunsch, Schrott_MB_MW_Wunsch,
                Kupfer_PB_OW_Wunsch, Kupfer_PB_MW_Wunsch,
                Blei_PB_OW_Wunsch, Blei_PB_MW_Wunsch,
                Sand_PB_OW_Wunsch, Sand_PB_MW_Wunsch,
                Kohle_PB_OW_Wunsch, Kohle_PB_MW_Wunsch,
                Titan_PB_OW_Wunsch, Titan_PB_MW_Wunsch,
                Schrott_PB_OW_Wunsch, Schrott_PB_MW_Wunsch,
                Kupfer_LB_OW_Wunsch, Kupfer_LB_MW_Wunsch,
                Blei_LB_OW_Wunsch, Blei_LB_MW_Wunsch,
                Sand_LB_OW_Wunsch, Sand_LB_MW_Wunsch,
                Kohle_LB_OW_Wunsch, Kohle_LB_MW_Wunsch,
                Titan_LB_OW_Wunsch, Titan_LB_MW_Wunsch,
                Thorium_LB_OW_Wunsch, Thorium_LB_MW_Wunsch,
                Schrott_LB_OW_Wunsch, Schrott_LB_MW_Wunsch,
                Kupfer_SB_OW_Wunsch, Kupfer_SB_MW_Wunsch,
                Blei_SB_OW_Wunsch, Blei_SB_MW_Wunsch,
                Sand_SB_OW_Wunsch, Sand_SB_MW_Wunsch,
                Kohle_SB_OW_Wunsch, Kohle_SB_MW_Wunsch,
                Titan_SB_OW_Wunsch, Titan_SB_MW_Wunsch,
                Thorium_SB_OW_Wunsch, Thorium_SB_MW_Wunsch,
                Schrott_SB_OW_Wunsch, Schrott_SB_MW_Wunsch,

                //Pumpe
                Wasser_MP_Wunsch,
                Kryoflüssigkeit_MP_Wunsch,
                Öl_MP_Wunsch,
                Schlacke_MP_Wunsch,
                Wasser_RP_Wunsch,
                Kryoflüssigkeit_RP_Wunsch,
                Öl_RP_Wunsch,
                Schlacke_RP_Wunsch,
                Wasser_TP_Wunsch,
                Kryoflüssigkeit_TP_Wunsch,
                Öl_TP_Wunsch,
                Schlacke_TP_Wunsch,


                //secundär Rohstoffe
                WasserExtractor_Pr, Kultivierer_Pr, ÖlExtractor_Pr, Sporenpresse_Pr, Pulverisierer_Pr,
                    Kohlenzentriefuge_Pr, Kryoflüssigkeitsmixer_Pr, Schmelzer_Pr,
                    Trenner_Pr, GroßerTrenner_Pr,

                //Fabriken
                    GrafitPresse_Pr, MultiPresse_Pr, SiliziumSchmelzer_Pr, SiliziumSchmelztiegel_Pr, Brennofen_Pr,
                    PlastaniumVerdichter_Pr, Phasenweber_Pr, Legierungsschmelze_Pr, PyratitMixer_Pr, Sprengmixer_Pr,

                //Generatoren
                    Verbrennungsgenerator_Pr, ThermischerGenerator_Pr, Turbinengenerator_Pr, Differenzialgenerator_Pr, RTGGenerator_Pr,
                    Solarpanel_Pr, GroßesSolarpanel_Pr, ThoriumReaktor_Pr, Schlaggenerator_Pr, Strom_Pr = 0, Strom_Er;

                //Erzeugung
                //Rohstoffe
                double Schrott_Er, Kupfer_Er, Blei_Er, Sand_Er, Kohle_Er, Titan_Er, Thorium_Er,

                //Flüssigkeiten
                    Schlacke_Er, Wasser_Er, Kryoflüssigkeit_Er, Öl_Er,

                //Produkte
                    SporenPod_Er, Metaglas_Er, Grafit_Er, Silizium_Er, Pyratit_Er, ExplosiveMischung_Er, Plastanium_Er, Phasengewebe_Er,
                    Spannungslegierung_Er,

                //Bohrer
                Kupfer_MB_OW_Value, Kupfer_MB_MW_Value,
                Blei_MB_OW_Value, Blei_MB_MW_Value,
                Sand_MB_OW_Value, Sand_MB_MW_Value,
                Kohle_MB_OW_Value, Kohle_MB_MW_Value,
                Schrott_MB_OW_Value, Schrott_MB_MW_Value,
                Kupfer_PB_OW_Value, Kupfer_PB_MW_Value,
                Blei_PB_OW_Value, Blei_PB_MW_Value,
                Sand_PB_OW_Value, Sand_PB_MW_Value,
                Kohle_PB_OW_Value, Kohle_PB_MW_Value,
                Titan_PB_OW_Value, Titan_PB_MW_Value,
                Schrott_PB_OW_Value, Schrott_PB_MW_Value,
                Kupfer_LB_OW_Value, Kupfer_LB_MW_Value,
                Blei_LB_OW_Value, Blei_LB_MW_Value,
                Sand_LB_OW_Value, Sand_LB_MW_Value,
                Kohle_LB_OW_Value, Kohle_LB_MW_Value,
                Titan_LB_OW_Value, Titan_LB_MW_Value,
                Thorium_LB_OW_Value, Thorium_LB_MW_Value,
                Schrott_LB_OW_Value, Schrott_LB_MW_Value,
                Kupfer_SB_OW_Value, Kupfer_SB_MW_Value,
                Blei_SB_OW_Value, Blei_SB_MW_Value,
                Sand_SB_OW_Value, Sand_SB_MW_Value,
                Kohle_SB_OW_Value, Kohle_SB_MW_Value,
                Titan_SB_OW_Value, Titan_SB_MW_Value,
                Thorium_SB_OW_Value, Thorium_SB_MW_Value,
                Schrott_SB_OW_Value, Schrott_SB_MW_Value,

                //Pumpe
                Wasser_MP_Value,
                Kryoflüssigkeit_MP_Value,
                Öl_MP_Value,
                Schlacke_MP_Value,
                Wasser_RP_Value,
                Kryoflüssigkeit_RP_Value,
                Öl_RP_Value,
                Schlacke_RP_Value,
                Wasser_TP_Value,
                Kryoflüssigkeit_TP_Value,
                Öl_TP_Value,
                Schlacke_TP_Value;

                ////Truppen Land
                //Dagger, Mace, Fortress, Scepter, Reign,
                double Bodenfabrik_B_Orange = 0,

                //Nova, Pulsar, Quasar, Vela, Korvus,
                    Bodenfabrik_B_Gruen = 0,

                //Crawler, Atrax, Spirokt, Arkyid, Toxopid,
                    Bodenfabrik_B_Lila = 0,

                ////Truppen Luft
                //Flare, Horizont, Zenit, Antumbra, Eclipse,
                     Luftfabrik_L_Orange = 0,

                //Mono, Poly, Mega, Quad, Okt;
                    Luftfabrik_L_Gruen = 0,

                ////Truppen Wasser
                //Risso, Minke, Bryde, Sei, Omura,
                    Wasserfabrik_W_Orange = 0,

                //Retusa, Oxynoe, Cyerce, Aegires, Navanax
                    Wasserfabrik_W_Gruen = 0,

                //Rekonstrukeur
                    HinzufügenderRekonstrukeur_Zw = 0, MultiplikativerRekonstrukeur_Zw = 0,
                    ExponenziellerRekonstrukeur_Zw = 0, TretrativerRekonstrukeur_Zw = 0;

                //Constanten
                const double Ku_MB_OW = 0.36, Ku_MB_MW = 0.9216;//Kupfer
                const double Bl_MB_OW = 0.36, Bl_MB_MW = 0.9216;//Blei
                const double Sa_MB_OW = 0.40, Sa_MB_MW = 1.0240;//Sand
                const double Kh_MB_OW = 0.34, Kh_MB_MW = 0.8704;//Kohle
                const double Sc_MB_OW = 0.40, Sc_MB_MW = 1.0240;//Schrott

                const double Ku_PB_OW = 0.53, Ku_PB_MW = 1.3568;//Kupfer
                const double Bl_PB_OW = 0.53, Bl_PB_MW = 1.3568;//Blei
                const double Sa_PB_OW = 0.60, Sa_PB_MW = 1.5360;//Sand
                const double Kh_PB_OW = 0.48, Kh_PB_MW = 1.2288;//Kohle
                const double Ti_PB_OW = 0.43, Ti_PB_MW = 1.1008;//Kohle
                const double Sc_PB_OW = 0.60, Sc_PB_MW = 1.5360;//Schrott

                const double Ku_LB_OW = 1.63, Ku_LB_MW = 4.1728;//Kupfer
                const double Bl_LB_OW = 1.63, Bl_LB_MW = 4.1728;//Blei
                const double Sa_LB_OW = 1.92, Sa_LB_MW = 4.9152;//Sand
                const double Kh_LB_OW = 1.42, Kh_LB_MW = 3.6352;//Kohle
                const double Ti_LB_OW = 1.25, Ti_LB_MW = 3.2000;//Kohle
                const double Th_LB_OW = 1.12, Th_LB_MW = 2.8672;//Kohle
                const double Sc_LB_OW = 1.92, Sc_LB_MW = 4.9152;//Schrott

                const double Ku_SB_OW = 2.90, Ku_SB_MW = 9.3960;//Kupfer
                const double Bl_SB_OW = 2.90, Bl_SB_MW = 9.3960;//Blei
                const double Sa_SB_OW = 3.42, Sa_SB_MW = 11.0808;//Sand
                const double Kh_SB_OW = 2.52, Kh_SB_MW = 8.1648;//Kohle
                const double Ti_SB_OW = 2.23, Ti_SB_MW = 7.2252;//Kohle
                const double Th_SB_OW = 2.00, Th_SB_MW = 6.4800;//Kohle
                const double Sc_SB_OW = 3.42, Sc_SB_MW = 11.0808;//Schrott

                const double C_MP_Div = 7, C_RP_Div = 48, C_TP_Div = 118.8;//Pumpen

                double Truppe_S = Convert.ToInt32(Truppen_Per_Sec.Value);
                //Truppen Land
                const int Dagger_S = 15, Nova_S = 40, Crawler_S = 10,

                //Truppen Wasser
                     Risso_S = 45, Retusa_S = 50,

                //Truppen Luft
                     Flare_S = 15, Mono_S = 35,

                //Konstruktoren
                    HR_S = 10, MR_S = 30, ER_S = 90, TR_S = 240;

                //infiniti dedected helper
                //Help_class infin_Schrott, infin_Kupfer, infin_Blei, infin_Sand, infin_Kohle, infin_Titan, infin_Thorium,
                //           infin_Schlacke, infin_Wasser, infin_Kryoflüssigkeit, infin_Öl,
                //           infin_SporenPod, infin_Metaglas, infin_Grafit, infin_Silizium, infin_Pyratit, infin_ExplosiveMischung,
                //           infin_Plastanium, infin_Phasengewebe, infin_Spannungslegierung;
                long infin_Schrott = 0, infin_Kupfer = 0, infin_Blei = 0, infin_Sand = 0, infin_Kohle = 0, infin_Titan = 0, infin_Thorium = 0,
                     infin_Schlacke = 0, infin_Wasser = 0, infin_Kryoflüssigkeit = 0, infin_Öl = 0,
                     infin_SporenPod = 0, infin_Metaglas = 0, infin_Grafit = 0, infin_Silizium = 0, infin_Pyratit = 0, infin_ExplosiveMischung = 0,
                     infin_Plastanium = 0, infin_Phasengewebe = 0, infin_Spannungslegierung = 0;

                //Hilfs-Variablen
                long alva;
                double beta;
                bool Strom_only = false;

                //Inizialisierung
                {
                    //Rohstoffe
                    Schrott = Convert.ToInt32(Schrott_Wunsch.Value);
                    Kupfer = Convert.ToInt32(Kupfer_Wunsch.Value);
                    Blei = Convert.ToInt32(Blei_Wunsch.Value);
                    Sand = Convert.ToInt32(Sand_Wunsch.Value);
                    Kohle = Convert.ToInt32(Kohle_Wunsch.Value);
                    Titan = Convert.ToInt32(Titan_Wunsch.Value);
                    Thorium = Convert.ToInt32(Thorium_Wunsch.Value);

                    //Flüssigkeiten
                    Schlacke = Convert.ToInt32(Schlacke_Wunsch.Value);
                    Wasser = Convert.ToInt32(Wasser_Wunsch.Value);
                    Kryoflüssigkeit = Convert.ToInt32(Kryoflüssigkeit_Wunsch.Value);
                    Öl = Convert.ToInt32(Öl_Wunsch.Value);

                    //secundär Rohstoffe
                    WasserExtractor = Convert.ToInt32(WasserExtractor_Zu.Value);
                    Kultivierer = Convert.ToInt32(Kultivierer_Zu.Value);
                    ÖlExtractor = Convert.ToInt32(ÖlExtractor_Zu.Value);
                    Sporenpresse = Convert.ToInt32(Sporenpresse_Zu.Value);
                    Pulverisierer = Convert.ToInt32(Pulverisierer_Zu.Value);
                    Kohlenzentriefuge = Convert.ToInt32(Kohlenzentriefuge_Zu.Value);
                    Kryoflüssigkeitsmixer = Convert.ToInt32(Kryoflüssigkeitsmixer_Zu.Value);
                    Schmelzer = Convert.ToInt32(Schmelzer_Zu.Value);
                    Trenner = Convert.ToInt32(Trenner_Zu.Value);
                    GroßerTrenner = Convert.ToInt32(GroßerTrenner_Zu.Value);

                    WasserExtractor_Pr = 0;//Convert.ToInt64(WasserExtractor_Be.Text);
                    Kultivierer_Pr = 0;//Convert.ToInt64(Kultivierer_Be.Text);
                    ÖlExtractor_Pr = 0;//Convert.ToInt64(ÖlExtractor_Be.Text);
                    Sporenpresse_Pr = 0;//Convert.ToInt64(Sporenpresse_Be.Text);
                    Pulverisierer_Pr = 0;//Convert.ToInt64(Pulverisierer_Be.Text);
                    Kohlenzentriefuge_Pr = 0;//Convert.ToInt64(Kohlenzentriefuge_Be.Text);
                    Kryoflüssigkeitsmixer_Pr = 0;//Convert.ToInt64(Kryoflüssigkeitsmixer_Be.Text);
                    Schmelzer_Pr = 0;//Convert.ToInt64(Schmelzer_Be.Text);
                    Trenner_Pr = 0;//Convert.ToInt64(Trenner_Be.Text);
                    GroßerTrenner_Pr = 0;//Convert.ToInt64(GroßerTrenner_Be.Text);

                    //Fabriken
                    GrafitPresse = Convert.ToInt32(GrafitPresse_Zu.Value);
                    MultiPresse = Convert.ToInt32(MultiPresse_Zu.Value);
                    SiliziumSchmelzer = Convert.ToInt32(SiliziumSchmelzer_Zu.Value);
                    SiliziumSchmelztiegel = Convert.ToInt32(SiliziumSchmelztiegel_Zu.Value);
                    Brennofen = Convert.ToInt32(Brennofen_Zu.Value);
                    PlastaniumVerdichter = Convert.ToInt32(PlastaniumVerdichter_Zu.Value);
                    Phasenweber = Convert.ToInt32(Phasenweber_Zu.Value);
                    Legierungsschmelze = Convert.ToInt32(Legierungsschmelze_Zu.Value);
                    PyratitMixer = Convert.ToInt32(PyratitMixer_Zu.Value);
                    Sprengmixer = Convert.ToInt32(Sprengmixer_Zu.Value);

                    GrafitPresse_Pr = 0;//Convert.ToInt64(Math.Ceiling(Convert.ToDecimal(GrafitPresse_Be.Text) * GrafitPresse_Div.Value));
                    MultiPresse_Pr = 0;//Convert.ToInt64(Math.Ceiling(Convert.ToDecimal(MultiPresse_Be.Text) * MultiPresse_Div.Value));
                    SiliziumSchmelzer_Pr = 0;//Convert.ToInt64(Convert.ToDecimal(SiliziumSchmelzer_Be.Text) * SiliziumSchmelzer_Div.Value);
                    SiliziumSchmelztiegel_Pr = 0;//Convert.ToInt64(Convert.ToDecimal(SiliziumSchmelztiegel_Be.Text) * SiliziumSchmelztiegel_Div.Value);
                    Brennofen_Pr = 0;//Convert.ToInt64(Brennofen_Be.Text);
                    PlastaniumVerdichter_Pr = 0;//Convert.ToInt64(PlastaniumVerdichter_Be.Text);
                    Phasenweber_Pr = 0;//Convert.ToInt64(Phasenweber_Be.Text);
                    Legierungsschmelze_Pr = 0;//Convert.ToInt64(Legierungsschmelze_Be.Text);
                    PyratitMixer_Pr = 0;//Convert.ToInt64(PyratitMixer_Be.Text);
                    Sprengmixer_Pr = 0;//Convert.ToInt64(Sprengmixer_Be.Text);

                    //Produkte
                    SporenPod = Convert.ToInt32(SporenPod_Wunsch.Value);
                    Metaglas = Convert.ToInt32(Metaglas_Wunsch.Value);
                    Grafit = Convert.ToInt32(Grafit_Wunsch.Value);
                    Silizium = Convert.ToInt32(Silizium_Wunsch.Value);
                    Pyratit = Convert.ToInt32(Pyratit_Wunsch.Value);
                    ExplosiveMischung = Convert.ToInt32(ExplosiveMischung_Wunsch.Value);
                    Plastanium = Convert.ToInt32(Plastanium_Wunsch.Value);
                    Phasengewebe = Convert.ToInt32(Phasengewebe_Wunsch.Value);
                    Spannungslegierung = Convert.ToInt32(Spannungslegierung_Wunsch.Value);
                    Strom = Convert.ToInt32(Strom_Wunsch.Value);

                    //Bohrer
                    Kupfer_MB_OW_Value = 0;//Math.Ceiling(Convert.ToDouble(Kupfer_MBohrer_OW_Be.Text));
                    Kupfer_MB_MW_Value = 0;//Math.Ceiling(Convert.ToDouble(Kupfer_MBohrer_MW_Be.Text));
                    Blei_MB_OW_Value = 0;//Math.Ceiling(Convert.ToDouble(Blei_MBohrer_OW_Be.Text));
                    Blei_MB_MW_Value = 0;//Math.Ceiling(Convert.ToDouble(Blei_MBohrer_MW_Be.Text));
                    Sand_MB_OW_Value = 0;//Math.Ceiling(Convert.ToDouble(Sand_MBohrer_OW_Be.Text));
                    Sand_MB_MW_Value = 0;//Math.Ceiling(Convert.ToDouble(Sand_MBohrer_MW_Be.Text));
                    Kohle_MB_OW_Value = 0;//Math.Ceiling(Convert.ToDouble(Kohle_MBohrer_OW_Be.Text));
                    Kohle_MB_MW_Value = 0;//Math.Ceiling(Convert.ToDouble(Kohle_MBohrer_MW_Be.Text));
                    Schrott_MB_OW_Value = 0;//Math.Ceiling(Convert.ToDouble(Schrott_MBohrer_OW_Be.Text));
                    Schrott_MB_MW_Value = 0;//Math.Ceiling(Convert.ToDouble(Schrott_MBohrer_MW_Be.Text));
                    Kupfer_PB_OW_Value = 0;//Math.Ceiling(Convert.ToDouble(Kupfer_PBohrer_OW_Be.Text));
                    Kupfer_PB_MW_Value = 0;//Math.Ceiling(Convert.ToDouble(Kupfer_PBohrer_MW_Be.Text));
                    Blei_PB_OW_Value = 0;//Math.Ceiling(Convert.ToDouble(Blei_PBohrer_OW_Be.Text));
                    Blei_PB_MW_Value = 0;//Math.Ceiling(Convert.ToDouble(Blei_PBohrer_MW_Be.Text));
                    Sand_PB_OW_Value = 0;//Math.Ceiling(Convert.ToDouble(Sand_PBohrer_OW_Be.Text));
                    Sand_PB_MW_Value = 0;//Math.Ceiling(Convert.ToDouble(Sand_PBohrer_MW_Be.Text));
                    Kohle_PB_OW_Value = 0;//Math.Ceiling(Convert.ToDouble(Kohle_PBohrer_OW_Be.Text));
                    Kohle_PB_MW_Value = 0;//Math.Ceiling(Convert.ToDouble(Kohle_PBohrer_MW_Be.Text));
                    Titan_PB_OW_Value = 0;//Math.Ceiling(Convert.ToDouble(Titan_PBohrer_OW_Be.Text));
                    Titan_PB_MW_Value = 0;//Math.Ceiling(Convert.ToDouble(Titan_PBohrer_MW_Be.Text));
                    Schrott_PB_OW_Value = 0;//Math.Ceiling(Convert.ToDouble(Schrott_PBohrer_OW_Be.Text));
                    Schrott_PB_MW_Value = 0;//Math.Ceiling(Convert.ToDouble(Schrott_PBohrer_MW_Be.Text));
                    Kupfer_LB_OW_Value = 0;//Math.Ceiling(Convert.ToDouble(Kupfer_LBohrer_OW_Be.Text));
                    Kupfer_LB_MW_Value = 0;//Math.Ceiling(Convert.ToDouble(Kupfer_LBohrer_MW_Be.Text));
                    Blei_LB_OW_Value = 0;//Math.Ceiling(Convert.ToDouble(Blei_LBohrer_OW_Be.Text));
                    Blei_LB_MW_Value = 0;//Math.Ceiling(Convert.ToDouble(Blei_LBohrer_MW_Be.Text));
                    Sand_LB_OW_Value = 0;//Math.Ceiling(Convert.ToDouble(Sand_LBohrer_OW_Be.Text));
                    Sand_LB_MW_Value = 0;//Math.Ceiling(Convert.ToDouble(Sand_LBohrer_MW_Be.Text));
                    Kohle_LB_OW_Value = 0;//Math.Ceiling(Convert.ToDouble(Kohle_LBohrer_OW_Be.Text));
                    Kohle_LB_MW_Value = 0;//Math.Ceiling(Convert.ToDouble(Kohle_LBohrer_MW_Be.Text));
                    Titan_LB_OW_Value = 0;//Math.Ceiling(Convert.ToDouble(Titan_LBohrer_OW_Be.Text));
                    Titan_LB_MW_Value = 0;//Math.Ceiling(Convert.ToDouble(Titan_LBohrer_MW_Be.Text));
                    Thorium_LB_OW_Value = 0;//Math.Ceiling(Convert.ToDouble(Thorium_LBohrer_OW_Be.Text));
                    Thorium_LB_MW_Value = 0;//Math.Ceiling(Convert.ToDouble(Thorium_LBohrer_MW_Be.Text));
                    Schrott_LB_OW_Value = 0;//Math.Ceiling(Convert.ToDouble(Schrott_LBohrer_OW_Be.Text));
                    Schrott_LB_MW_Value = 0;//Math.Ceiling(Convert.ToDouble(Schrott_LBohrer_MW_Be.Text));
                    Kupfer_SB_OW_Value = 0;//Math.Ceiling(Convert.ToDouble(Kupfer_SBohrer_OW_Be.Text));
                    Kupfer_SB_MW_Value = 0;//Math.Ceiling(Convert.ToDouble(Kupfer_SBohrer_MW_Be.Text));
                    Blei_SB_OW_Value = 0;//Math.Ceiling(Convert.ToDouble(Blei_SBohrer_OW_Be.Text));
                    Blei_SB_MW_Value = 0;//Math.Ceiling(Convert.ToDouble(Blei_SBohrer_MW_Be.Text));
                    Sand_SB_OW_Value = 0;//Math.Ceiling(Convert.ToDouble(Sand_SBohrer_OW_Be.Text));
                    Sand_SB_MW_Value = 0;//Math.Ceiling(Convert.ToDouble(Sand_SBohrer_MW_Be.Text));
                    Kohle_SB_OW_Value = 0;//Math.Ceiling(Convert.ToDouble(Kohle_SBohrer_OW_Be.Text));
                    Kohle_SB_MW_Value = 0;//Math.Ceiling(Convert.ToDouble(Kohle_SBohrer_MW_Be.Text));
                    Titan_SB_OW_Value = 0;//Math.Ceiling(Convert.ToDouble(Titan_SBohrer_OW_Be.Text));
                    Titan_SB_MW_Value = 0;//Math.Ceiling(Convert.ToDouble(Titan_SBohrer_MW_Be.Text));
                    Thorium_SB_OW_Value = 0;//Math.Ceiling(Convert.ToDouble(Thorium_SBohrer_OW_Be.Text));
                    Thorium_SB_MW_Value = 0;//Math.Ceiling(Convert.ToDouble(Thorium_SBohrer_MW_Be.Text));
                    Schrott_SB_OW_Value = 0;//Math.Ceiling(Convert.ToDouble(Schrott_SBohrer_OW_Be.Text));
                    Schrott_SB_MW_Value = 0;//Math.Ceiling(Convert.ToDouble(Schrott_SBohrer_MW_Be.Text));

                    Kupfer_MB_OW_Wunsch = Convert.ToInt64(Kupfer_MBohrer_OW_Zu.Value);
                    Kupfer_MB_MW_Wunsch = Convert.ToInt64(Kupfer_MBohrer_MW_Zu.Value);
                    Blei_MB_OW_Wunsch = Convert.ToInt64(Blei_MBohrer_OW_Zu.Value);
                    Blei_MB_MW_Wunsch = Convert.ToInt64(Blei_MBohrer_MW_Zu.Value);
                    Sand_MB_OW_Wunsch = Convert.ToInt64(Sand_MBohrer_OW_Zu.Value);
                    Sand_MB_MW_Wunsch = Convert.ToInt64(Sand_MBohrer_MW_Zu.Value);
                    Kohle_MB_OW_Wunsch = Convert.ToInt64(Kohle_MBohrer_OW_Zu.Value);
                    Kohle_MB_MW_Wunsch = Convert.ToInt64(Kohle_MBohrer_MW_Zu.Value);
                    Schrott_MB_OW_Wunsch = Convert.ToInt64(Schrott_MBohrer_OW_Zu.Value);
                    Schrott_MB_MW_Wunsch = Convert.ToInt64(Schrott_MBohrer_MW_Zu.Value);
                    Kupfer_PB_OW_Wunsch = Convert.ToInt64(Kupfer_PBohrer_OW_Zu.Value);
                    Kupfer_PB_MW_Wunsch = Convert.ToInt64(Kupfer_PBohrer_MW_Zu.Value);
                    Blei_PB_OW_Wunsch = Convert.ToInt64(Blei_PBohrer_OW_Zu.Value);
                    Blei_PB_MW_Wunsch = Convert.ToInt64(Blei_PBohrer_MW_Zu.Value);
                    Sand_PB_OW_Wunsch = Convert.ToInt64(Sand_PBohrer_OW_Zu.Value);
                    Sand_PB_MW_Wunsch = Convert.ToInt64(Sand_PBohrer_MW_Zu.Value);
                    Kohle_PB_OW_Wunsch = Convert.ToInt64(Kohle_PBohrer_OW_Zu.Value);
                    Kohle_PB_MW_Wunsch = Convert.ToInt64(Kohle_PBohrer_MW_Zu.Value);
                    Titan_PB_OW_Wunsch = Convert.ToInt64(Titan_PBohrer_OW_Zu.Value);
                    Titan_PB_MW_Wunsch = Convert.ToInt64(Titan_PBohrer_MW_Zu.Value);
                    Schrott_PB_OW_Wunsch = Convert.ToInt64(Schrott_PBohrer_OW_Zu.Value);
                    Schrott_PB_MW_Wunsch = Convert.ToInt64(Schrott_PBohrer_MW_Zu.Value);
                    Kupfer_LB_OW_Wunsch = Convert.ToInt64(Kupfer_LBohrer_OW_Zu.Value);
                    Kupfer_LB_MW_Wunsch = Convert.ToInt64(Kupfer_LBohrer_MW_Zu.Value);
                    Blei_LB_OW_Wunsch = Convert.ToInt64(Blei_LBohrer_OW_Zu.Value);
                    Blei_LB_MW_Wunsch = Convert.ToInt64(Blei_LBohrer_MW_Zu.Value);
                    Sand_LB_OW_Wunsch = Convert.ToInt64(Sand_LBohrer_OW_Zu.Value);
                    Sand_LB_MW_Wunsch = Convert.ToInt64(Sand_LBohrer_MW_Zu.Value);
                    Kohle_LB_OW_Wunsch = Convert.ToInt64(Kohle_LBohrer_OW_Zu.Value);
                    Kohle_LB_MW_Wunsch = Convert.ToInt64(Kohle_LBohrer_MW_Zu.Value);
                    Titan_LB_OW_Wunsch = Convert.ToInt64(Titan_LBohrer_OW_Zu.Value);
                    Titan_LB_MW_Wunsch = Convert.ToInt64(Titan_LBohrer_MW_Zu.Value);
                    Thorium_LB_OW_Wunsch = Convert.ToInt64(Thorium_LBohrer_OW_Zu.Value);
                    Thorium_LB_MW_Wunsch = Convert.ToInt64(Thorium_LBohrer_MW_Zu.Value);
                    Schrott_LB_OW_Wunsch = Convert.ToInt64(Schrott_LBohrer_OW_Zu.Value);
                    Schrott_LB_MW_Wunsch = Convert.ToInt64(Schrott_LBohrer_MW_Zu.Value);
                    Kupfer_SB_OW_Wunsch = Convert.ToInt64(Kupfer_SBohrer_OW_Zu.Value);
                    Kupfer_SB_MW_Wunsch = Convert.ToInt64(Kupfer_SBohrer_MW_Zu.Value);
                    Blei_SB_OW_Wunsch = Convert.ToInt64(Blei_SBohrer_OW_Zu.Value);
                    Blei_SB_MW_Wunsch = Convert.ToInt64(Blei_SBohrer_MW_Zu.Value);
                    Sand_SB_OW_Wunsch = Convert.ToInt64(Sand_SBohrer_OW_Zu.Value);
                    Sand_SB_MW_Wunsch = Convert.ToInt64(Sand_SBohrer_MW_Zu.Value);
                    Kohle_SB_OW_Wunsch = Convert.ToInt64(Kohle_SBohrer_OW_Zu.Value);
                    Kohle_SB_MW_Wunsch = Convert.ToInt64(Kohle_SBohrer_MW_Zu.Value);
                    Titan_SB_OW_Wunsch = Convert.ToInt64(Titan_SBohrer_OW_Zu.Value);
                    Titan_SB_MW_Wunsch = Convert.ToInt64(Titan_SBohrer_MW_Zu.Value);
                    Thorium_SB_OW_Wunsch = Convert.ToInt64(Thorium_SBohrer_OW_Zu.Value);
                    Thorium_SB_MW_Wunsch = Convert.ToInt64(Thorium_SBohrer_MW_Zu.Value);
                    Schrott_SB_OW_Wunsch = Convert.ToInt64(Schrott_SBohrer_OW_Zu.Value);
                    Schrott_SB_MW_Wunsch = Convert.ToInt64(Schrott_SBohrer_MW_Zu.Value);

                    //Pumpe
                    Wasser_MP_Value = 0;//Math.Ceiling(Convert.ToDouble(Wasser_MP_Be.Text));
                    Kryoflüssigkeit_MP_Value = 0;//Math.Ceiling(Convert.ToDouble(Kryoflüssigkeit_MP_Be.Text));
                    Öl_MP_Value = 0;//Math.Ceiling(Convert.ToDouble(Öl_MP_Be.Text));
                    Schlacke_MP_Value = 0;//Math.Ceiling(Convert.ToDouble(Schlacke_MP_Be.Text));
                    Wasser_RP_Value = 0;//Math.Ceiling(Convert.ToDouble(Wasser_RP_Be.Text));
                    Kryoflüssigkeit_RP_Value = 0;//Math.Ceiling(Convert.ToDouble(Kryoflüssigkeit_RP_Be.Text));
                    Öl_RP_Value = 0;//Math.Ceiling(Convert.ToDouble(Öl_RP_Be.Text));
                    Schlacke_RP_Value = 0;//Math.Ceiling(Convert.ToDouble(Schlacke_RP_Be.Text));
                    Wasser_TP_Value = 0;//Math.Ceiling(Convert.ToDouble(Wasser_TP_Be.Text));
                    Kryoflüssigkeit_TP_Value = 0;//Math.Ceiling(Convert.ToDouble(Kryoflüssigkeit_TP_Be.Text));
                    Öl_TP_Value = 0;//Math.Ceiling(Convert.ToDouble(Öl_TP_Be.Text));
                    Schlacke_TP_Value = 0;//Math.Ceiling(Convert.ToDouble(Schlacke_TP_Be.Text));

                    Wasser_MP_Wunsch = Convert.ToInt64(Wasser_MP_Zu.Value);
                    Kryoflüssigkeit_MP_Wunsch = Convert.ToInt64(Kryoflüssigkeit_MP_Zu.Value);
                    Öl_MP_Wunsch = Convert.ToInt64(Öl_MP_Zu.Value);
                    Schlacke_MP_Wunsch = Convert.ToInt64(Schlacke_MP_Zu.Value);
                    Wasser_RP_Wunsch = Convert.ToInt64(Wasser_RP_Zu.Value);
                    Kryoflüssigkeit_RP_Wunsch = Convert.ToInt64(Kryoflüssigkeit_RP_Zu.Value);
                    Öl_RP_Wunsch = Convert.ToInt64(Öl_RP_Zu.Value);
                    Schlacke_RP_Wunsch = Convert.ToInt64(Schlacke_RP_Zu.Value);
                    Wasser_TP_Wunsch = Convert.ToInt64(Wasser_TP_Zu.Value);
                    Kryoflüssigkeit_TP_Wunsch = Convert.ToInt64(Kryoflüssigkeit_TP_Zu.Value);
                    Öl_TP_Wunsch = Convert.ToInt64(Öl_TP_Zu.Value);
                    Schlacke_TP_Wunsch = Convert.ToInt64(Schlacke_TP_Zu.Value);

                    //Generatoren
                    Verbrennungsgenerator = Convert.ToInt32(Verbrennungsgenerator_Zu.Value);
                    ThermischerGenerator = Convert.ToInt32(ThermischerGenerator_Zu.Value);
                    Turbinengenerator = Convert.ToInt32(Turbinengenerator_Zu.Value);
                    Differenzialgenerator = Convert.ToInt32(Differenzialgenerator_Zu.Value);
                    RTGGenerator = Convert.ToInt32(RTGGenerator_Zu.Value);
                    Solarpanel = Convert.ToInt32(Solarpanel_Zu.Value);
                    GroßesSolarpanel = Convert.ToInt32(GroßesSolarpanel_Zu.Value);
                    ThoriumReaktor = Convert.ToInt32(ThoriumReaktor_Zu.Value);
                    Schlaggenerator = Convert.ToInt32(Schlaggenerator_Zu.Value);

                    Verbrennungsgenerator_Pr = 0;//Convert.ToInt64(Math.Ceiling(Convert.ToDecimal(Verbrennungsgenerator_Be.Text) * Verbrennungsgenerator_Div.Value));
                    ThermischerGenerator_Pr = 0;//Convert.ToInt64(Math.Ceiling(Convert.ToDecimal(ThermischerGenerator_Be.Text) * ThermischerGenerator_Div.Value));
                    Turbinengenerator_Pr = 0;//Convert.ToInt64(Math.Ceiling(Convert.ToDecimal(Turbinengenerator_Be.Text) * Turbinengenerator_Div.Value));
                    Differenzialgenerator_Pr = 0;//Convert.ToInt64(Math.Ceiling(Convert.ToDecimal(Differenzialgenerator_Be.Text) * Differenzialgenerator_Div.Value));
                    RTGGenerator_Pr = 0;//Convert.ToInt64(Math.Ceiling(Convert.ToDecimal(RTGGenerator_Be.Text) * RTGGenerator_Div.Value));
                    Solarpanel_Pr = 0;//Convert.ToInt64(Math.Ceiling(Convert.ToDecimal(Solarpanel_Be.Text) * Solarpanel_Div.Value));
                    GroßesSolarpanel_Pr = 0;//Convert.ToInt64(Math.Ceiling(Convert.ToDecimal(GroßesSolarpanel_Be.Text) * GroßesSolarpanel_Div.Value));
                    ThoriumReaktor_Pr = 0;//Convert.ToInt64(Math.Ceiling(Convert.ToDecimal(ThoriumReaktor_Be.Text) * ThoriumReaktor_Div.Value));
                    Schlaggenerator_Pr = 0;//Convert.ToInt64(Math.Ceiling(Convert.ToDecimal(Schlaggenerator_Be.Text) * Schlaggenerator_Div.Value));

                    //Mauern
                    Kupfermauer = Convert.ToInt32(Kupfermauer_Zu.Value);
                    GroßeKupfermauer = Convert.ToInt32(GroßeKupfermauer_Zu.Value);
                    Titanmauer = Convert.ToInt32(Titanmauer_Zu.Value);
                    GroßeTitanmauer = Convert.ToInt32(GroßeTitanmauer_Zu.Value);
                    Thoriummauer = Convert.ToInt32(Thoriummauer_Zu.Value);
                    GroßeThoriummauer = Convert.ToInt32(GroßeThoriummauer_Zu.Value);
                    Phasenmauer = Convert.ToInt32(Phasenmauer_Zu.Value);
                    GroßePhasenmauer = Convert.ToInt32(GroßePhasenmauer_Zu.Value);
                    Spannungsmauer = Convert.ToInt32(Spannungsmauer_Zu.Value);
                    GroßeSpannungsmauer = Convert.ToInt32(GroßeSpannungsmauer_Zu.Value);
                    Plastaniummauer = Convert.ToInt32(Plastaniummauer_Zu.Value);
                    GroßePlastaniummauer = Convert.ToInt32(GroßePlastaniummauer_Zu.Value);
                    Tor = Convert.ToInt32(Tor_Zu.Value);
                    GroßesTor = Convert.ToInt32(GroßesTor_Zu.Value);

                    //Schutzeinrichtungen
                    Batterie = Convert.ToInt32(Batterie_Zu.Value);
                    GroßeBatterie = Convert.ToInt32(GroßeBatterie_Zu.Value);
                    Behälter = Convert.ToInt32(Behälter_Zu.Value);
                    Tresor = Convert.ToInt32(Tresor_Zu.Value);
                    Reparateur = Convert.ToInt32(Reparateur_Zu.Value);
                    Reparaturprojektor = Convert.ToInt32(Reparaturprojektor_Zu.Value);
                    BeschleunigungsProjektor = Convert.ToInt32(BeschleunigungsProjektor_Zu.Value);
                    BeschleunigungsMaschine = Convert.ToInt32(BeschleunigungsMaschine_Zu.Value);
                    KraftfeldProjektor = Convert.ToInt32(KraftfeldProjektor_Zu.Value);
                    SchockMine = Convert.ToInt32(SchockMine_Zu.Value);
                    Reparaturpunkt = Convert.ToInt32(Reparaturpunkt_Zu.Value);
                    Reparaturstation = Convert.ToInt32(Reparaturstation_Zu.Value);

                    //Geschütze
                    Doppelgeschütz = Convert.ToInt32(Doppelgeschütz_Zu.Value);
                    Luftgeschütz = Convert.ToInt32(Luftgeschütz_Zu.Value);
                    Scatter = Convert.ToInt32(Scatter_Zu.Value);
                    Hail = Convert.ToInt32(Hail_Zu.Value);
                    Welle = Convert.ToInt32(Welle_Zu.Value);
                    Lancer = Convert.ToInt32(Lancer_Zu.Value);
                    Arcus = Convert.ToInt32(Arcus_Zu.Value);
                    Parallax = Convert.ToInt32(Parallax_Zu.Value);
                    Schwärmer = Convert.ToInt32(Schwärmer_Zu.Value);
                    Salve = Convert.ToInt32(Salve_Zu.Value);
                    Segment = Convert.ToInt32(Segment_Zu.Value);
                    Tsunami = Convert.ToInt32(Tsunami_Zu.Value);
                    Zünder = Convert.ToInt32(Zünder_Zu.Value);
                    Zerstörer = Convert.ToInt32(Zerstörer_Zu.Value);
                    Zyklon = Convert.ToInt32(Zyklon_Zu.Value);
                    Foreshadow = Convert.ToInt32(Foreshadow_Zu.Value);
                    Phantom = Convert.ToInt32(Phantom_Zu.Value);
                    Meltdown = Convert.ToInt32(Meltdown_Zu.Value);

                    //Truppen Produktion
                    //Bodenfabrik = Convert.ToInt32(Bodenfabrik_Zu.Value);
                    //Luftfabrik = Convert.ToInt32(Luftfabrik_Zu.Value);
                    //Wasserfabrik = Convert.ToInt32(Wasserfabrik_Zu.Value);
                    HinzufügenderRekonstrukeur = Convert.ToInt32(HinzufügenderRekonstrukeur_Zu.Value);
                    MultiplikativerRekonstrukeur = Convert.ToInt32(MultiplikativerRekonstrukeur_Zu.Value);
                    ExponenziellerRekonstrukeur = Convert.ToInt32(ExponenziellerRekonstrukeur_Zu.Value);
                    TretrativerRekonstrukeur = Convert.ToInt32(TretrativerRekonstrukeur_Zu.Value);

                    //Truppen Land
                    Dagger = Convert.ToDouble(Dagger_Zu.Value);
                    Mace = Convert.ToDouble(Mace_Zu.Value);
                    Fortress = Convert.ToDouble(Fortress_Zu.Value);
                    Scepter = Convert.ToDouble(Scepter_Zu.Value);
                    Reign = Convert.ToDouble(Reign_Zu.Value);

                    Nova = Convert.ToDouble(Nova_Zu.Value);
                    Pulsar = Convert.ToDouble(Pulsar_Zu.Value);
                    Quasar = Convert.ToDouble(Quasar_Zu.Value);
                    Vela = Convert.ToDouble(Vela_Zu.Value);
                    Korvus = Convert.ToDouble(Korvus_Zu.Value);

                    Crawler = Convert.ToDouble(Crawler_Zu.Value);
                    Atrax = Convert.ToDouble(Atrax_Zu.Value);
                    Spirokt = Convert.ToDouble(Spirokt_Zu.Value);
                    Arkyid = Convert.ToDouble(Arkyid_Zu.Value);
                    Toxopid = Convert.ToDouble(Toxopid_Zu.Value);

                    //Truppen Wasser
                    Risso = Convert.ToDouble(Risso_Zu.Value);
                    Minke = Convert.ToDouble(Minke_Zu.Value);
                    Bryde = Convert.ToDouble(Bryde_Zu.Value);
                    Sei = Convert.ToDouble(Sei_Zu.Value);
                    Omura = Convert.ToDouble(Omura_Zu.Value);

                    Retusa = Convert.ToDouble(Retusa_Zu.Value);
                    Oxynoe = Convert.ToDouble(Oxynoe_Zu.Value);
                    Cyerce = Convert.ToDouble(Cyerce_Zu.Value);
                    Aegires = Convert.ToDouble(Aegires_Zu.Value);
                    Navanax = Convert.ToDouble(Navanax_Zu.Value);

                    //Truppen Luft
                    Flare = Convert.ToDouble(Flare_Zu.Value);
                    Horizont = Convert.ToDouble(Horizont_Zu.Value);
                    Zenit = Convert.ToDouble(Zenit_Zu.Value);
                    Antumbra = Convert.ToDouble(Antumbra_Zu.Value);
                    Eclipse = Convert.ToDouble(Eclipse_Zu.Value);

                    Mono = Convert.ToDouble(Mono_Zu.Value);
                    Poly = Convert.ToDouble(Poly_Zu.Value);
                    Mega = Convert.ToDouble(Mega_Zu.Value);
                    Quad = Convert.ToDouble(Quad_Zu.Value);
                    Okt = Convert.ToDouble(Okt_Zu.Value);
                }
                //Truppen Berechnung
                {
                    //Truppen Produktion
                    //Stufe 1
                    {
                        if (Dagger > 0)
                        {
                            Bodenfabrik_B_Orange = Math.Ceiling(Dagger * (Dagger_S / Truppe_S));
                        }
                        if (Nova > 0)
                        {
                            Bodenfabrik_B_Gruen = Math.Ceiling(Nova * (Nova_S / Truppe_S));
                        }
                        if (Crawler > 0)
                        {
                            Bodenfabrik_B_Lila = Math.Ceiling(Crawler * (Crawler_S / Truppe_S));
                        }
                        if (Risso > 0)
                        {
                            Wasserfabrik_W_Orange = Math.Ceiling(Risso * (Risso_S / Truppe_S));
                        }
                        if (Retusa > 0)
                        {
                            Wasserfabrik_W_Gruen = Math.Ceiling(Retusa * (Retusa_S / Truppe_S));
                        }
                        if (Flare > 0)
                        {
                            Luftfabrik_L_Orange = Math.Ceiling(Flare * (Flare_S / Truppe_S));
                        }
                        if (Mono > 0)
                        {
                            Luftfabrik_L_Gruen = Math.Ceiling(Mono * (Mono_S / Truppe_S));
                        }
                    }
                    //Stufe 2
                    {
                        if (Mace > 0)
                        {
                            HinzufügenderRekonstrukeur_Zw += Math.Ceiling(Mace * (HR_S / Truppe_S));
                            Bodenfabrik_B_Orange += Math.Ceiling(Mace * (Dagger_S / Truppe_S));
                        }
                        if (Pulsar > 0)
                        {
                            HinzufügenderRekonstrukeur_Zw += Math.Ceiling(Pulsar * (HR_S / Truppe_S));
                            Bodenfabrik_B_Gruen += Math.Ceiling(Pulsar * (Nova_S / Truppe_S));
                        }
                        if (Atrax > 0)
                        {
                            HinzufügenderRekonstrukeur_Zw += Math.Ceiling(Atrax * (HR_S / Truppe_S));
                            Bodenfabrik_B_Lila += Math.Ceiling(Atrax * (Crawler_S / Truppe_S));
                        }
                        if (Minke > 0)
                        {
                            HinzufügenderRekonstrukeur_Zw += Math.Ceiling(Minke * (HR_S / Truppe_S));
                            Wasserfabrik_W_Orange += Math.Ceiling(Minke * (Risso_S / Truppe_S));
                        }
                        if (Oxynoe > 0)
                        {
                            HinzufügenderRekonstrukeur_Zw += Math.Ceiling(Oxynoe * (HR_S / Truppe_S));
                            Wasserfabrik_W_Gruen += Math.Ceiling(Oxynoe * (Retusa_S / Truppe_S));
                        }
                        if (Horizont > 0)
                        {
                            HinzufügenderRekonstrukeur_Zw += Math.Ceiling(Horizont * (HR_S / Truppe_S));
                            Luftfabrik_L_Orange += Math.Ceiling(Horizont * (Flare_S / Truppe_S));
                        }
                        if (Poly > 0)
                        {
                            HinzufügenderRekonstrukeur_Zw += Math.Ceiling(Poly * (HR_S / Truppe_S));
                            Luftfabrik_L_Gruen += Math.Ceiling(Poly * (Mono_S / Truppe_S));
                        }
                    }
                    //Stufe 3
                    {
                        if (Fortress > 0)
                        {
                            MultiplikativerRekonstrukeur_Zw += Math.Ceiling(Fortress * (MR_S / Truppe_S));
                            HinzufügenderRekonstrukeur_Zw += Math.Ceiling(Fortress * (HR_S / Truppe_S));
                            Bodenfabrik_B_Orange += Math.Ceiling(Fortress * (Dagger_S / Truppe_S));
                        }
                        if (Quasar > 0)
                        {
                            MultiplikativerRekonstrukeur_Zw += Math.Ceiling(Quasar * (MR_S / Truppe_S));
                            HinzufügenderRekonstrukeur_Zw += Math.Ceiling(Quasar * (HR_S / Truppe_S));
                            Bodenfabrik_B_Gruen += Math.Ceiling(Quasar * (Nova_S / Truppe_S));
                        }
                        if (Spirokt > 0)
                        {
                            MultiplikativerRekonstrukeur_Zw += Math.Ceiling(Spirokt * (MR_S / Truppe_S));
                            HinzufügenderRekonstrukeur_Zw += Math.Ceiling(Spirokt * (HR_S / Truppe_S));
                            Bodenfabrik_B_Lila += Math.Ceiling(Spirokt * (Crawler_S / Truppe_S));
                        }
                        if (Bryde > 0)
                        {
                            MultiplikativerRekonstrukeur_Zw += Math.Ceiling(Bryde * (MR_S / Truppe_S));
                            HinzufügenderRekonstrukeur_Zw += Math.Ceiling(Bryde * (HR_S / Truppe_S));
                            Wasserfabrik_W_Orange += Math.Ceiling(Bryde * (Risso_S / Truppe_S));
                        }
                        if (Cyerce > 0)
                        {
                            MultiplikativerRekonstrukeur_Zw += Math.Ceiling(Cyerce * (MR_S / Truppe_S));
                            HinzufügenderRekonstrukeur_Zw += Math.Ceiling(Cyerce * (HR_S / Truppe_S));
                            Wasserfabrik_W_Gruen += Math.Ceiling(Cyerce * (Retusa_S / Truppe_S));
                        }
                        if (Zenit > 0)
                        {
                            MultiplikativerRekonstrukeur_Zw += Math.Ceiling(Zenit * (MR_S / Truppe_S));
                            HinzufügenderRekonstrukeur_Zw += Math.Ceiling(Zenit * (HR_S / Truppe_S));
                            Luftfabrik_L_Orange += Math.Ceiling(Zenit * (Flare_S / Truppe_S));
                        }
                        if (Mega > 0)
                        {
                            MultiplikativerRekonstrukeur_Zw += Math.Ceiling(Mega * (MR_S / Truppe_S));
                            HinzufügenderRekonstrukeur_Zw += Math.Ceiling(Mega * (HR_S / Truppe_S));
                            Luftfabrik_L_Gruen += Math.Ceiling(Mega * (Mono_S / Truppe_S));
                        }
                    }
                    //Stufe4
                    {
                        if (Scepter > 0)
                        {
                            ExponenziellerRekonstrukeur_Zw += Math.Ceiling(Scepter * (ER_S / Truppe_S));
                            MultiplikativerRekonstrukeur_Zw += Math.Ceiling(Scepter * (MR_S / Truppe_S));
                            HinzufügenderRekonstrukeur_Zw += Math.Ceiling(Scepter * (HR_S / Truppe_S));
                            Bodenfabrik_B_Orange += Math.Ceiling(Scepter * (Dagger_S / Truppe_S));
                        }
                        if (Vela > 0)
                        {
                            ExponenziellerRekonstrukeur_Zw += Math.Ceiling(Vela * (ER_S / Truppe_S));
                            MultiplikativerRekonstrukeur_Zw += Math.Ceiling(Vela * (MR_S / Truppe_S));
                            HinzufügenderRekonstrukeur_Zw += Math.Ceiling(Vela * (HR_S / Truppe_S));
                            Bodenfabrik_B_Gruen += Math.Ceiling(Vela * (Nova_S / Truppe_S));
                        }
                        if (Arkyid > 0)
                        {
                            ExponenziellerRekonstrukeur_Zw += Math.Ceiling(Arkyid * (ER_S / Truppe_S));
                            MultiplikativerRekonstrukeur_Zw += Math.Ceiling(Arkyid * (MR_S / Truppe_S));
                            HinzufügenderRekonstrukeur_Zw += Math.Ceiling(Arkyid * (HR_S / Truppe_S));
                            Bodenfabrik_B_Lila += Math.Ceiling(Arkyid * (Crawler_S / Truppe_S));
                        }
                        if (Sei > 0)
                        {
                            ExponenziellerRekonstrukeur_Zw += Math.Ceiling(Sei * (ER_S / Truppe_S));
                            MultiplikativerRekonstrukeur_Zw += Math.Ceiling(Sei * (MR_S / Truppe_S));
                            HinzufügenderRekonstrukeur_Zw += Math.Ceiling(Sei * (HR_S / Truppe_S));
                            Wasserfabrik_W_Orange += Math.Ceiling(Sei * (Risso_S / Truppe_S));
                        }
                        if (Aegires > 0)
                        {
                            ExponenziellerRekonstrukeur_Zw += Math.Ceiling(Aegires * (ER_S / Truppe_S));
                            MultiplikativerRekonstrukeur_Zw += Math.Ceiling(Aegires * (MR_S / Truppe_S));
                            HinzufügenderRekonstrukeur_Zw += Math.Ceiling(Aegires * (HR_S / Truppe_S));
                            Wasserfabrik_W_Gruen += Math.Ceiling(Aegires * (Retusa_S / Truppe_S));
                        }
                        if (Antumbra > 0)
                        {
                            ExponenziellerRekonstrukeur_Zw += Math.Ceiling(Antumbra * (ER_S / Truppe_S));
                            MultiplikativerRekonstrukeur_Zw += Math.Ceiling(Antumbra * (MR_S / Truppe_S));
                            HinzufügenderRekonstrukeur_Zw += Math.Ceiling(Antumbra * (HR_S / Truppe_S));
                            Luftfabrik_L_Orange += Math.Ceiling(Antumbra * (Flare_S / Truppe_S));
                        }
                        if (Quad > 0)
                        {
                            ExponenziellerRekonstrukeur_Zw += Math.Ceiling(Quad * (ER_S / Truppe_S));
                            MultiplikativerRekonstrukeur_Zw += Math.Ceiling(Quad * (MR_S / Truppe_S));
                            HinzufügenderRekonstrukeur_Zw += Math.Ceiling(Quad * (HR_S / Truppe_S));
                            Luftfabrik_L_Gruen += Math.Ceiling(Quad * (Mono_S / Truppe_S));
                        }
                    }
                    //Stife 5
                    {
                        if (Reign > 0)
                        {
                            TretrativerRekonstrukeur_Zw += Math.Ceiling(Reign * (TR_S / Truppe_S));
                            ExponenziellerRekonstrukeur_Zw += Math.Ceiling(Reign * (TR_S / Truppe_S));
                            MultiplikativerRekonstrukeur_Zw += Math.Ceiling(Reign * (MR_S / Truppe_S));
                            HinzufügenderRekonstrukeur_Zw += Math.Ceiling(Reign * (HR_S / Truppe_S));
                            Bodenfabrik_B_Orange += Math.Ceiling(Reign * (Dagger_S / Truppe_S));
                        }
                        if (Korvus > 0)
                        {
                            TretrativerRekonstrukeur_Zw += Math.Ceiling(Korvus * (TR_S / Truppe_S));
                            ExponenziellerRekonstrukeur_Zw += Math.Ceiling(Korvus * (TR_S / Truppe_S));
                            MultiplikativerRekonstrukeur_Zw += Math.Ceiling(Korvus * (MR_S / Truppe_S));
                            HinzufügenderRekonstrukeur_Zw += Math.Ceiling(Korvus * (HR_S / Truppe_S));
                            Bodenfabrik_B_Gruen += Math.Ceiling(Korvus * (Nova_S / Truppe_S));
                        }
                        if (Toxopid > 0)
                        {
                            TretrativerRekonstrukeur_Zw += Math.Ceiling(Toxopid * (TR_S / Truppe_S));
                            ExponenziellerRekonstrukeur_Zw += Math.Ceiling(Toxopid * (TR_S / Truppe_S));
                            MultiplikativerRekonstrukeur_Zw += Math.Ceiling(Toxopid * (MR_S / Truppe_S));
                            HinzufügenderRekonstrukeur_Zw += Math.Ceiling(Toxopid * (HR_S / Truppe_S));
                            Bodenfabrik_B_Lila += Math.Ceiling(Toxopid * (Crawler_S / Truppe_S));
                        }
                        if (Omura > 0)
                        {
                            TretrativerRekonstrukeur_Zw += Math.Ceiling(Omura * (TR_S / Truppe_S));
                            ExponenziellerRekonstrukeur_Zw += Math.Ceiling(Omura * (TR_S / Truppe_S));
                            MultiplikativerRekonstrukeur_Zw += Math.Ceiling(Omura * (MR_S / Truppe_S));
                            HinzufügenderRekonstrukeur_Zw += Math.Ceiling(Omura * (HR_S / Truppe_S));
                            Wasserfabrik_W_Orange += Math.Ceiling(Omura * (Risso_S / Truppe_S));
                        }
                        if (Navanax > 0)
                        {
                            TretrativerRekonstrukeur_Zw += Math.Ceiling(Navanax * (TR_S / Truppe_S));
                            ExponenziellerRekonstrukeur_Zw += Math.Ceiling(Navanax * (TR_S / Truppe_S));
                            MultiplikativerRekonstrukeur_Zw += Math.Ceiling(Navanax * (MR_S / Truppe_S));
                            HinzufügenderRekonstrukeur_Zw += Math.Ceiling(Navanax * (HR_S / Truppe_S));
                            Wasserfabrik_W_Gruen += Math.Ceiling(Navanax * (Retusa_S / Truppe_S));
                        }
                        if (Eclipse > 0)
                        {
                            TretrativerRekonstrukeur_Zw += Math.Ceiling(Eclipse * (TR_S / Truppe_S));
                            ExponenziellerRekonstrukeur_Zw += Math.Ceiling(Eclipse * (TR_S / Truppe_S));
                            MultiplikativerRekonstrukeur_Zw += Math.Ceiling(Eclipse * (MR_S / Truppe_S));
                            HinzufügenderRekonstrukeur_Zw += Math.Ceiling(Eclipse * (HR_S / Truppe_S));
                            Luftfabrik_L_Orange += Math.Ceiling(Eclipse * (Flare_S / Truppe_S));
                        }
                        if (Okt > 0)
                        {
                            TretrativerRekonstrukeur_Zw += Math.Ceiling(Okt * (TR_S / Truppe_S));
                            ExponenziellerRekonstrukeur_Zw += Math.Ceiling(Okt * (TR_S / Truppe_S));
                            MultiplikativerRekonstrukeur_Zw += Math.Ceiling(Okt * (MR_S / Truppe_S));
                            HinzufügenderRekonstrukeur_Zw += Math.Ceiling(Okt * (HR_S / Truppe_S));
                            Luftfabrik_L_Gruen += Math.Ceiling(Okt * (Mono_S / Truppe_S));
                        }
                    }
                    //Truppenresursen
                    Blei_Pr += (2 / 3) * Bodenfabrik_B_Orange + Bodenfabrik_B_Gruen / 2 + (15 / 35) * Luftfabrik_L_Gruen;
                    Kohle_Pr += Bodenfabrik_B_Lila;
                    Titan_Pr += Bodenfabrik_B_Gruen / 2 + 0.4 * Wasserfabrik_W_Gruen + (8 / 3) * (MultiplikativerRekonstrukeur_Zw + MultiplikativerRekonstrukeur);
                    Kryoflüssigkeit_Pr += 60 * (ExponenziellerRekonstrukeur_Zw + ExponenziellerRekonstrukeur);
                    Metaglas_Pr += (35 / 45) * Wasserfabrik_W_Orange + Wasserfabrik_W_Gruen / 2 + (4 / 3) * (MultiplikativerRekonstrukeur_Zw + MultiplikativerRekonstrukeur) +
                                   (57 / 9) * (ExponenziellerRekonstrukeur_Zw + ExponenziellerRekonstrukeur);
                    Grafit_Pr += 4 * (HinzufügenderRekonstrukeur_Zw + HinzufügenderRekonstrukeur);
                    Silizium_Pr += (2 / 3) * Bodenfabrik_B_Orange + 0.75 * Bodenfabrik_B_Gruen + 0.8 * Bodenfabrik_B_Lila +
                                   Luftfabrik_L_Orange + (30 / 35) * Luftfabrik_L_Gruen + (20 / 45) * Wasserfabrik_W_Orange + 0.3 * Wasserfabrik_W_Gruen +
                                   4 * (HinzufügenderRekonstrukeur_Zw + HinzufügenderRekonstrukeur) + (13 / 3) * (MultiplikativerRekonstrukeur_Zw + MultiplikativerRekonstrukeur) +
                                   (85 / 9) * (ExponenziellerRekonstrukeur_Zw + ExponenziellerRekonstrukeur) + (100 / 24) * (TretrativerRekonstrukeur_Zw + TretrativerRekonstrukeur);
                    Plastanium_Pr += (65 / 9) * (ExponenziellerRekonstrukeur_Zw + ExponenziellerRekonstrukeur) + 2.5 * (TretrativerRekonstrukeur_Zw + TretrativerRekonstrukeur);
                    Phasengewebe_Pr += (35 / 24) * (TretrativerRekonstrukeur_Zw + TretrativerRekonstrukeur);
                    Spannungslegierung_Pr += (50 / 24) * (TretrativerRekonstrukeur_Zw + TretrativerRekonstrukeur);
                    Strom_Pr += Convert.ToInt64(72 * (Bodenfabrik_B_Orange + Bodenfabrik_B_Gruen + Bodenfabrik_B_Lila +
                                Luftfabrik_L_Orange + Luftfabrik_L_Gruen + Wasserfabrik_W_Orange + Wasserfabrik_W_Gruen) +
                                180 * (HinzufügenderRekonstrukeur_Zw + HinzufügenderRekonstrukeur) + 360 * (MultiplikativerRekonstrukeur_Zw + MultiplikativerRekonstrukeur) +
                                780 * (ExponenziellerRekonstrukeur_Zw + ExponenziellerRekonstrukeur) + 1500 * (TretrativerRekonstrukeur_Zw + TretrativerRekonstrukeur));
                }
                //Mauern, Schutzeinrichtungen, Geschütze Berechnung
                {
                    ////Rohstoffe
                    //Kupfer_Pr += Convert.ToInt32(Kupfermauer_Zu.Value) * 6 + Convert.ToInt32(GroßeKupfermauer_Zu.Value) * 24;
                    //Titan_Pr += Convert.ToInt32(Titanmauer_Zu.Value) * 6 + Convert.ToInt32(GroßeTitanmauer_Zu.Value) * 24 + Tor * 6 + GroßesTor * 24;
                    //Thorium_Pr += Convert.ToInt32(Thoriummauer_Zu.Value) * 6 + Convert.ToInt32(GroßeThoriummauer_Zu.Value) * 24;

                    //Produkte
                    //Metaglas_Pr += Plastaniummauer * 5 + GroßePlastaniummauer * 20;
                    Silizium_Pr += Reparateur * 0.15 + BeschleunigungsMaschine * 0.3;// +Tor * 4 + GroßesTor * 16;
                    //Plastanium_Pr += Plastaniummauer * 2 + GroßePlastaniummauer * 8;
                    Phasengewebe_Pr += Reparaturprojektor * 0.15 + BeschleunigungsProjektor * 0.15 + BeschleunigungsMaschine * 0.2;
                    //                   + Convert.ToInt32(Phasenmauer_Zu.Value) * 6 + Convert.ToInt32(GroßePhasenmauer_Zu.Value) * 24 +;
                    //Spannungslegierung_Pr += Convert.ToInt32(Spannungsmauer_Zu.Value) * 6 + Convert.ToInt32(GroßeSpannungsmauer_Zu.Value) * 24;
                    Strom_Pr += Reparaturpunkt * 60 + Reparateur * 18 + Reparaturprojektor * 90 + BeschleunigungsProjektor * 210 + BeschleunigungsMaschine * 600 +
                                KraftfeldProjektor * 240 + Reparaturstation * 300;

                    if (KraftfeldProjektor > 0)
                    {
                        if (KraftfeldProjektor_Versterkung.Text == "Verstärkung")
                        {
                            Phasengewebe_Pr += KraftfeldProjektor * 0.17;
                        }
                        if (KraftfeldProjektor_Kühlung.Text == s_Wasser)
                        {
                            Wasser_Pr += 6;
                        }
                        if (KraftfeldProjektor_Kühlung.Text == s_Kryoflüssigkeit)
                        {
                            Kryoflüssigkeit_Pr += 6;
                        }
                    }
                    if (Reparaturstation > 0)
                    {
                        if (Reparaturstation_Kühlung.Text == s_Wasser)
                        {
                            Wasser_Pr += 9.6;
                        }
                        if (Reparaturstation_Kühlung.Text == s_Kryoflüssigkeit)
                        {
                            Kryoflüssigkeit_Pr += 9.6;
                        }
                    }

                    //Geschütze
                    if (Doppelgeschütz > 0)
                    {
                        if (Doppelgeschütz_Kühlung.Text == s_Keine_Kühlung)
                        {
                            if (Doppelgeschütz_Munition.Text == s_Kupfer)
                            {
                                Kupfer_Pr += Doppelgeschütz * 1.5;
                            }
                            if (Doppelgeschütz_Munition.Text == s_Grafit)
                            {
                                Grafit_Pr += Doppelgeschütz * 0.75;
                            }
                            if (Doppelgeschütz_Munition.Text == s_Silizium)
                            {
                                Silizium_Pr += Doppelgeschütz * 0.9;
                            }
                        }
                        if (Doppelgeschütz_Kühlung.Text == s_Wasser)
                        {
                            if (Doppelgeschütz_Munition.Text == s_Kupfer)
                            {
                                Kupfer_Pr += Doppelgeschütz * 1.8;
                            }
                            if (Doppelgeschütz_Munition.Text == s_Grafit)
                            {
                                Grafit_Pr += Doppelgeschütz * 0.9;
                            }
                            if (Doppelgeschütz_Munition.Text == s_Silizium)
                            {
                                Silizium_Pr += Doppelgeschütz * 1.08;
                            }
                            Wasser_Pr += Doppelgeschütz * 6;
                        }
                        if (Doppelgeschütz_Kühlung.Text == s_Kryoflüssigkeit)
                        {
                            if (Doppelgeschütz_Munition.Text == s_Kupfer)
                            {
                                Kupfer_Pr += Doppelgeschütz * 2.175;
                            }
                            if (Doppelgeschütz_Munition.Text == s_Grafit)
                            {
                                Grafit_Pr += Doppelgeschütz * 1.0875;
                            }
                            if (Doppelgeschütz_Munition.Text == s_Silizium)
                            {
                                Silizium_Pr += Doppelgeschütz * 1.305;
                            }
                            Kryoflüssigkeit_Pr += Doppelgeschütz * 6;
                        }
                    }
                    if (Luftgeschütz > 0)
                    {
                        if (Luftgeschütz_Kühlung.Text == s_Keine_Kühlung)
                        {
                            if (Luftgeschütz_Munition.Text == s_Blei)
                            {
                                Blei_Pr += Luftgeschütz * 1.6667;
                            }
                            if (Luftgeschütz_Munition.Text == s_Schrott)
                            {
                                Schrott_Pr += Luftgeschütz * 1.0667;
                            }
                            if (Luftgeschütz_Munition.Text == s_Metaglas)
                            {
                                Metaglas_Pr += Luftgeschütz * 0.6667;
                            }
                        }
                        if (Luftgeschütz_Kühlung.Text == s_Wasser)
                        {
                            if (Luftgeschütz_Munition.Text == s_Blei)
                            {
                                Blei_Pr += Luftgeschütz * 2.3333;
                            }
                            if (Luftgeschütz_Munition.Text == s_Schrott)
                            {
                                Schrott_Pr += Luftgeschütz * 1.4933;
                            }
                            if (Luftgeschütz_Munition.Text == s_Metaglas)
                            {
                                Metaglas_Pr += Luftgeschütz * 0.9333;
                            }
                            Wasser_Pr += Luftgeschütz * 12;
                        }
                        if (Luftgeschütz_Kühlung.Text == s_Kryoflüssigkeit)
                        {
                            if (Luftgeschütz_Munition.Text == s_Blei)
                            {
                                Blei_Pr += Luftgeschütz * 3.1667;
                            }
                            if (Luftgeschütz_Munition.Text == s_Grafit)
                            {
                                Schrott_Pr += Luftgeschütz * 2.0267;
                            }
                            if (Luftgeschütz_Munition.Text == s_Metaglas)
                            {
                                Metaglas_Pr += Luftgeschütz * 1.2667;
                            }
                            Kryoflüssigkeit_Pr += Luftgeschütz * 12;
                        }
                    }
                    if (Scatter > 0)
                    {
                        if (Scatter_Kühlung.Text == s_Keine_Kühlung)
                        {
                            if (Scatter_Munition.Text == s_Kohle)
                            {
                                Kohle_Pr += Scatter * 3.3333;
                            }
                            if (Scatter_Munition.Text == s_Pyratit)
                            {
                                Pyratit_Pr += Scatter * 1.6667;
                            }
                        }
                        if (Scatter_Kühlung.Text == s_Wasser)
                        {
                            if (Scatter_Munition.Text == s_Kohle)
                            {
                                Kohle_Pr += Scatter * 3.5333;
                            }
                            if (Scatter_Munition.Text == s_Pyratit)
                            {
                                Pyratit_Pr += Scatter * 1.7667;
                            }
                            Wasser_Pr += Scatter * 6;
                        }
                        if (Scatter_Kühlung.Text == s_Kryoflüssigkeit)
                        {
                            if (Scatter_Munition.Text == s_Kohle)
                            {
                                Kohle_Pr += Scatter * 3.7833;
                            }
                            if (Scatter_Munition.Text == s_Pyratit)
                            {
                                Pyratit_Pr += Scatter * 1.8917;
                            }
                            Kryoflüssigkeit_Pr += Scatter * 6;
                        }
                    }
                    if (Hail > 0)
                    {
                        if (Hail_Kühlung.Text == s_Keine_Kühlung)
                        {
                            if (Hail_Munition.Text == s_Pyratit)
                            {
                                Pyratit_Pr += Hail * 0.25;
                            }
                            if (Hail_Munition.Text == s_Grafit)
                            {
                                Grafit_Pr += Hail * 0.5;
                            }
                            if (Hail_Munition.Text == s_Silizium)
                            {
                                Silizium_Pr += Hail * 0.4;
                            }
                        }
                        if (Hail_Kühlung.Text == s_Wasser)
                        {
                            if (Hail_Munition.Text == s_Pyratit)
                            {
                                Pyratit_Pr += Hail * 0.3;
                            }
                            if (Hail_Munition.Text == s_Grafit)
                            {
                                Grafit_Pr += Hail * 0.9;
                            }
                            if (Hail_Munition.Text == s_Silizium)
                            {
                                Silizium_Pr += Hail * 0.48;
                            }
                            Wasser_Pr += Hail * 6;
                        }
                        if (Hail_Kühlung.Text == s_Kryoflüssigkeit)
                        {
                            if (Hail_Munition.Text == s_Pyratit)
                            {
                                Pyratit_Pr += Hail * 0.3625;
                            }
                            if (Hail_Munition.Text == s_Grafit)
                            {
                                Grafit_Pr += Hail * 0.725;
                            }
                            if (Hail_Munition.Text == s_Silizium)
                            {
                                Silizium_Pr += Hail * 0.58;
                            }
                            Kryoflüssigkeit_Pr += Hail * 6;
                        }
                    }
                    if (Welle > 0)
                    {
                        if (Welle_Munition.Text == s_Wasser)
                        {
                            Wasser_Pr += Welle * 20;
                        }
                        if (Welle_Munition.Text == s_Kryoflüssigkeit)
                        {
                            Kryoflüssigkeit_Pr += Welle * 20;
                        }
                        if (Welle_Munition.Text == s_Öl)
                        {
                            Öl_Pr += Welle * 20;
                        }
                        if (Welle_Munition.Text == s_Schlacke)
                        {
                            Schlacke_Pr += Welle * 20;
                        }
                    }
                    if (Lancer > 0)
                    {
                        Strom_Pr += Lancer * 360;
                        if (Lancer_Kühlung.Text == s_Wasser)
                        {
                            Wasser_Pr += Lancer * 12;
                        }
                        if (Lancer_Kühlung.Text == s_Kryoflüssigkeit)
                        {
                            Kryoflüssigkeit_Pr += Lancer * 12;
                        }
                    }
                    if (Arcus > 0)
                    {
                        Strom_Pr += Arcus * 198;
                        if (Arcus_Kühlung.Text == s_Wasser)
                        {
                            Wasser_Pr += Arcus * 6;
                        }
                        if (Arcus_Kühlung.Text == s_Kryoflüssigkeit)
                        {
                            Kryoflüssigkeit_Pr += Arcus * 6;
                        }
                    }
                    if (Parallax > 0)
                    {
                        Strom_Pr += Parallax * 180;
                    }
                    if (Schwärmer > 0)
                    {
                        if (Schwärmer_Kühlung.Text == s_Keine_Kühlung)
                        {
                            if (Schwärmer_Munition.Text == s_Pyratit)
                            {
                                Pyratit_Pr += Schwärmer * 1.6;
                            }
                            if (Schwärmer_Munition.Text == s_ExplosiveMischung)
                            {
                                ExplosiveMischung_Pr += Schwärmer * 1.6;
                            }
                            if (Schwärmer_Munition.Text == s_Spannungslegierung)
                            {
                                Spannungslegierung_Pr += Schwärmer * 2;
                            }
                        }
                        if (Schwärmer_Kühlung.Text == s_Wasser)
                        {
                            if (Schwärmer_Munition.Text == s_Pyratit)
                            {
                                Pyratit_Pr += Schwärmer * 2.56;
                            }
                            if (Schwärmer_Munition.Text == s_ExplosiveMischung)
                            {
                                ExplosiveMischung_Pr += Schwärmer * 2.56;
                            }
                            if (Schwärmer_Munition.Text == s_Spannungslegierung)
                            {
                                Spannungslegierung_Pr += Schwärmer * 3.2;
                            }
                            Wasser_Pr += Schwärmer * 18;
                        }
                        if (Schwärmer_Kühlung.Text == s_Kryoflüssigkeit)
                        {
                            if (Schwärmer_Munition.Text == s_Pyratit)
                            {
                                Pyratit_Pr += Schwärmer * 3.76;
                            }
                            if (Schwärmer_Munition.Text == s_ExplosiveMischung)
                            {
                                ExplosiveMischung_Pr += Schwärmer * 3.76;
                            }
                            if (Schwärmer_Munition.Text == s_Spannungslegierung)
                            {
                                Spannungslegierung_Pr += Schwärmer * 4.7;
                            }
                            Kryoflüssigkeit_Pr += Schwärmer * 18;
                        }
                    }
                    if (Salve > 0)
                    {
                        if (Salve_Kühlung.Text == s_Keine_Kühlung)
                        {
                            if (Salve_Munition.Text == s_Kupfer)
                            {
                                Kupfer_Pr += Salve * 3.87;
                            }
                            if (Salve_Munition.Text == s_Thorium)
                            {
                                Thorium_Pr += Salve * 1.935;
                            }
                            if (Salve_Munition.Text == s_Grafit)
                            {
                                Grafit_Pr += Salve * 1.18035;
                            }
                            if (Salve_Munition.Text == s_Silizium)
                            {
                                Silizium_Pr += Salve * 2.322;
                            }
                            if (Salve_Munition.Text == s_Pyratit)
                            {
                                Pyratit_Pr += Salve * 1.548;
                            }
                        }
                        if (Salve_Kühlung.Text == s_Wasser)
                        {
                            if (Salve_Munition.Text == s_Kupfer)
                            {
                                Kupfer_Pr += Salve * 5.418;
                            }
                            if (Salve_Munition.Text == s_Thorium)
                            {
                                Thorium_Pr += Salve * 2.709;
                            }
                            if (Salve_Munition.Text == s_Grafit)
                            {
                                Grafit_Pr += Salve * 1.65249;
                            }
                            if (Salve_Munition.Text == s_Silizium)
                            {
                                Silizium_Pr += Salve * 3.2508;
                            }
                            if (Salve_Munition.Text == s_Pyratit)
                            {
                                Pyratit_Pr += Salve * 2.1672;
                            }
                            Wasser_Pr += 12;
                        }
                        if (Salve_Kühlung.Text == s_Kryoflüssigkeit)
                        {
                            if (Salve_Munition.Text == s_Kupfer)
                            {
                                Kupfer_Pr += Salve * 7.353;
                            }
                            if (Salve_Munition.Text == s_Thorium)
                            {
                                Thorium_Pr += Salve * 3.6765;
                            }
                            if (Salve_Munition.Text == s_Grafit)
                            {
                                Grafit_Pr += Salve * 2.242665;
                            }
                            if (Salve_Munition.Text == s_Silizium)
                            {
                                Silizium_Pr += Salve * 4.4118;
                            }
                            if (Salve_Munition.Text == s_Pyratit)
                            {
                                Pyratit_Pr += Salve * 2.9412;
                            }
                            Kryoflüssigkeit_Pr += 12;
                        }
                    }
                    if (Segment > 0)
                    {
                        Strom_Pr += Segment * 480;
                    }
                    if (Tsunami > 0)
                    {
                        if (Tsunami_Munition.Text == s_Wasser)
                        {
                            Wasser_Pr += Tsunami * 40;
                        }
                        if (Tsunami_Munition.Text == s_Kryoflüssigkeit)
                        {
                            Kryoflüssigkeit_Pr += Tsunami * 40;
                        }
                        if (Tsunami_Munition.Text == s_Öl)
                        {
                            Öl_Pr += Tsunami * 40;
                        }
                        if (Tsunami_Munition.Text == s_Schlacke)
                        {
                            Schlacke_Pr += Tsunami * 40;
                        }
                    }
                    if (Zünder > 0)
                    {
                        if (Zünder_Kühlung.Text == s_Keine_Kühlung)
                        {
                            if (Zünder_Munition.Text == s_Titan)
                            {
                                Titan_Pr += Zünder * 1.6705;
                            }
                            if (Zünder_Munition.Text == s_Thorium)
                            {
                                Thorium_Pr += Zünder * 1.028;
                            }
                        }
                        if (Zünder_Kühlung.Text == s_Wasser)
                        {
                            if (Zünder_Munition.Text == s_Titan)
                            {
                                Titan_Pr += Zünder * 2.6728;
                            }
                            if (Zünder_Munition.Text == s_Thorium)
                            {
                                Thorium_Pr += Zünder * 1.6448;
                            }
                            Wasser_Pr += Zünder * 18;
                        }
                        if (Zünder_Kühlung.Text == s_Kryoflüssigkeit)
                        {
                            if (Zünder_Munition.Text == s_Titan)
                            {
                                Titan_Pr += Zünder * 2.925675;
                            }
                            if (Zünder_Munition.Text == s_Thorium)
                            {
                                Thorium_Pr += Zünder * 2.4158;
                            }
                            Kryoflüssigkeit_Pr += Zünder * 18;
                        }
                    }
                    if (Zerstörer > 0)
                    {
                        if (Zerstörer_Kühlung.Text == s_Keine_Kühlung)
                        {
                            if (Zerstörer_Munition.Text == s_Grafit)
                            {
                                Grafit_Pr += Zerstörer * 4;
                            }
                            if (Zerstörer_Munition.Text == s_Silizium)
                            {
                                Silizium_Pr += Zerstörer * 3.2;
                            }
                            if (Zerstörer_Munition.Text == s_Pyratit)
                            {
                                Pyratit_Pr += Zerstörer * 2;
                            }
                            if (Zerstörer_Munition.Text == s_ExplosiveMischung)
                            {
                                ExplosiveMischung_Pr += Zerstörer * 2;
                            }
                            if (Zerstörer_Munition.Text == s_Plastanium)
                            {
                                Plastanium_Pr += Zerstörer * 4;
                            }
                        }
                        if (Zerstörer_Kühlung.Text == s_Wasser)
                        {
                            if (Zerstörer_Munition.Text == s_Grafit)
                            {
                                Grafit_Pr += Zerstörer * 6.4;
                            }
                            if (Zerstörer_Munition.Text == s_Silizium)
                            {
                                Silizium_Pr += Zerstörer * 5.12;
                            }
                            if (Zerstörer_Munition.Text == s_Pyratit)
                            {
                                Pyratit_Pr += Zerstörer * 3.2;
                            }
                            if (Zerstörer_Munition.Text == s_ExplosiveMischung)
                            {
                                ExplosiveMischung_Pr += Zerstörer * 3.2;
                            }
                            if (Zerstörer_Munition.Text == s_Plastanium)
                            {
                                Plastanium_Pr += Zerstörer * 6.4;
                            }
                            Wasser_Pr += Zerstörer * 18;
                        }
                        if (Zerstörer_Kühlung.Text == s_Kryoflüssigkeit)
                        {
                            if (Zerstörer_Munition.Text == s_Grafit)
                            {
                                Grafit_Pr += Zerstörer * 9.4;
                            }
                            if (Zerstörer_Munition.Text == s_Silizium)
                            {
                                Silizium_Pr += Zerstörer * 7.52;
                            }
                            if (Zerstörer_Munition.Text == s_Pyratit)
                            {
                                Pyratit_Pr += Zerstörer * 4.7;
                            }
                            if (Zerstörer_Munition.Text == s_ExplosiveMischung)
                            {
                                ExplosiveMischung_Pr += Zerstörer * 4.7;
                            }
                            if (Zerstörer_Munition.Text == s_Plastanium)
                            {
                                Plastanium_Pr += Zerstörer * 9.4;
                            }
                            Kryoflüssigkeit_Pr += Zerstörer * 18;
                        }
                    }
                    if (Zyklon > 0)
                    {
                        if (Zyklon_Kühlung.Text == s_Keine_Kühlung)
                        {
                            if (Zyklon_Munition.Text == s_Metaglas)
                            {
                                Metaglas_Pr += Zyklon * 3;
                            }
                            if (Zyklon_Munition.Text == s_ExplosiveMischung)
                            {
                                ExplosiveMischung_Pr += Zyklon * 1.5;
                            }
                            if (Zyklon_Munition.Text == s_Plastanium)
                            {
                                Plastanium_Pr += Zyklon * 1.875;
                            }
                            if (Zyklon_Munition.Text == s_Spannungslegierung)
                            {
                                Spannungslegierung_Pr += Zyklon * 1.5;
                            }
                        }
                        if (Zyklon_Kühlung.Text == s_Wasser)
                        {
                            if (Zyklon_Munition.Text == s_Metaglas)
                            {
                                Metaglas_Pr += Zyklon * 4.8;
                            }
                            if (Zyklon_Munition.Text == s_ExplosiveMischung)
                            {
                                ExplosiveMischung_Pr += Zyklon * 2.4;
                            }
                            if (Zyklon_Munition.Text == s_Plastanium)
                            {
                                Plastanium_Pr += Zyklon * 3;
                            }
                            if (Zyklon_Munition.Text == s_Spannungslegierung)
                            {
                                Spannungslegierung_Pr += Zyklon * 2.4;
                            }
                            Wasser_Pr += Zyklon * 18;
                        }
                        if (Zyklon_Kühlung.Text == s_Kryoflüssigkeit)
                        {
                            if (Zyklon_Munition.Text == s_Metaglas)
                            {
                                Metaglas_Pr += Zyklon * 7.05;
                            }
                            if (Zyklon_Munition.Text == s_ExplosiveMischung)
                            {
                                ExplosiveMischung_Pr += Zyklon * 3.525;
                            }
                            if (Zyklon_Munition.Text == s_Plastanium)
                            {
                                Plastanium_Pr += Zyklon * 4.40625;
                            }
                            if (Zyklon_Munition.Text == s_Spannungslegierung)
                            {
                                Spannungslegierung_Pr += Zyklon * 3.525;
                            }
                            Kryoflüssigkeit_Pr += Zyklon * 18;
                        }
                    }
                    if (Foreshadow > 0)
                    {
                        Strom_Pr += Foreshadow * 600;
                        if (Foreshadow_Kühlung.Text == s_Keine_Kühlung)
                        {
                            Spannungslegierung_Pr += Foreshadow * 1.5;
                        }
                        if (Foreshadow_Kühlung.Text == s_Wasser)
                        {
                            Spannungslegierung_Pr += Foreshadow * 1.74;
                            Wasser_Pr += Foreshadow * 60;
                        }
                        if (Foreshadow_Kühlung.Text == s_Kryoflüssigkeit)
                        {
                            Spannungslegierung_Pr += Foreshadow * 2.04;
                            Kryoflüssigkeit_Pr += Foreshadow * 60;
                        }
                    }
                    if (Phantom > 0)
                    {
                        if (Phantom_Kühlung.Text == s_Keine_Kühlung)
                        {
                            if (Phantom_Munition.Text == s_Thorium)
                            {
                                Thorium_Pr += Phantom * 4.285;
                            }
                            if (Phantom_Munition.Text == s_Grafit)
                            {
                                Grafit_Pr += Phantom * 3.64425;
                            }
                            if (Phantom_Munition.Text == s_Pyratit)
                            {
                                Pyratit_Pr += Phantom * 2.8567;
                            }
                        }
                        if (Phantom_Kühlung.Text == s_Wasser)
                        {
                            if (Phantom_Munition.Text == s_Thorium)
                            {
                                Thorium_Pr += Phantom * 5.142;
                            }
                            if (Phantom_Munition.Text == s_Grafit)
                            {
                                Grafit_Pr += Phantom * 4.3707;
                            }
                            if (Phantom_Munition.Text == s_Pyratit)
                            {
                                Pyratit_Pr += Phantom * 3.428;
                            }
                            Wasser_Pr += Phantom * 60;
                        }
                        if (Phantom_Kühlung.Text == s_Kryoflüssigkeit)
                        {
                            if (Phantom_Munition.Text == s_Thorium)
                            {
                                Thorium_Pr += Phantom * 6.21325;
                            }
                            if (Phantom_Munition.Text == s_Grafit)
                            {
                                Grafit_Pr += Phantom * 5.2812625;
                            }
                            if (Phantom_Munition.Text == s_Pyratit)
                            {
                                Pyratit_Pr += Phantom * 4.142167;
                            }
                            Kryoflüssigkeit_Pr += Phantom * 60;
                        }
                    }
                    if (Meltdown > 0)//!!!
                    {
                        if (Meltdown_Kühlung.Text == s_Wasser)
                        {
                            Strom_Pr += Meltdown * 1020;
                            Wasser_Pr += Meltdown * 30;
                        }
                        if (Meltdown_Kühlung.Text == s_Kryoflüssigkeit)
                        {
                            Strom_Pr += Meltdown * 1020;
                            Kryoflüssigkeit_Pr += Meltdown * 30;
                        }
                    }

                }

                //Rohstoffe
                double Schrott_Pr_C = Schrott_Pr,
                Kupfer_Pr_C = Kupfer_Pr,
                Blei_Pr_C = Blei_Pr,
                //Sand_Pr_C = Sand_Pr,
                Kohle_Pr_C = Kohle_Pr,
                Titan_Pr_C = Titan_Pr,
                Thorium_Pr_C = Thorium_Pr,

                //Produkte
                SporenPod_Pr_C = SporenPod_Pr,
                Metaglas_Pr_C = Metaglas_Pr,
                Grafit_Pr_C = Grafit_Pr,
                Silizium_Pr_C = Silizium_Pr,
                Pyratit_Pr_C = Pyratit_Pr,
                ExplosiveMischung_Pr_C = ExplosiveMischung_Pr,
                Plastanium_Pr_C = Plastanium_Pr,
                Phasengewebe_Pr_C = Phasengewebe_Pr,
                Spannungslegierung_Pr_C = Spannungslegierung_Pr,

                //Flüssigkeiten
                Schlacke_Pr_C = Schlacke_Pr,
                Wasser_Pr_C = Wasser_Pr,
                Kryoflüssigkeit_Pr_C = Kryoflüssigkeit_Pr,
                Öl_Pr_C = Öl_Pr;

                long Strom_Pr_C = Strom_Pr,
                    Bodenfabrik_Zw = Convert.ToInt64(Math.Ceiling(Bodenfabrik_B_Orange) + Math.Ceiling(Bodenfabrik_B_Gruen) + Math.Ceiling(Bodenfabrik_B_Lila)),
                    Luftfabrik_Zw = Convert.ToInt64(Math.Ceiling(Wasserfabrik_W_Orange) + Math.Ceiling(Wasserfabrik_W_Gruen)),
                    Wasserfabrik_Zw = Convert.ToInt64(Math.Ceiling(Luftfabrik_L_Orange) + Math.Ceiling(Luftfabrik_L_Gruen));

                //Berechnung
                do
                {
                    changed = false;

                    //Produktionskosten
                    //Rohstoffe
                    Schrott_Pr = Schrott_Pr_C + (GroßerTrenner + GroßerTrenner_Pr) * 4 + (Schmelzer + Schmelzer_Pr) * 6 + (Pulverisierer + Pulverisierer_Pr) * 1.5;
                    Kupfer_Pr = Kupfer_Pr_C + (Legierungsschmelze + Legierungsschmelze_Pr) * 2.4;
                    Blei_Pr = Blei_Pr_C + (Brennofen + Brennofen_Pr) * 2 + (Legierungsschmelze + Legierungsschmelze_Pr) * 3.2 + (PyratitMixer + PyratitMixer_Pr) * 1.5;
                    Sand_Pr = (SiliziumSchmelzer + SiliziumSchmelzer_Pr) * 3 + (SiliziumSchmelztiegel + SiliziumSchmelztiegel_Pr) * 4 + (Brennofen + Brennofen_Pr) * 2 +
                              (Phasenweber + Phasenweber_Pr) * 5 + (PyratitMixer + PyratitMixer_Pr) * 1.5 + (ÖlExtractor + ÖlExtractor_Pr) * 1;
                    Kohle_Pr = Kohle_Pr_C + (GrafitPresse + GrafitPresse_Pr) * 1.3333 + (MultiPresse + MultiPresse_Pr) * 6 + (SiliziumSchmelzer + SiliziumSchmelzer_Pr) * 1.5 +
                               (SiliziumSchmelztiegel + SiliziumSchmelztiegel_Pr) * 2.6667 + (PyratitMixer + PyratitMixer_Pr) * 0.75;
                    Titan_Pr = Titan_Pr_C + (PlastaniumVerdichter + PlastaniumVerdichter_Pr) * 2 + (Legierungsschmelze + Legierungsschmelze_Pr) * 1.6 +
                               (Kryoflüssigkeitsmixer + Kryoflüssigkeitsmixer_Pr) * 0.5;
                    Thorium_Pr = Thorium_Pr_C + (Phasenweber + Phasenweber_Pr) * 2;

                    //Produkte
                    SporenPod_Pr = SporenPod_Pr_C + (Sprengmixer + Sprengmixer_Pr) * 0.75 + (Sporenpresse + Sporenpresse_Pr) * 3;
                    Metaglas_Pr = Metaglas_Pr_C;
                    Grafit_Pr = Grafit_Pr_C;
                    Silizium_Pr = Silizium_Pr_C + (Legierungsschmelze + Legierungsschmelze_Pr) * 2.4;
                    Pyratit_Pr = Pyratit_Pr_C + (SiliziumSchmelztiegel + SiliziumSchmelztiegel_Pr) * 0.6666 + (Sprengmixer + Sprengmixer_Pr) * 0.75;
                    ExplosiveMischung_Pr = ExplosiveMischung_Pr_C;
                    Plastanium_Pr = Plastanium_Pr_C;
                    Phasengewebe_Pr = Phasengewebe_Pr_C;
                    Spannungslegierung_Pr = Spannungslegierung_Pr_C;
                    Strom_Pr = Strom_Pr_C + (MultiPresse + MultiPresse_Pr) * 108 + (SiliziumSchmelzer + SiliziumSchmelzer_Pr) * 30 +
                               (SiliziumSchmelztiegel + SiliziumSchmelztiegel_Pr) * 240 + (Brennofen + Brennofen_Pr) * 36 + (PlastaniumVerdichter + PlastaniumVerdichter_Pr) * 180 +
                               (Phasenweber + Phasenweber_Pr) * 300 + (Legierungsschmelze + Legierungsschmelze_Pr) * 240 + (Kryoflüssigkeitsmixer + Kryoflüssigkeitsmixer_Pr) * 60 +
                               (PyratitMixer + PyratitMixer_Pr) * 12 + (Sprengmixer + Sprengmixer_Pr) * 24 + (Schmelzer + Schmelzer_Pr) * 60 + (GroßerTrenner + GroßerTrenner_Pr) * 240 +
                               (Trenner + Trenner_Pr) * 66 + (Sporenpresse + Sporenpresse_Pr) * 42 + (Pulverisierer + Pulverisierer_Pr) * 30 + (Kohlenzentriefuge + Kohlenzentriefuge_Pr) * 42 +
                               (WasserExtractor + WasserExtractor_Pr) * 90 + (Kultivierer + Kultivierer_Pr) * 80 + (ÖlExtractor + ÖlExtractor_Pr) * 180 +
                               Convert.ToInt64(Math.Ceiling(Kupfer_LB_OW_Value) + Math.Ceiling(Kupfer_LB_MW_Value) +
                               Math.Ceiling(Blei_LB_OW_Value) + Math.Ceiling(Blei_LB_MW_Value) +
                               Math.Ceiling(Sand_LB_OW_Value) + Math.Ceiling(Sand_LB_MW_Value) +
                               Math.Ceiling(Kohle_LB_OW_Value) + Math.Ceiling(Kohle_LB_MW_Value) +
                               Math.Ceiling(Titan_LB_OW_Value) + Math.Ceiling(Titan_LB_MW_Value) +
                               Math.Ceiling(Thorium_LB_OW_Value) + Math.Ceiling(Thorium_LB_MW_Value) +
                               Math.Ceiling(Schrott_LB_OW_Value) + Math.Ceiling(Schrott_LB_MW_Value)) * 66 +
                               Convert.ToInt64(Math.Ceiling(Kupfer_SB_OW_Value) + Math.Ceiling(Kupfer_SB_MW_Value) +
                               Math.Ceiling(Blei_SB_OW_Value) + Math.Ceiling(Blei_SB_MW_Value) +
                               Math.Ceiling(Sand_SB_OW_Value) + Math.Ceiling(Sand_SB_MW_Value) +
                               Math.Ceiling(Kohle_SB_OW_Value) + Math.Ceiling(Kohle_SB_MW_Value) +
                               Math.Ceiling(Titan_SB_OW_Value) + Math.Ceiling(Titan_SB_MW_Value) +
                               Math.Ceiling(Thorium_SB_OW_Value) + Math.Ceiling(Thorium_SB_MW_Value) +
                               Math.Ceiling(Schrott_SB_OW_Value) + Math.Ceiling(Schrott_SB_MW_Value)) * 180 +
                               Convert.ToInt64(Math.Ceiling(Wasser_RP_Value) +
                               Math.Ceiling(Kryoflüssigkeit_RP_Value) +
                               Math.Ceiling(Öl_RP_Value) +
                               Math.Ceiling(Schlacke_RP_Value)) * 18 +
                               Convert.ToInt64(Math.Ceiling(Wasser_TP_Value) +
                               Math.Ceiling(Kryoflüssigkeit_TP_Value) +
                               Math.Ceiling(Öl_TP_Value) +
                               Math.Ceiling(Schlacke_TP_Value)) * 78;




                    //Flüssigkeiten
                    Schlacke_Pr = Schlacke_Pr_C + (GroßerTrenner + GroßerTrenner_Pr) * 7.2 + (Trenner + Trenner_Pr) * 4;
                    Wasser_Pr = Wasser_Pr_C + (MultiPresse + MultiPresse_Pr) * 6 + (Kryoflüssigkeitsmixer + Kryoflüssigkeitsmixer_Pr) * 12 +
                                (Kultivierer + Kultivierer_Pr) * 18 + (ÖlExtractor + ÖlExtractor_Pr) * 9;
                    Kryoflüssigkeit_Pr = Kryoflüssigkeit_Pr_C;
                    Öl_Pr = Öl_Pr_C + (PlastaniumVerdichter + PlastaniumVerdichter_Pr) * 15 + (Kohlenzentriefuge + Kohlenzentriefuge_Pr) * 6;

                    M_Strom = 0;

                    //Produkte-Generator
                    if (!Stromberechnung_off)
                    {
                        if ((Verbrennungsgenerator + Verbrennungsgenerator_Pr) > 0)
                        {
                            if (Verbrennungsgenerator_Energie.Text == s_Kohle)
                            {
                                Kohle_Pr += Convert.ToDouble(Verbrennungsgenerator + Verbrennungsgenerator_Pr) * 0.5;
                            }
                            if (Verbrennungsgenerator_Energie.Text == s_SporenPod)
                            {
                                SporenPod_Pr += Convert.ToDouble(Verbrennungsgenerator + Verbrennungsgenerator_Pr) * 0.5;
                            }
                            if (Verbrennungsgenerator_Energie.Text == s_Pyratit)
                            {
                                Pyratit_Pr += Convert.ToDouble(Verbrennungsgenerator + Verbrennungsgenerator_Pr) * 0.5;
                            }
                            if (Verbrennungsgenerator_Energie.Text == s_ExplosiveMischung)
                            {
                                ExplosiveMischung_Pr += Convert.ToDouble(Verbrennungsgenerator + Verbrennungsgenerator_Pr) * 0.5;
                            }
                            M_Strom += 60 / 99;
                        }
                        if ((Turbinengenerator + Turbinengenerator_Pr) > 0)
                        {
                            if (Turbinengenerator_Energie.Text == s_Kohle)
                            {
                                Kohle_Pr += Convert.ToDouble(Turbinengenerator + Turbinengenerator_Pr) * 0.6667;
                            }
                            if (Turbinengenerator_Energie.Text == s_SporenPod)
                            {
                                SporenPod_Pr += Convert.ToDouble(Turbinengenerator + Turbinengenerator_Pr) * 0.6667;
                            }
                            if (Turbinengenerator_Energie.Text == s_Pyratit)
                            {
                                Pyratit_Pr += Convert.ToDouble(Turbinengenerator + Turbinengenerator_Pr) * 0.6667;
                            }
                            if (Turbinengenerator_Energie.Text == s_ExplosiveMischung)
                            {
                                ExplosiveMischung_Pr += Convert.ToDouble(Turbinengenerator + Turbinengenerator_Pr) * 0.6667;
                            }
                            Wasser_Pr += Convert.ToDouble(Turbinengenerator + Turbinengenerator_Pr) * 6;
                            M_Strom += 330 / 99;
                        }
                        if ((Differenzialgenerator + Differenzialgenerator_Pr) > 0)
                        {
                            Pyratit_Pr += (Differenzialgenerator + Differenzialgenerator_Pr) * 0.27273;
                            Kryoflüssigkeit_Pr += (Differenzialgenerator + Differenzialgenerator_Pr) * 6;
                            M_Strom += 1080 / 99;
                        }
                        if ((RTGGenerator + RTGGenerator_Pr) > 0)
                        {
                            if (RTGGenerator_Energie.Text == s_Thorium)
                            {
                                Thorium_Pr += Convert.ToDouble(RTGGenerator + RTGGenerator_Pr) * 0.071428571;
                            }
                            if (RTGGenerator_Energie.Text == s_Phasengewebe)
                            {
                                Phasengewebe_Pr += Convert.ToDouble(RTGGenerator + RTGGenerator_Pr) * 0.071428571;
                            }
                            M_Strom += 270 / 99;
                        }
                        if ((ThoriumReaktor + ThoriumReaktor_Pr) > 0)
                        {
                            Thorium_Pr += Convert.ToDouble(ThoriumReaktor + ThoriumReaktor_Pr) * 0.16667;
                            Kryoflüssigkeit_Pr += Convert.ToDouble(ThoriumReaktor + ThoriumReaktor_Pr) * 2.39;
                            M_Strom += 900 / 99;
                        }
                        if ((Schlaggenerator + Schlaggenerator_Pr) > 0)
                        {
                            ExplosiveMischung_Pr += Convert.ToDouble(Schlaggenerator + Schlaggenerator_Pr) * 0.428571429;
                            Kryoflüssigkeit_Pr += Convert.ToDouble(Schlaggenerator + Schlaggenerator_Pr) * 15;
                            M_Strom += 6300 / 99;
                        }
                        if ((ThermischerGenerator + ThermischerGenerator_Pr) > 0)
                        {
                            M_Strom += 108 / 99;
                        }
                        if ((Solarpanel + Solarpanel_Pr) > 0)
                        {
                            M_Strom += 6 / 99;
                        }
                        if ((GroßesSolarpanel + GroßesSolarpanel_Pr) > 0)
                        {
                            M_Strom += 78 / 99;
                        }
                    }

                    //Erzeugubg
                    {
                        //Rohstoffe
                        Schrott_Er =
                        Schrott_MB_OW_Wunsch * Sc_MB_OW + Math.Ceiling(Schrott_MB_OW_Value) * BM_OW_Div * Sc_MB_OW +
                        Schrott_MB_MW_Wunsch * Sc_MB_MW + Math.Ceiling(Schrott_MB_MW_Value) * BM_MW_Div * Sc_MB_MW +
                        Schrott_PB_OW_Wunsch * Sc_PB_OW + Math.Ceiling(Schrott_PB_OW_Value) * BP_OW_Div * Sc_PB_OW +
                        Schrott_PB_MW_Wunsch * Sc_PB_MW + Math.Ceiling(Schrott_PB_MW_Value) * BP_MW_Div * Sc_PB_MW +
                        Schrott_LB_OW_Wunsch * Sc_LB_OW + Math.Ceiling(Schrott_LB_OW_Value) * BL_OW_Div * Sc_LB_OW +
                        Schrott_LB_MW_Wunsch * Sc_LB_MW + Math.Ceiling(Schrott_LB_MW_Value) * BL_MW_Div * Sc_LB_MW +
                        Schrott_SB_OW_Wunsch * Sc_SB_OW + Math.Ceiling(Schrott_SB_OW_Value) * BS_OW_Div * Sc_SB_OW +
                        Schrott_SB_MW_Wunsch * Sc_SB_MW + Math.Ceiling(Schrott_SB_MW_Value) * BS_MW_Div * Sc_SB_MW;
                        Kupfer_Er =
                        Kupfer_MB_OW_Wunsch * Ku_MB_OW + Math.Ceiling(Kupfer_MB_OW_Value) * BM_OW_Div * Ku_MB_OW +
                        Kupfer_MB_MW_Wunsch * Ku_MB_MW + Math.Ceiling(Kupfer_MB_MW_Value) * BM_MW_Div * Ku_MB_MW +
                        Kupfer_PB_OW_Wunsch * Ku_PB_OW + Math.Ceiling(Kupfer_PB_OW_Value) * BP_OW_Div * Ku_PB_OW +
                        Kupfer_PB_MW_Wunsch * Ku_PB_MW + Math.Ceiling(Kupfer_PB_MW_Value) * BP_MW_Div * Ku_PB_MW +
                        Kupfer_LB_OW_Wunsch * Ku_LB_OW + Math.Ceiling(Kupfer_LB_OW_Value) * BL_OW_Div * Ku_LB_OW +
                        Kupfer_LB_MW_Wunsch * Ku_LB_MW + Math.Ceiling(Kupfer_LB_MW_Value) * BL_MW_Div * Ku_LB_MW +
                        Kupfer_SB_OW_Wunsch * Ku_SB_OW + Math.Ceiling(Kupfer_SB_OW_Value) * BS_OW_Div * Ku_SB_OW +
                        Kupfer_SB_MW_Wunsch * Ku_SB_MW + Math.Ceiling(Kupfer_SB_MW_Value) * BS_MW_Div * Ku_SB_MW +
                        (Trenner + Trenner_Pr) * 0.6833;
                        Blei_Er =
                        Blei_MB_OW_Wunsch * Bl_MB_OW + Math.Ceiling(Blei_MB_OW_Value) * BM_OW_Div * Bl_MB_OW +
                        Blei_MB_MW_Wunsch * Bl_MB_MW + Math.Ceiling(Blei_MB_MW_Value) * BM_MW_Div * Bl_MB_MW +
                        Blei_PB_OW_Wunsch * Bl_PB_OW + Math.Ceiling(Blei_PB_OW_Value) * BP_OW_Div * Bl_PB_OW +
                        Blei_PB_MW_Wunsch * Bl_PB_MW + Math.Ceiling(Blei_PB_MW_Value) * BP_MW_Div * Bl_PB_MW +
                        Blei_LB_OW_Wunsch * Bl_LB_OW + Math.Ceiling(Blei_LB_OW_Value) * BL_OW_Div * Bl_LB_OW +
                        Blei_LB_MW_Wunsch * Bl_LB_MW + Math.Ceiling(Blei_LB_MW_Value) * BL_MW_Div * Bl_LB_MW +
                        Blei_SB_OW_Wunsch * Bl_SB_OW + Math.Ceiling(Blei_SB_OW_Value) * BS_OW_Div * Bl_SB_OW +
                        Blei_SB_MW_Wunsch * Bl_SB_MW + Math.Ceiling(Blei_SB_MW_Value) * BS_MW_Div * Bl_SB_MW +
                        (Trenner + Trenner_Pr) * 0.4333;
                        Sand_Er =
                        Sand_MB_OW_Wunsch * Sa_MB_OW + Math.Ceiling(Sand_MB_OW_Value) * BM_OW_Div * Sa_MB_OW +
                        Sand_MB_MW_Wunsch * Sa_MB_MW + Math.Ceiling(Sand_MB_MW_Value) * BM_MW_Div * Sa_MB_MW +
                        Sand_PB_OW_Wunsch * Sa_PB_OW + Math.Ceiling(Sand_PB_OW_Value) * BP_OW_Div * Sa_PB_OW +
                        Sand_PB_MW_Wunsch * Sa_PB_MW + Math.Ceiling(Sand_PB_MW_Value) * BP_MW_Div * Sa_PB_MW +
                        Sand_LB_OW_Wunsch * Sa_LB_OW + Math.Ceiling(Sand_LB_OW_Value) * BL_OW_Div * Sa_LB_OW +
                        Sand_LB_MW_Wunsch * Sa_LB_MW + Math.Ceiling(Sand_LB_MW_Value) * BL_MW_Div * Sa_LB_MW +
                        Sand_SB_OW_Wunsch * Sa_SB_OW + Math.Ceiling(Sand_SB_OW_Value) * BS_OW_Div * Sa_SB_OW +
                        Sand_SB_MW_Wunsch * Sa_SB_MW + Math.Ceiling(Sand_SB_MW_Value) * BS_MW_Div * Sa_SB_MW +
                        (GroßerTrenner + GroßerTrenner_Pr) * 1.4166 + (Pulverisierer + Pulverisierer_Pr) * 1.5;
                        Kohle_Er =
                        Kohle_MB_OW_Wunsch * Kh_MB_OW + Math.Ceiling(Kohle_MB_OW_Value) * BM_OW_Div * Kh_MB_OW +
                        Kohle_MB_MW_Wunsch * Kh_MB_MW + Math.Ceiling(Kohle_MB_MW_Value) * BM_MW_Div * Kh_MB_MW +
                        Kohle_PB_OW_Wunsch * Kh_PB_OW + Math.Ceiling(Kohle_PB_OW_Value) * BP_OW_Div * Kh_PB_OW +
                        Kohle_PB_MW_Wunsch * Kh_PB_MW + Math.Ceiling(Kohle_PB_MW_Value) * BP_MW_Div * Kh_PB_MW +
                        Kohle_LB_OW_Wunsch * Kh_LB_OW + Math.Ceiling(Kohle_LB_OW_Value) * BL_OW_Div * Kh_LB_OW +
                        Kohle_LB_MW_Wunsch * Kh_LB_MW + Math.Ceiling(Kohle_LB_MW_Value) * BL_MW_Div * Kh_LB_MW +
                        Kohle_SB_OW_Wunsch * Kh_SB_OW + Math.Ceiling(Kohle_SB_OW_Value) * BS_OW_Div * Kh_SB_OW +
                        Kohle_SB_MW_Wunsch * Kh_SB_MW + Math.Ceiling(Kohle_SB_MW_Value) * BS_MW_Div * Kh_SB_MW +
                        (Kohlenzentriefuge + Kohlenzentriefuge_Pr) * 2;
                        Titan_Er =
                        Titan_PB_OW_Wunsch * Ti_PB_OW + Math.Ceiling(Titan_PB_OW_Value) * BP_OW_Div * Ti_PB_OW +
                        Titan_PB_MW_Wunsch * Ti_PB_MW + Math.Ceiling(Titan_PB_MW_Value) * BP_MW_Div * Ti_PB_MW +
                        Titan_LB_OW_Wunsch * Ti_LB_OW + Math.Ceiling(Titan_LB_OW_Value) * BL_OW_Div * Ti_LB_OW +
                        Titan_LB_MW_Wunsch * Ti_LB_MW + Math.Ceiling(Titan_LB_MW_Value) * BL_MW_Div * Ti_LB_MW +
                        Titan_SB_OW_Wunsch * Ti_SB_OW + Math.Ceiling(Titan_SB_OW_Value) * BS_OW_Div * Ti_SB_OW +
                        Titan_SB_MW_Wunsch * Ti_SB_MW + Math.Ceiling(Titan_SB_MW_Value) * BS_MW_Div * Ti_SB_MW +
                        (Trenner + Trenner_Pr) * 0.25 + (GroßerTrenner + GroßerTrenner_Pr) * 0.8333;
                        Thorium_Er =
                        Thorium_LB_OW_Wunsch * Th_LB_OW + Math.Ceiling(Thorium_LB_OW_Value) * BL_OW_Div * Th_LB_OW +
                        Thorium_LB_MW_Wunsch * Th_LB_MW + Math.Ceiling(Thorium_LB_MW_Value) * BL_MW_Div * Th_LB_MW +
                        Thorium_SB_OW_Wunsch * Th_SB_OW + Math.Ceiling(Thorium_SB_OW_Value) * BS_OW_Div * Th_SB_OW +
                        Thorium_SB_MW_Wunsch * Th_SB_MW + Math.Ceiling(Thorium_SB_MW_Value) * BS_MW_Div * Th_SB_MW +
                        (GroßerTrenner + GroßerTrenner_Pr) * 0.8166;

                        //Flüssigkeiten
                        Schlacke_Er = Convert.ToDouble(Schlacke_MP_Value) * C_MP_Div * MP_Div + Convert.ToDouble(Schlacke_MP_Wunsch) * C_MP_Div +
                                      Convert.ToDouble(Schlacke_RP_Value) * C_RP_Div * RP_Div + Convert.ToDouble(Schlacke_RP_Wunsch) * C_RP_Div +
                                      Convert.ToDouble(Schlacke_TP_Value) * C_TP_Div * TP_Div + Convert.ToDouble(Schlacke_TP_Wunsch) * C_TP_Div +
                                      (Schmelzer + Schmelzer_Pr) * 12;
                        Wasser_Er = Convert.ToDouble(Wasser_MP_Value) * C_MP_Div * MP_Div + Convert.ToDouble(Wasser_MP_Wunsch) * C_MP_Div +
                                    Convert.ToDouble(Wasser_RP_Value) * C_RP_Div * RP_Div + Convert.ToDouble(Wasser_RP_Wunsch) * C_RP_Div +
                                    Convert.ToDouble(Wasser_TP_Value) * C_TP_Div * TP_Div + Convert.ToDouble(Wasser_TP_Wunsch) * C_TP_Div +
                                    (WasserExtractor + WasserExtractor_Pr) * 6.6;
                        Kryoflüssigkeit_Er = (Convert.ToDouble(Kryoflüssigkeit_MP_Value) * C_MP_Div * MP_Div + Convert.ToDouble(Kryoflüssigkeit_MP_Wunsch) * C_MP_Div +
                                             Convert.ToDouble(Kryoflüssigkeit_RP_Value) * C_RP_Div * RP_Div + Convert.ToDouble(Kryoflüssigkeit_RP_Wunsch) * C_RP_Div +
                                             Convert.ToDouble(Kryoflüssigkeit_TP_Value) * C_TP_Div * TP_Div + Convert.ToDouble(Kryoflüssigkeit_TP_Wunsch) * C_TP_Div) / 2 +
                                             (Kryoflüssigkeitsmixer + Kryoflüssigkeitsmixer_Pr) * 12;
                        Öl_Er = Convert.ToDouble(Öl_MP_Value) * C_MP_Div * MP_Div + Convert.ToDouble(Öl_MP_Wunsch) * C_MP_Div +
                                Convert.ToDouble(Öl_RP_Value) * C_RP_Div * RP_Div + Convert.ToDouble(Öl_RP_Wunsch) * C_RP_Div +
                                Convert.ToDouble(Öl_TP_Value) * C_TP_Div * TP_Div + Convert.ToDouble(Öl_TP_Wunsch) * C_TP_Div +
                                (ÖlExtractor + ÖlExtractor_Pr) * 15 +
                                (Sporenpresse + Sporenpresse_Pr) * 18;


                        //Produkte
                        SporenPod_Er = (Kultivierer + Kultivierer_Pr) * 0.6;
                        Metaglas_Er = (Brennofen + Brennofen_Pr) * 2;
                        Grafit_Er = (GrafitPresse + GrafitPresse_Pr) * 0.6667 + (MultiPresse + MultiPresse_Pr) * 4 +
                                    (GroßerTrenner + GroßerTrenner_Pr) * 0.7667 + (Trenner + Trenner_Pr) * 0.1833;
                        Silizium_Er = (SiliziumSchmelzer + SiliziumSchmelzer_Pr) * 1.5 + (SiliziumSchmelztiegel + SiliziumSchmelztiegel_Pr) * 5.3333;
                        Pyratit_Er = (PyratitMixer + PyratitMixer_Pr) * 0.75;
                        ExplosiveMischung_Er = (Sprengmixer + Sprengmixer_Pr) * 0.75;
                        Plastanium_Er = (PlastaniumVerdichter + PlastaniumVerdichter_Pr);
                        Phasengewebe_Er = (Phasenweber + Phasenweber_Pr) * 0.5;
                        Spannungslegierung_Er = (Legierungsschmelze + Legierungsschmelze_Pr) * 0.8;
                        Strom_Er = (Verbrennungsgenerator + Verbrennungsgenerator_Pr) * 60 + (ThermischerGenerator + ThermischerGenerator_Pr) * 108 +
                                   (Turbinengenerator + Turbinengenerator_Pr) * 330 + (Differenzialgenerator + Differenzialgenerator_Pr) * 1080 +
                                   (RTGGenerator + RTGGenerator_Pr) * 270 + (Solarpanel + Solarpanel_Pr) * 6 + (GroßesSolarpanel + GroßesSolarpanel_Pr) * 78 +
                                   (ThoriumReaktor + ThoriumReaktor_Pr) * 900 + (Schlaggenerator + Schlaggenerator_Pr) * 6300;

                        //Strom_only = false;

                        //beta = Kohle_Pr - Convert.ToDouble(Turbinengenerator + Turbinengenerator_Pr) * 0.6667;
                        //if (!Strom_only && beta < 0.0001)
                        //{
                        //    Strom_only = true;
                        //}

                        //beta = SporenPod_Pr - Convert.ToDouble(Turbinengenerator + Turbinengenerator_Pr) * 0.6667;
                        //if (!Strom_only && beta < 0.0001)
                        //{
                        //    Strom_only = true;
                        //}

                        //beta = Pyratit_Pr - Convert.ToDouble(Turbinengenerator + Turbinengenerator_Pr) * 0.6667 + (Differenzialgenerator + Differenzialgenerator_Pr) * 0.27273;
                        //if (!Strom_only && beta < 0.0001)
                        //{
                        //    Strom_only = true;
                        //}

                        //beta = ExplosiveMischung_Pr - Convert.ToDouble(Turbinengenerator + Turbinengenerator_Pr) * 0.6667 + Convert.ToDouble(Schlaggenerator + Schlaggenerator_Pr) * 0.428571429;
                        //if (!Strom_only && beta < 0.0001)
                        //{
                        //    Strom_only = true;
                        //}

                        //beta = Thorium_Pr - Convert.ToDouble(RTGGenerator + RTGGenerator_Pr) * 0.071428571 + Convert.ToDouble(ThoriumReaktor + ThoriumReaktor_Pr) * 0.16667;
                        //if (!Strom_only && beta < 0.0001)
                        //{
                        //    Strom_only = true;
                        //}

                        //beta = Phasengewebe_Pr - Convert.ToDouble(RTGGenerator + RTGGenerator_Pr) * 0.071428571;
                        //if (!Strom_only && beta < 0.0001)
                        //{
                        //    Strom_only = true;
                        //}

                        //if (Kohle_Pr - (Convert.ToDouble(Turbinengenerator + Turbinengenerator_Pr) * 0.6667) < 0.0001 &&
                        //    SporenPod_Pr - (Convert.ToDouble(Turbinengenerator + Turbinengenerator_Pr) * 0.6667) < 0.0001 &&
                        //    Pyratit_Pr - (Convert.ToDouble(Turbinengenerator + Turbinengenerator_Pr) * 0.6667 + (Differenzialgenerator + Differenzialgenerator_Pr) * 0.27273) < 0.0001 &&
                        //    ExplosiveMischung_Pr - (Convert.ToDouble(Turbinengenerator + Turbinengenerator_Pr) * 0.6667 + Convert.ToDouble(Schlaggenerator + Schlaggenerator_Pr) * 0.428571429) < 0.0001 &&
                        //    Thorium_Pr - (Convert.ToDouble(RTGGenerator + RTGGenerator_Pr) * 0.071428571 + Convert.ToDouble(ThoriumReaktor + ThoriumReaktor_Pr) * 0.16667) < 0.0001 &&
                        //    Phasengewebe_Pr - (Convert.ToDouble(RTGGenerator + RTGGenerator_Pr) * 0.071428571) < 0.0001
                        //    )
                        //{
                        //    Strom_only = true;
                        //    //Strom_only = false;
                        //}
                        //else
                        //{
                        //    Strom_only = false;
                        //}
                    }
                    //Rohstoffe
                    //Schrott
                    if (((Schrott + Schrott_Pr) > Schrott_Er + 0.01) || ((Schrott + Schrott_Pr) > (Schrott_Er + 20)))
                    {
                        changed = true;
                        if (BM_OW_Div > 0)
                        {
                            Schrott_MB_OW_Value = (Schrott + Schrott_Pr) / (Sc_MB_OW);
                        }
                        //else
                        //{
                        //    Schrott_MB_OW_Value = 0;
                        //}
                        if (BM_MW_Div > 0)
                        {
                            Schrott_MB_MW_Value = (Schrott + Schrott_Pr) / (Sc_MB_MW);
                        }
                        //else
                        //{
                        //    Schrott_MB_MW_Value = 0;
                        //}
                        if (BP_OW_Div > 0)
                        {
                            Schrott_PB_OW_Value = (Schrott + Schrott_Pr) / (Sc_PB_OW);
                        }
                        //else
                        //{
                        //    Schrott_PB_OW_Value = 0;
                        //}
                        if (BP_MW_Div > 0)
                        {
                            Schrott_PB_MW_Value = (Schrott + Schrott_Pr) / (Sc_PB_MW);
                        }
                        //else
                        //{
                        //    Schrott_PB_MW_Value = 0;
                        //}
                        if (BL_OW_Div > 0)
                        {
                            Schrott_LB_OW_Value = (Schrott + Schrott_Pr) / (Sc_LB_OW);
                        }
                        //else
                        //{
                        //    Schrott_LB_OW_Value = 0;
                        //}
                        if (BL_MW_Div > 0)
                        {
                            Schrott_LB_MW_Value = (Schrott + Schrott_Pr) / (Sc_LB_MW);
                        }
                        //else
                        //{
                        //    Schrott_LB_MW_Value = 0;
                        //}
                        if (BS_OW_Div > 0)
                        {
                            //Schrott_SB_OW_Value = (Schrott + Schrott_Pr) / (BS_OW_Div * Sc_SB_OW);
                            Schrott_SB_OW_Value = (Schrott + Schrott_Pr) / (Sc_SB_OW);
                        }
                        //else
                        //{
                        //    Schrott_SB_OW_Value = 0;
                        //}
                        if (BS_MW_Div > 0)
                        {
                            //Schrott_SB_MW_Value = (Schrott + Schrott_Pr) / (BS_MW_Div * Sc_SB_MW);
                            Schrott_SB_MW_Value = (Schrott + Schrott_Pr) / (Sc_SB_MW);
                        }
                        //else
                        //{
                        //    Schrott_SB_MW_Value = 0;
                        //}
                    }
                    //Kupfer
                    if (((Kupfer + Kupfer_Pr) > Kupfer_Er + 0.01) || ((Kupfer + Kupfer_Pr) > (Kupfer_Er + 20 + (Trenner + Trenner_Pr) * 0.6833)))
                    {
                        changed = true;
                        if (Kupfer_aweleble.Checked)
                        {
                            beta = (Kupfer + Kupfer_Pr) - (Trenner + Trenner_Pr) * 0.6833;
                            if (beta <= 0)
                            {
                                beta = 0;
                            }
                            if (BM_OW_Div > 0)
                            {
                                Kupfer_MB_OW_Value = beta / (Ku_MB_OW);
                            }
                            //else
                            //{
                            //    Kupfer_MB_OW_Value = 0;
                            //}
                            if (BM_MW_Div > 0)
                            {
                                Kupfer_MB_MW_Value = beta / (Ku_MB_MW);
                            }
                            //else
                            //{
                            //    Kupfer_MB_MW_Value = 0;
                            //}
                            if (BP_OW_Div > 0)
                            {
                                Kupfer_PB_OW_Value = beta / (Ku_PB_OW);
                            }
                            //else
                            //{
                            //    Kupfer_PB_OW_Value = 0;
                            //}
                            if (BP_MW_Div > 0)
                            {
                                Kupfer_PB_MW_Value = beta / (Ku_PB_MW);
                            }
                            //else
                            //{
                            //    Kupfer_PB_MW_Value = 0;
                            //}
                            if (BL_OW_Div > 0)
                            {
                                Kupfer_LB_OW_Value = beta / (Ku_LB_OW);
                            }
                            //else
                            //{
                            //    Kupfer_LB_OW_Value = 0;
                            //}
                            if (BL_MW_Div > 0)
                            {
                                Kupfer_LB_MW_Value = beta / (Ku_LB_MW);
                            }
                            //else
                            //{
                            //    Kupfer_LB_MW_Value = 0;
                            //}
                            if (BS_OW_Div > 0)
                            {
                                Kupfer_SB_OW_Value = beta / (Ku_SB_OW);
                            }
                            //else
                            //{
                            //    Kupfer_SB_OW_Value = 0;
                            //}
                            if (BS_MW_Div > 0)
                            {
                                Kupfer_SB_MW_Value = beta / (Ku_SB_MW);
                            }
                            //else
                            //{
                            //    Kupfer_SB_MW_Value = 0;
                            //}
                        }
                        else
                        {
                            alva = Convert.ToInt64(Math.Ceiling((Kupfer + Kupfer_Pr) / 0.6833));
                            if (Trenner_Pr < alva || alva == 0)
                            {
                                Trenner_Pr = alva;
                            }
                            Kupfer_MB_OW_Value = 0;
                            Kupfer_MB_MW_Value = 0;
                            Kupfer_PB_OW_Value = 0;
                            Kupfer_PB_MW_Value = 0;
                            Kupfer_LB_OW_Value = 0;
                            Kupfer_LB_MW_Value = 0;
                            Kupfer_SB_OW_Value = 0;
                            Kupfer_SB_MW_Value = 0;
                        }
                    }
                    //Blei
                    if (((Blei + Blei_Pr) > Blei_Er + 0.01) || ((Blei + Blei_Pr) > (Blei_Er + 20 + (Trenner + Trenner_Pr) * 0.4333)))
                    {
                        changed = true;
                        if (Blei_aweleble.Checked)
                        {
                            beta = (Blei + Blei_Pr) - (Trenner + Trenner_Pr) * 0.4333;
                            if (beta <= 0)
                            {
                                beta = 0;
                            }
                            if (BM_OW_Div > 0)
                            {
                                Blei_MB_OW_Value = beta / (Bl_MB_OW);
                            }
                            //else
                            //{
                            //    Blei_MB_OW_Value = 0;
                            //}
                            if (BM_MW_Div > 0)
                            {
                                Blei_MB_MW_Value = beta / (Bl_MB_MW);
                            }
                            //else
                            //{
                            //    Blei_MB_MW_Value = 0;
                            // }
                            if (BP_OW_Div > 0)
                            {
                                Blei_PB_OW_Value = beta / (Bl_PB_OW);
                            }
                            //else
                            //{
                            //    Blei_PB_OW_Value = 0;
                            //}
                            if (BP_MW_Div > 0)
                            {
                                Blei_PB_MW_Value = beta / (Bl_PB_MW);
                            }
                            //else
                            //{
                            //    Blei_PB_MW_Value = 0;
                            //}
                            if (BL_OW_Div > 0)
                            {
                                Blei_LB_OW_Value = beta / (Bl_LB_OW);
                            }
                            //else
                            //{
                            //    Blei_LB_OW_Value = 0;
                            //}
                            if (BL_MW_Div > 0)
                            {
                                Blei_LB_MW_Value = beta / (Bl_LB_MW);
                            }
                            //else
                            //{
                            //    Blei_LB_MW_Value = 0;
                            //}
                            if (BS_OW_Div > 0)
                            {
                                Blei_SB_OW_Value = beta / (Bl_SB_OW);
                            }
                            //else
                            //{
                            //    Blei_SB_OW_Value = 0;
                            //}
                            if (BS_MW_Div > 0)
                            {
                                Blei_SB_MW_Value = beta / (Bl_SB_MW);
                            }
                            //else
                            //{
                            //    Blei_SB_MW_Value = 0;
                            //}
                        }
                        else
                        {
                            alva = Convert.ToInt64(Math.Ceiling((Blei + Blei_Pr) / 0.4333));
                            if (Trenner_Pr < alva || alva == 0)
                            {
                                Trenner_Pr = alva;
                            }
                            Blei_MB_OW_Value = 0;
                            Blei_MB_MW_Value = 0;
                            Blei_PB_OW_Value = 0;
                            Blei_PB_MW_Value = 0;
                            Blei_LB_OW_Value = 0;
                            Blei_LB_MW_Value = 0;
                            Blei_SB_OW_Value = 0;
                            Blei_SB_MW_Value = 0;
                        }
                    }
                    //Sand
                    if (((Sand + Sand_Pr) > Sand_Er + 0.01) || ((Sand + Sand_Pr) > (Sand_Er + 20 + (GroßerTrenner + GroßerTrenner_Pr) * 1.4166)))
                    {
                        changed = true;
                        if (Sand_aweleble.Checked)
                        {
                            beta = (Sand + Sand_Pr) - (GroßerTrenner + GroßerTrenner_Pr) * 1.4166;
                            if (beta <= 0)
                            {
                                beta = 0;
                            }
                            if (BM_OW_Div > 0)
                            {
                                Sand_MB_OW_Value = beta / (Sa_MB_OW);
                            }
                            //else
                            //{
                            //    Sand_MB_OW_Value = 0;
                            //}
                            if (BM_MW_Div > 0)
                            {
                                Sand_MB_MW_Value = beta / (Sa_MB_MW);
                            }
                            //else
                            //{
                            //    Sand_MB_MW_Value = 0;
                            //}
                            if (BP_OW_Div > 0)
                            {
                                Sand_PB_OW_Value = beta / (Sa_PB_OW);
                            }
                            //else
                            //{
                            //    Sand_PB_OW_Value = 0;
                            //}
                            if (BP_MW_Div > 0)
                            {
                                Sand_PB_MW_Value = beta / (Sa_PB_MW);
                            }
                            //else
                            //{
                            //    Sand_PB_MW_Value = 0;
                            //}
                            if (BL_OW_Div > 0)
                            {
                                Sand_LB_OW_Value = beta / (Sa_LB_OW);
                            }
                            //else
                            //{
                            //    Sand_LB_OW_Value = 0;
                            //}
                            if (BL_MW_Div > 0)
                            {
                                Sand_LB_MW_Value = beta / (Sa_LB_MW);
                            }
                            //else
                            //{
                            //    Sand_LB_MW_Value = 0;
                            //}
                            if (BS_OW_Div > 0)
                            {
                                Sand_SB_OW_Value = beta / (Sa_SB_OW);
                            }
                            //else
                            //{
                            //    Sand_SB_OW_Value = 0;
                            //}
                            if (BS_MW_Div > 0)
                            {
                                Sand_SB_MW_Value = beta / (Sa_SB_MW);
                            }
                            //else
                            //{
                            //    Sand_SB_MW_Value = 0;
                            //}
                        }
                        else
                        {
                            //alva = Convert.ToInt64(Math.Ceiling((Sand + Sand_Pr) / 1.4166));
                            //if (GroßerTrenner_Pr < alva)
                            //{
                            //    GroßerTrenner_Pr = alva;
                            //}
                            Pulverisierer_Pr = Convert.ToInt64(Math.Ceiling((Sand + Sand_Pr) / 1.5));
                            Sand_MB_OW_Value = 0;
                            Sand_MB_MW_Value = 0;
                            Sand_PB_OW_Value = 0;
                            Sand_PB_MW_Value = 0;
                            Sand_LB_OW_Value = 0;
                            Sand_LB_MW_Value = 0;
                            Sand_SB_OW_Value = 0;
                            Sand_SB_MW_Value = 0;
                        }
                    }
                    //Kohle
                    if (((Kohle + Kohle_Pr) > Kohle_Er + 0.01) || ((Kohle + Kohle_Pr) > (Kohle_Er + 20)))
                    {
                        changed = true;
                        if (Strom_only)
                        {
                            //Kohle = 0;
                            Kohle_Pr = 0;
                        }
                        if (Kohle_aweleble.Checked)
                        {
                            if (BM_OW_Div > 0)
                            {
                                Kohle_MB_OW_Value = (Kohle + Kohle_Pr) / (Kh_MB_OW);
                            }
                            //else
                            //{
                            //    Kohle_MB_OW_Value = 0;
                            //}
                            if (BM_MW_Div > 0)
                            {
                                Kohle_MB_MW_Value = (Kohle + Kohle_Pr) / (Kh_MB_MW);
                            }
                            //else
                            //{
                            //    Kohle_MB_MW_Value = 0;
                            //}
                            if (BP_OW_Div > 0)
                            {
                                Kohle_PB_OW_Value = (Kohle + Kohle_Pr) / (Kh_PB_OW);
                            }
                            //else
                            //{
                            //    Kohle_PB_OW_Value = 0;
                            //}
                            if (BP_MW_Div > 0)
                            {
                                Kohle_PB_MW_Value = (Kohle + Kohle_Pr) / (Kh_PB_MW);
                            }
                            //else
                            //{
                            //    Kohle_PB_MW_Value = 0;
                            //}
                            if (BL_OW_Div > 0)
                            {
                                Kohle_LB_OW_Value = (Kohle + Kohle_Pr) / (Kh_LB_OW);
                            }
                            //else
                            //{
                            //    Kohle_LB_OW_Value = 0;
                            //}
                            if (BL_MW_Div > 0)
                            {
                                Kohle_LB_MW_Value = (Kohle + Kohle_Pr) / (Kh_LB_MW);
                            }
                            //else
                            //{
                            //    Kohle_LB_MW_Value = 0;
                            //}
                            if (BS_OW_Div > 0)
                            {
                                Kohle_SB_OW_Value = (Kohle + Kohle_Pr) / (Kh_SB_OW);
                            }
                            //else
                            //{
                            //    Kohle_SB_OW_Value = 0;
                            //}
                            if (BS_MW_Div > 0)
                            {
                                Kohle_SB_MW_Value = (Kohle + Kohle_Pr) / (Kh_SB_MW);
                            }
                            //else
                            //{
                            //    Kohle_SB_MW_Value = 0;
                            //}
                        }
                        else
                        {
                            Kohlenzentriefuge_Pr = Convert.ToInt64(Math.Ceiling((Kohle + Kohle_Pr) / 2));
                            Kohle_MB_OW_Value = 0;
                            Kohle_MB_MW_Value = 0;
                            Kohle_PB_OW_Value = 0;
                            Kohle_PB_MW_Value = 0;
                            Kohle_LB_OW_Value = 0;
                            Kohle_LB_MW_Value = 0;
                            Kohle_SB_OW_Value = 0;
                            Kohle_SB_MW_Value = 0;
                        }
                    }
                    //Titan
                    if (((Titan + Titan_Pr) > Titan_Er + 0.01) ||
                        ((Titan + Titan_Pr) > (Titan_Er + 20 + (GroßerTrenner + GroßerTrenner_Pr) * 0.25 + (Trenner + Trenner_Pr) * 0.8333)))
                    {
                        changed = true;
                        if (Titan_aweleble.Checked)
                        {
                            beta = (Titan + Titan_Pr) - ((GroßerTrenner + GroßerTrenner_Pr) * 0.25 + (Trenner + Trenner_Pr) * 0.8333);
                            if (beta <= 0)
                            {
                                beta = 0;
                            }
                            if (BP_OW_Div > 0)
                            {
                                Titan_PB_OW_Value = beta / (Ti_PB_OW);
                            }
                            //else
                            //{
                            //    Titan_PB_OW_Value = 0;
                            //}
                            if (BP_MW_Div > 0)
                            {
                                Titan_PB_MW_Value = beta / (Ti_PB_MW);
                            }
                            //else
                            //{
                            //    Titan_PB_MW_Value = 0;
                            //}
                            if (BL_OW_Div > 0)
                            {
                                Titan_LB_OW_Value = beta / (Ti_LB_OW);
                            }
                            //else
                            //{
                            //    Titan_LB_OW_Value = 0;
                            //}
                            if (BL_MW_Div > 0)
                            {
                                Titan_LB_MW_Value = beta / (Ti_LB_MW);
                            }
                            //else
                            //{
                            //    Titan_LB_MW_Value = 0;
                            //}
                            if (BS_OW_Div > 0)
                            {
                                Titan_SB_OW_Value = beta / (Ti_SB_OW);
                            }
                            //else
                            //{
                            //    Titan_SB_OW_Value = 0;
                            //}
                            if (BS_MW_Div > 0)
                            {
                                Titan_SB_MW_Value = beta / (Ti_SB_MW);
                            }
                            //else
                            //{
                            //    Titan_SB_MW_Value = 0;
                            //}
                        }
                        else
                        {
                            alva = Convert.ToInt64(Math.Ceiling((Titan + Titan_Pr + GroßerTrenner_Pr * 0.8333) / 0.25));
                            if (Trenner_Pr < alva || alva == 0)
                            {
                                Trenner_Pr = alva;
                            }
                            alva = Convert.ToInt64(Math.Ceiling((Titan + Titan_Pr - Trenner_Pr * 0.25) / 0.8333));
                            if (GroßerTrenner_Pr < alva || alva == 0)
                            {
                                GroßerTrenner_Pr = alva;
                            }
                            Titan_PB_OW_Value = 0;
                            Titan_PB_MW_Value = 0;
                            Titan_LB_OW_Value = 0;
                            Titan_LB_MW_Value = 0;
                            Titan_SB_OW_Value = 0;
                            Titan_SB_MW_Value = 0;
                        }
                    }
                    //Thorium
                    if (((Thorium + Thorium_Pr) > Thorium_Er + 0.01) || ((Thorium + Thorium_Pr) > (Thorium_Er + 20 + (GroßerTrenner + GroßerTrenner_Pr) * 0.8166)))
                    {
                        changed = true;
                        if (Strom_only)
                        {
                            //Thorium = 0;
                            Thorium_Pr = 0;
                        }
                        if (Thorium_aweleble.Checked)
                        {
                            beta = (Thorium + Thorium_Pr) - (GroßerTrenner + GroßerTrenner_Pr) * 0.8166;
                            if (beta <= 0)
                            {
                                beta = 0;
                            }
                            if (BL_OW_Div > 0)
                            {
                                Thorium_LB_OW_Value = beta / (Th_LB_OW);
                            }
                            //else
                            //{
                            //    Thorium_LB_OW_Value = 0;
                            //}
                            if (BL_MW_Div > 0)
                            {
                                Thorium_LB_MW_Value = beta / (Th_LB_MW);
                            }
                            //else
                            //{
                            //    Thorium_LB_MW_Value = 0;
                            //}
                            if (BS_OW_Div > 0)
                            {
                                Thorium_SB_OW_Value = beta / (Th_SB_OW);
                            }
                            //else
                            //{
                            //    Thorium_SB_OW_Value = 0;
                            //}
                            if (BS_MW_Div > 0)
                            {
                                Thorium_SB_MW_Value = beta / (Th_SB_MW);
                            }
                            //else
                            //{
                            //    Thorium_SB_MW_Value = 0;
                            //}
                        }
                        else
                        {
                            alva = Convert.ToInt64(Math.Ceiling((Thorium + Thorium_Pr) / 0.8166));
                            if (GroßerTrenner_Pr < alva || alva == 0)
                            {
                                GroßerTrenner_Pr = alva;
                            }
                            Thorium_LB_OW_Value = 0;
                            Thorium_LB_MW_Value = 0;
                            Thorium_SB_OW_Value = 0;
                            Thorium_SB_MW_Value = 0;
                        }


                    }
                    //Produkte
                    //SporenPod
                    if (((SporenPod + SporenPod_Pr) > SporenPod_Er + 0.01) || ((SporenPod + SporenPod_Pr) > (SporenPod_Er + 1)))
                    {
                        changed = true;
                        if (Strom_only)
                        {
                            //SporenPod = 0;
                            SporenPod_Pr = 0;
                        }
                        Kultivierer_Pr = Convert.ToInt64(Math.Ceiling((SporenPod + SporenPod_Pr) / 0.6));
                    }
                    //Metaglas
                    if (((Metaglas + Metaglas_Pr) > Metaglas_Er + 0.01) || ((Metaglas + Metaglas_Pr) > (Metaglas_Er + 3)))
                    {
                        changed = true;
                        Brennofen_Pr = Convert.ToInt64(Math.Ceiling((Metaglas + Metaglas_Pr) / 2));
                    }
                    //Grafit
                    if (((Grafit + Grafit_Pr) > Grafit_Er + 0.01) ||
                        ((Grafit + Grafit_Pr) > (Grafit_Er + 5 + (GroßerTrenner + GroßerTrenner_Pr) * 0.7667 + (Trenner + Trenner_Pr) * 0.1833)))
                    {
                        changed = true;
                        if (GrafitPresse_Zu.ReadOnly == false || MultiPresse_Zu.ReadOnly == false)
                        {
                            beta = (Grafit + Grafit_Pr) - ((GroßerTrenner + GroßerTrenner_Pr) * 0.7667 + (Trenner + Trenner_Pr) * 0.1833);
                            if (beta <= 0)
                            {
                                beta = 0;
                            }
                            GrafitPresse_Pr = Convert.ToInt64(Math.Ceiling((beta / 0.6667) * (Convert.ToDouble(GrafitPresse_Div.Value) / 100)));
                            MultiPresse_Pr = Convert.ToInt64(Math.Ceiling((beta / 4) * (Convert.ToDouble(MultiPresse_Div.Value) / 100)));
                        }
                        else
                        {
                            alva = Convert.ToInt64(Math.Ceiling((Grafit + Grafit_Pr) / 0.1833));
                            if (Trenner_Pr < alva || alva == 0)
                            {
                                Trenner_Pr = alva;
                            }
                            alva = Convert.ToInt64(Math.Ceiling((Grafit + Grafit_Pr - Trenner_Pr * 0.1833) / 0.7667));
                            if (GroßerTrenner_Pr < alva || alva == 0)
                            {
                                GroßerTrenner_Pr = alva;
                            }
                            GrafitPresse_Pr = 0;
                            MultiPresse_Pr = 0;
                        }

                    }
                    //Silizium
                    if (((Silizium + Silizium_Pr) > Silizium_Er + 0.01) || ((Silizium + Silizium_Pr) > (Silizium_Er + 6)))
                    {
                        changed = true;
                        SiliziumSchmelzer_Pr = Convert.ToInt64(Math.Ceiling(((Silizium + Silizium_Pr) / 1.5) * (Convert.ToDouble(SiliziumSchmelzer_Div.Value) / 100)));
                        SiliziumSchmelztiegel_Pr = Convert.ToInt64(Math.Ceiling(((Silizium + Silizium_Pr) / 5.3333) * (Convert.ToDouble(SiliziumSchmelztiegel_Div.Value) / 100)));
                    }
                    //Pyratit
                    if (((Pyratit + Pyratit_Pr) > Pyratit_Er + 0.01) || ((Pyratit + Pyratit_Pr) > (Pyratit_Er + 1)))
                    {
                        changed = true;
                        if (Strom_only)
                        {
                            //Pyratit = 0;
                            Pyratit_Pr = 0;
                        }
                        PyratitMixer_Pr = Convert.ToInt64(Math.Ceiling((Pyratit + Pyratit_Pr) / 0.75));
                    }
                    //ExplosiveMischung
                    if (((ExplosiveMischung + ExplosiveMischung_Pr) > ExplosiveMischung_Er + 0.01) || ((ExplosiveMischung + ExplosiveMischung_Pr) > (ExplosiveMischung_Er + 1)))
                    {
                        changed = true;
                        if (Strom_only)
                        {
                            //ExplosiveMischung = 0;
                            ExplosiveMischung_Pr = 0;
                        }
                        Sprengmixer_Pr = Convert.ToInt64(Math.Ceiling((ExplosiveMischung + ExplosiveMischung_Pr) / 0.75));
                    }
                    //Plastanium
                    if (((Plastanium + Plastanium_Pr) > Plastanium_Er + 0.01) || ((Plastanium + Plastanium_Pr) > (Plastanium_Er + 2)))
                    {
                        changed = true;
                        PlastaniumVerdichter_Pr = Convert.ToInt64(Math.Ceiling(Plastanium + Plastanium_Pr));
                    }
                    //Phasengewebe
                    if (((Phasengewebe + Phasengewebe_Pr) > Phasengewebe_Er + 0.01) || ((Phasengewebe + Phasengewebe_Pr) > (Phasengewebe_Er + 1)))
                    {
                        changed = true;
                        if (Strom_only)
                        {
                            //Phasengewebe = 0;
                            Phasengewebe_Pr = 0;
                        }
                        Phasenweber_Pr = Convert.ToInt64(Math.Ceiling((Phasengewebe + Phasengewebe_Pr) / 0.5));
                    }
                    //Spannungslegierung
                    if (((Spannungslegierung + Spannungslegierung_Pr) > Spannungslegierung_Er + 0.01) || ((Spannungslegierung + Spannungslegierung_Pr) > (Spannungslegierung_Er + 1)))
                    {
                        changed = true;
                        Legierungsschmelze_Pr = Convert.ToInt64(Math.Ceiling((Spannungslegierung + Spannungslegierung_Pr) / 0.8));
                    }
                    //Generatoren
                    //Strom
                    if (!Stromberechnung_off)
                    {
                        if (((Strom + Strom_Pr) > Strom_Er) || ((Strom + Strom_Pr) > (Strom_Er + M_Strom)))
                        {
                            changed = true;
                            Verbrennungsgenerator_Pr = Convert.ToInt64(Math.Ceiling((Convert.ToDouble(Strom + Strom_Pr) / 60) * VerG_Div));
                            ThermischerGenerator_Pr = Convert.ToInt64(Math.Ceiling((Convert.ToDouble(Strom + Strom_Pr) / 108) * TerG_Div));
                            Turbinengenerator_Pr = Convert.ToInt64(Math.Ceiling((Convert.ToDouble(Strom + Strom_Pr) / 330) * TurG_Div));
                            Differenzialgenerator_Pr = Convert.ToInt64(Math.Ceiling((Convert.ToDouble(Strom + Strom_Pr) / 1080) * DifG_Div));
                            RTGGenerator_Pr = Convert.ToInt64(Math.Ceiling((Convert.ToDouble(Strom + Strom_Pr) / 270) * RTGG_Div));
                            Solarpanel_Pr = Convert.ToInt64(Math.Ceiling((Convert.ToDouble(Strom + Strom_Pr) / 6) * SolG_Div));
                            GroßesSolarpanel_Pr = Convert.ToInt64(Math.Ceiling((Convert.ToDouble(Strom + Strom_Pr) / 78) * GSG_Div));
                            ThoriumReaktor_Pr = Convert.ToInt64(Math.Ceiling((Convert.ToDouble(Strom + Strom_Pr) / 900) * TorG_Div));
                            Schlaggenerator_Pr = Convert.ToInt64(Math.Ceiling((Convert.ToDouble(Strom + Strom_Pr) / 6300) * SchG_Div));
                        }
                    }
                    //Flüssigkeiten
                    //Wasser
                    if (((Wasser + Wasser_Pr) > Wasser_Er + 0.01) || ((Wasser + Wasser_Pr) > (Wasser_Er + 200)))
                    {
                        changed = true;
                        if (Strom_only)
                        {
                            //Wasser = 0;
                            Wasser_Pr = 0;
                        }
                        if (Wasser_aweleble.Checked)
                        {
                            Wasser_MP_Value = Math.Ceiling((Wasser + Wasser_Pr) / C_MP_Div * MP_Div);
                            Wasser_RP_Value = Math.Ceiling((Wasser + Wasser_Pr) / C_RP_Div * RP_Div);
                            Wasser_TP_Value = Math.Ceiling((Wasser + Wasser_Pr) / C_TP_Div * TP_Div);
                            WasserExtractor_Pr = Convert.ToInt64(Math.Ceiling((Convert.ToDouble(Wasser + Wasser_Pr) * (1 - MP_Div - RP_Div - TP_Div)) / 6.6));
                        }
                        else
                        {
                            WasserExtractor_Pr = Convert.ToInt64(Math.Ceiling(Convert.ToDouble(Wasser + Wasser_Pr) / 6.6));
                        }
                    }
                    //Öl
                    if (((Öl + Öl_Pr) > Öl_Er + 0.01) || ((Öl + Öl_Pr) > (Öl_Er + 200)))
                    {
                        changed = true;
                        if (Öl_aweleble.Checked)
                        {
                            Öl_MP_Value = Math.Ceiling((Öl + Öl_Pr) / C_MP_Div * MP_Div);
                            Öl_RP_Value = Math.Ceiling((Öl + Öl_Pr) / C_RP_Div * RP_Div);
                            Öl_TP_Value = Math.Ceiling((Öl + Öl_Pr) / C_TP_Div * TP_Div);
                        }
                        else
                        {
                            ÖlExtractor_Pr = Convert.ToInt64(Math.Ceiling(((Öl + Öl_Pr) * (Convert.ToDouble(ÖlExtractor_Div.Value) / 100)) / 15));
                            Sporenpresse_Pr = Convert.ToInt64(Math.Ceiling(((Öl + Öl_Pr) * (Convert.ToDouble(Sporenpresse_Div.Value) / 100)) / 18));
                        }
                    }
                    //Kryoflüssigkeitsmixer
                    if (((Kryoflüssigkeit + Kryoflüssigkeit_Pr) > Kryoflüssigkeit_Er + 0.01) || ((Kryoflüssigkeit + Kryoflüssigkeit_Pr) > (Kryoflüssigkeit_Er + 200)))
                    {
                        changed = true;
                        if (Strom_only)
                        {
                            //Kryoflüssigkeit = 0;
                            Kryoflüssigkeit_Pr = 0;
                        }
                        if (Kryoflüssigkeit_aweleble.Checked)
                        {
                            Kryoflüssigkeit_MP_Value = Math.Ceiling((Kryoflüssigkeit + Kryoflüssigkeit_Pr) / (C_MP_Div / 2) * MP_Div);
                            Kryoflüssigkeit_RP_Value = Math.Ceiling((Kryoflüssigkeit + Kryoflüssigkeit_Pr) / (C_RP_Div / 2) * RP_Div);
                            Kryoflüssigkeit_TP_Value = Math.Ceiling((Kryoflüssigkeit + Kryoflüssigkeit_Pr) / (C_TP_Div / 2) * TP_Div);
                            Kryoflüssigkeitsmixer_Pr = Convert.ToInt64(Math.Ceiling((Convert.ToDouble(Kryoflüssigkeit + Kryoflüssigkeit_Pr) * (1 - MP_Div - RP_Div - TP_Div)) / 12));
                        }
                        else
                        {
                            Kryoflüssigkeitsmixer_Pr = Convert.ToInt64(Math.Ceiling((Kryoflüssigkeit + Kryoflüssigkeit_Pr) / 12));
                        }
                    }
                    //Schmelzer
                    if (((Schlacke + Schlacke_Pr) > Schlacke_Er + 0.01) || ((Schlacke + Schlacke_Pr) > (Schlacke_Er + 200)))
                    {
                        changed = true;
                        if (Schlacke_aweleble.Checked)
                        {
                            Schlacke_MP_Value = Math.Ceiling((Schlacke + Schlacke_Pr) / C_MP_Div * MP_Div);
                            Schlacke_RP_Value = Math.Ceiling((Schlacke + Schlacke_Pr) / C_RP_Div * RP_Div);
                            Schlacke_TP_Value = Math.Ceiling((Schlacke + Schlacke_Pr) / C_TP_Div * TP_Div);
                            Schmelzer_Pr = Convert.ToInt64(Math.Ceiling((Convert.ToDouble(Schlacke + Schlacke_Pr) * (1 - MP_Div - RP_Div - TP_Div)) / 12));
                        }
                        else
                        {
                            Schmelzer_Pr = Convert.ToInt64(Math.Ceiling((Schlacke + Schlacke_Pr) / 12));
                        }
                    }



                    //infiniti dedected helper
                    //Help_class infin_Schrott, infin_Kupfer, infin_Blei, infin_Sand, infin_Kohle, infin_Titan, infin_Thorium,
                    //           infin_Schlacke, infin_Wasser, infin_Kryoflüssigkeit, infin_Öl,
                    //           infin_SporenPod, infin_Metaglas, infin_Grafit, infin_Silizium, infin_Pyratit, infin_ExplosiveMischung,
                    //           infin_Plastanium, infin_Phasengewebe, infin_Spannungslegierung;

                    if (Kupfer_Er > Kupfer_Pr)
                    {
                        if (infin_Kupfer > Kupfer_Er - Kupfer_Pr)
                        {
                            infiniti_loop++;
                        }
                        else if (Kupfer_Pr > long.MaxValue)
                        {
                            infiniti_loop = 100000;
                        }
                        else if (Kupfer_Pr == infin_Kupfer)
                        {
                            infiniti_loop_2++;
                        }
                        else
                        {
                            infiniti_loop_2 = 0;
                        }
                        infin_Kupfer = Convert.ToInt64(Kupfer_Er - Kupfer_Pr);
                    }
                    else if (Schrott_Er > Schrott_Pr)
                    {
                        if (infin_Schrott > Schrott_Er - Schrott_Pr)
                        {
                            infiniti_loop++;
                        }
                        else if (Schrott_Pr > long.MaxValue)
                        {
                            infiniti_loop = 100000;
                        }
                        else if (Schrott_Pr == infin_Schrott)
                        {
                            infiniti_loop_2++;
                        }
                        else
                        {
                            infiniti_loop_2 = 0;
                        }
                        infin_Schrott = Convert.ToInt64(Schrott_Er - Schrott_Pr);
                    }
                    else if (Blei_Er > Blei_Pr)
                    {
                        if (infin_Blei > Blei_Er - Blei_Pr)
                        {
                            infiniti_loop++;
                        }
                        else if (Blei_Pr > long.MaxValue)
                        {
                            infiniti_loop = 100000;
                        }
                        else if (Blei_Pr == infin_Blei)
                        {
                            infiniti_loop_2++;
                        }
                        else
                        {
                            infiniti_loop_2 = 0;
                        }
                        infin_Blei = Convert.ToInt64(Blei_Er - Blei_Pr);
                    }
                    else if (Sand_Er > Sand_Pr)
                    {
                        if (infin_Sand > Sand_Er - Sand_Pr)
                        {
                            infiniti_loop++;
                        }
                        else if (Sand_Pr > long.MaxValue)
                        {
                            infiniti_loop = 100000;
                        }
                        else if (Sand_Pr == infin_Sand)
                        {
                            infiniti_loop_2++;
                        }
                        else
                        {
                            infiniti_loop_2 = 0;
                        }
                        infin_Sand = Convert.ToInt64(Sand_Er - Sand_Pr);
                    }
                    else if (Kohle_Er > Kohle_Pr)
                    {
                        if (infin_Kohle > Kohle_Er - Kohle_Pr)
                        {
                            infiniti_loop++;
                        }
                        else if (Kohle_Pr > long.MaxValue)
                        {
                            infiniti_loop = 100000;
                        }
                        else if (Kohle_Pr == infin_Kohle)
                        {
                            infiniti_loop_2++;
                        }
                        else
                        {
                            infiniti_loop_2 = 0;
                        }
                        infin_Kohle = Convert.ToInt64(Kohle_Er - Kohle_Pr);
                    }
                    else if (Titan_Er > Titan_Pr)
                    {
                        if (infin_Titan > Titan_Er - Titan_Pr)
                        {
                            infiniti_loop++;
                        }
                        else if (Titan_Pr > long.MaxValue)
                        {
                            infiniti_loop = 100000;
                        }
                        else if (Titan_Pr == infin_Titan)
                        {
                            infiniti_loop_2++;
                        }
                        else
                        {
                            infiniti_loop_2 = 0;
                        }
                        infin_Titan = Convert.ToInt64(Titan_Er - Titan_Pr);
                    }
                    else if (Thorium_Er > Thorium_Pr)
                    {
                        if (infin_Thorium > Thorium_Er - Thorium_Pr)
                        {
                            infiniti_loop++;
                        }
                        else if (Thorium_Pr > long.MaxValue)
                        {
                            infiniti_loop = 100000;
                        }
                        else if (Thorium_Pr == infin_Thorium)
                        {
                            infiniti_loop_2++;
                        }
                        else
                        {
                            infiniti_loop_2 = 0;
                        }
                        infin_Thorium = Convert.ToInt64(Thorium_Er - Thorium_Pr);
                    }
                    else if (Schlacke_Er > Schlacke_Pr)
                    {
                        if (infin_Schlacke > Schlacke_Er - Schlacke_Pr)
                        {
                            infiniti_loop++;
                        }
                        else if (Schlacke_Pr > long.MaxValue)
                        {
                            infiniti_loop = 100000;
                        }
                        else if (Schlacke_Pr == infin_Schlacke)
                        {
                            infiniti_loop_2++;
                        }
                        else
                        {
                            infiniti_loop_2 = 0;
                        }
                        infin_Schlacke = Convert.ToInt64(Schlacke_Er - Schlacke_Pr);
                    }
                    else if (Wasser_Er > Wasser_Pr)
                    {
                        if (infin_Wasser > Wasser_Er - Wasser_Pr)
                        {
                            infiniti_loop++;
                        }
                        else if (Wasser_Pr > long.MaxValue)
                        {
                            infiniti_loop = 100000;
                        }
                        else if (Wasser_Pr == infin_Wasser)
                        {
                            infiniti_loop_2++;
                        }
                        else
                        {
                            infiniti_loop_2 = 0;
                        }
                        infin_Wasser = Convert.ToInt64(Wasser_Er - Wasser_Pr);
                    }
                    else if (Kryoflüssigkeit_Er > Kryoflüssigkeit_Pr)
                    {
                        if (infin_Kryoflüssigkeit > Kryoflüssigkeit_Er - Kryoflüssigkeit_Pr)
                        {
                            infiniti_loop++;
                        }
                        else if (Kryoflüssigkeit_Pr > long.MaxValue)
                        {
                            infiniti_loop = 100000;
                        }
                        else if (Kryoflüssigkeit_Pr == infin_Kryoflüssigkeit)
                        {
                            infiniti_loop_2++;
                        }
                        else
                        {
                            infiniti_loop_2 = 0;
                        }
                        infin_Kryoflüssigkeit = Convert.ToInt64(Kryoflüssigkeit_Er - Kryoflüssigkeit_Pr);
                    }
                    else if (Öl_Er > Öl_Pr)
                    {
                        if (infin_Öl > Öl_Er - Öl_Pr)
                        {
                            infiniti_loop++;
                        }
                        else if (Öl_Pr > long.MaxValue)
                        {
                            infiniti_loop = 100000;
                        }
                        else if (Öl_Pr == infin_Öl)
                        {
                            infiniti_loop_2++;
                        }
                        else
                        {
                            infiniti_loop_2 = 0;
                        }
                        infin_Öl = Convert.ToInt64(Öl_Er - Öl_Pr);
                    }
                    else if (SporenPod_Er > SporenPod_Pr)
                    {
                        if (infin_SporenPod > SporenPod_Er - SporenPod_Pr)
                        {
                            infiniti_loop++;
                        }
                        else if (SporenPod_Pr > long.MaxValue)
                        {
                            infiniti_loop = 100000;
                        }
                        else if (SporenPod_Pr == infin_SporenPod)
                        {
                            infiniti_loop_2++;
                        }
                        else
                        {
                            infiniti_loop_2 = 0;
                        }
                        infin_SporenPod = Convert.ToInt64(SporenPod_Er - SporenPod_Pr);
                    }
                    else if (Metaglas_Er > Metaglas_Pr)
                    {
                        if (infin_Metaglas > Metaglas_Er - Metaglas_Pr)
                        {
                            infiniti_loop++;
                        }
                        else if (Metaglas_Pr > long.MaxValue)
                        {
                            infiniti_loop = 100000;
                        }
                        else if (Metaglas_Pr == infin_Metaglas)
                        {
                            infiniti_loop_2++;
                        }
                        else
                        {
                            infiniti_loop_2 = 0;
                        }
                        infin_Metaglas = Convert.ToInt64(Metaglas_Er - Metaglas_Pr);
                    }
                    else if (Grafit_Er > Grafit_Pr)
                    {
                        if (infin_Grafit > Grafit_Er - Grafit_Pr)
                        {
                            infiniti_loop++;
                        }
                        else if (Grafit_Pr > long.MaxValue)
                        {
                            infiniti_loop = 100000;
                        }
                        else if (Grafit_Pr == infin_Grafit)
                        {
                            infiniti_loop_2++;
                        }
                        else
                        {
                            infiniti_loop_2 = 0;
                        }
                        infin_Grafit = Convert.ToInt64(Grafit_Er - Grafit_Pr);
                    }
                    else if (Silizium_Er > Silizium_Pr)
                    {
                        if (infin_Silizium > Silizium_Er - Silizium_Pr)
                        {
                            infiniti_loop++;
                        }
                        else if (Silizium_Pr > long.MaxValue)
                        {
                            infiniti_loop = 100000;
                        }
                        else if (Silizium_Pr == infin_Silizium)
                        {
                            infiniti_loop_2++;
                        }
                        else
                        {
                            infiniti_loop_2 = 0;
                        }
                        infin_Silizium = Convert.ToInt64(Silizium_Er - Silizium_Pr);
                    }
                    else if (Pyratit_Er > Pyratit_Pr)
                    {
                        if (infin_Pyratit > Pyratit_Er - Pyratit_Pr)
                        {
                            infiniti_loop++;
                        }
                        else if (Pyratit_Pr > long.MaxValue)
                        {
                            infiniti_loop = 100000;
                        }
                        else if (Pyratit_Pr == infin_Pyratit)
                        {
                            infiniti_loop_2++;
                        }
                        else
                        {
                            infiniti_loop_2 = 0;
                        }
                        infin_Pyratit = Convert.ToInt64(Pyratit_Er - Pyratit_Pr);
                    }
                    else if (ExplosiveMischung_Er > ExplosiveMischung_Pr)
                    {
                        if (infin_ExplosiveMischung > ExplosiveMischung_Er - ExplosiveMischung_Pr)
                        {
                            infiniti_loop++;
                        }
                        else if (ExplosiveMischung_Pr > long.MaxValue)
                        {
                            infiniti_loop = 100000;
                        }
                        else if (ExplosiveMischung_Pr == infin_ExplosiveMischung)
                        {
                            infiniti_loop_2++;
                        }
                        else
                        {
                            infiniti_loop_2 = 0;
                        }
                        infin_ExplosiveMischung = Convert.ToInt64(ExplosiveMischung_Er - ExplosiveMischung_Pr);
                    }
                    else if (Plastanium_Er > Plastanium_Pr)
                    {
                        if (infin_Plastanium > Plastanium_Er - Plastanium_Pr)
                        {
                            infiniti_loop++;
                        }
                        else if (Plastanium_Pr > long.MaxValue)
                        {
                            infiniti_loop = 100000;
                        }
                        else if (Plastanium_Pr == infin_Plastanium)
                        {
                            infiniti_loop_2++;
                        }
                        else
                        {
                            infiniti_loop_2 = 0;
                        }
                        infin_Plastanium = Convert.ToInt64(Plastanium_Er - Plastanium_Pr);
                    }
                    else if (Phasengewebe_Er > Phasengewebe_Pr)
                    {
                        if (infin_Phasengewebe > Phasengewebe_Er - Phasengewebe_Pr)
                        {
                            infiniti_loop++;
                        }
                        else if (Phasengewebe_Pr > long.MaxValue)
                        {
                            infiniti_loop = 100000;
                        }
                        else if (Phasengewebe_Pr == infin_Phasengewebe)
                        {
                            infiniti_loop_2++;
                        }
                        else
                        {
                            infiniti_loop_2 = 0;
                        }
                        infin_Phasengewebe = Convert.ToInt64(Phasengewebe_Er - Phasengewebe_Pr);
                    }
                    else if (Spannungslegierung_Er > Spannungslegierung_Pr)
                    {
                        if (infin_Spannungslegierung > Spannungslegierung_Er - Spannungslegierung_Pr)
                        {
                            infiniti_loop++;
                        }
                        else if (Spannungslegierung_Pr > long.MaxValue)
                        {
                            infiniti_loop = 100000;
                        }
                        else if (Spannungslegierung_Pr == infin_Spannungslegierung)
                        {
                            infiniti_loop_2++;
                        }
                        else
                        {
                            infiniti_loop_2 = 0;
                        }
                        infin_Spannungslegierung = Convert.ToInt64(Spannungslegierung_Er - Spannungslegierung_Pr);
                    }
                    //else if (Strom_Er > Strom_Pr)
                    //{
                    //    if (infin_Strom > Strom_Er - Strom_Pr)
                    //    {
                    //        infiniti_loop++;
                    //    }
                    //    else if (Strom_Pr > long.MaxValue)
                    //    {
                    //        infiniti_loop = 100000;
                    //    }
                    //    infin_Strom = Convert.ToInt64(Strom_Er - Strom_Pr);
                    //}
                    if (infiniti_loop_2 == 100)
                    {
                        infiniti_loop = 1000;
                    }

                    infiniti_loop_3++;

                    //Error Massege
                    if (infiniti_loop > 30 || infiniti_loop_3 > 10000)
                    {
                        //Massege
                        // Initializes the variables to pass to the MessageBox.Show method.
                        string message = "You have created infinite stacking.\nAll values will be reset!";
                        if (infiniti_loop_3 > 10000)
                        {
                            message += "\ninfinite count: " + Convert.ToString(infiniti_loop_3);
                        }
                        string caption = "Error Detected in Input";
                        MessageBoxButtons buttons = MessageBoxButtons.OK;
                        //DialogResult result;
                        {
                            //Reset Values
                            //Rohstoffe
                            Kupfer_Er = 0; Kupfer_Pr = 0;
                            Schrott_Er = 0; Schrott_Pr = 0;
                            Blei_Er = 0; Blei_Pr = 0;
                            Sand_Er = 0; Sand_Pr = 0;
                            Kohle_Er = 0; Kohle_Pr = 0;
                            Titan_Er = 0; Titan_Pr = 0;
                            Thorium_Er = 0; Thorium_Pr = 0;
                            //Produkte
                            SporenPod_Er = 0; SporenPod_Pr = 0;
                            Metaglas_Er = 0; Metaglas_Pr = 0;
                            Grafit_Er = 0; Grafit_Pr = 0;
                            Silizium_Er = 0; Silizium_Pr = 0;
                            Pyratit_Er = 0; Pyratit_Pr = 0;
                            ExplosiveMischung_Er = 0; ExplosiveMischung_Pr = 0;
                            Plastanium_Er = 0; Plastanium_Pr = 0;
                            Phasengewebe_Er = 0; Phasengewebe_Pr = 0;
                            Spannungslegierung_Er = 0; Spannungslegierung_Pr = 0;
                            Strom_Er = 0; Strom_Pr = 0;
                            //Flüssigkeiten
                            Schlacke_Er = 0; Schlacke_Pr = 0;
                            Wasser_Er = 0; Wasser_Pr = 0;
                            Kryoflüssigkeit_Er = 0; Kryoflüssigkeit_Pr = 0;
                            Öl_Er = 0; Öl_Pr = 0;
                            //Truppen Resurses
                            Bodenfabrik_Zw = 0;
                            Wasserfabrik_Zw = 0;
                            Luftfabrik_Zw = 0;
                            HinzufügenderRekonstrukeur_Zw = 0;
                            MultiplikativerRekonstrukeur_Zw = 0;
                            ExponenziellerRekonstrukeur_Zw = 0;
                            TretrativerRekonstrukeur_Zw = 0;
                            //secundär Rohstoffe
                            WasserExtractor_Pr = 0;
                            Kultivierer_Pr = 0;
                            ÖlExtractor_Pr = 0;
                            Sporenpresse_Pr = 0;
                            Pulverisierer_Pr = 0;
                            Kohlenzentriefuge_Pr = 0;
                            Kryoflüssigkeitsmixer_Pr = 0;
                            Schmelzer_Pr = 0;
                            Trenner_Pr = 0;
                            GroßerTrenner_Pr = 0;

                            //Bohrer
                            Kupfer_MB_OW_Value = 0; Kupfer_MB_MW_Value = 0;
                            Blei_MB_OW_Value = 0; Blei_MB_MW_Value = 0;
                            Sand_MB_OW_Value = 0; Sand_MB_MW_Value = 0;
                            Kohle_MB_OW_Value = 0; Kohle_MB_MW_Value = 0;
                            Schrott_MB_OW_Value = 0; Schrott_MB_MW_Value = 0;
                            Kupfer_PB_OW_Value = 0; Kupfer_PB_MW_Value = 0;
                            Blei_PB_OW_Value = 0; Blei_PB_MW_Value = 0;
                            Sand_PB_OW_Value = 0; Sand_PB_MW_Value = 0;
                            Kohle_PB_OW_Value = 0; Kohle_PB_MW_Value = 0;
                            Titan_PB_OW_Value = 0; Titan_PB_MW_Value = 0;
                            Schrott_PB_OW_Value = 0; Schrott_PB_MW_Value = 0;
                            Kupfer_LB_OW_Value = 0; Kupfer_LB_MW_Value = 0;
                            Blei_LB_OW_Value = 0; Blei_LB_MW_Value = 0;
                            Sand_LB_OW_Value = 0; Sand_LB_MW_Value = 0;
                            Kohle_LB_OW_Value = 0; Kohle_LB_MW_Value = 0;
                            Titan_LB_OW_Value = 0; Titan_LB_MW_Value = 0;
                            Thorium_LB_OW_Value = 0; Thorium_LB_MW_Value = 0;
                            Schrott_LB_OW_Value = 0; Schrott_LB_MW_Value = 0;
                            Kupfer_SB_OW_Value = 0; Kupfer_SB_MW_Value = 0;
                            Blei_SB_OW_Value = 0; Blei_SB_MW_Value = 0;
                            Sand_SB_OW_Value = 0; Sand_SB_MW_Value = 0;
                            Kohle_SB_OW_Value = 0; Kohle_SB_MW_Value = 0;
                            Titan_SB_OW_Value = 0; Titan_SB_MW_Value = 0;
                            Thorium_SB_OW_Value = 0; Thorium_SB_MW_Value = 0;
                            Schrott_SB_OW_Value = 0; Schrott_SB_MW_Value = 0;

                            //Pumpe
                            Wasser_MP_Value = 0;
                            Kryoflüssigkeit_MP_Value = 0;
                            Öl_MP_Value = 0;
                            Schlacke_MP_Value = 0;
                            Wasser_RP_Value = 0;
                            Kryoflüssigkeit_RP_Value = 0;
                            Öl_RP_Value = 0;
                            Schlacke_RP_Value = 0;
                            Wasser_TP_Value = 0;
                            Kryoflüssigkeit_TP_Value = 0;
                            Öl_TP_Value = 0;
                            Schlacke_TP_Value = 0;

                            Reset_All();
                        }
                        // Displays the MessageBox.
                        MessageBox.Show(message, caption, buttons);
                        break;
                    }
                }
                while (changed);

                //Ausgabe der Parameter
                {
                    //final Truppen Resurses
                    Bodenfabrik_Be.Text = Convert.ToString(Bodenfabrik_Zw);
                    Wasserfabrik_Be.Text = Convert.ToString(Wasserfabrik_Zw);
                    Luftfabrik_Be.Text = Convert.ToString(Luftfabrik_Zw);
                    HinzufügenderRekonstrukeur_Be.Text = Convert.ToString(Math.Ceiling(HinzufügenderRekonstrukeur_Zw));
                    MultiplikativerRekonstrukeur_Be.Text = Convert.ToString(Math.Ceiling(MultiplikativerRekonstrukeur_Zw));
                    ExponenziellerRekonstrukeur_Be.Text = Convert.ToString(Math.Ceiling(ExponenziellerRekonstrukeur_Zw));
                    TretrativerRekonstrukeur_Be.Text = Convert.ToString(Math.Ceiling(TretrativerRekonstrukeur_Zw));

                    //final Rohstoff Resurses
                    //Reale Kernzufur
                    Kupfer_Real.Text = Double_To_String_Max_4_Dig(Kupfer_Er - Kupfer_Pr);
                    Blei_Real.Text = Double_To_String_Max_4_Dig(Blei_Er - Blei_Pr);
                    Sand_Real.Text = Double_To_String_Max_4_Dig(Sand_Er - Sand_Pr);
                    Kohle_Real.Text = Double_To_String_Max_4_Dig(Kohle_Er - Kohle_Pr);
                    Titan_Real.Text = Double_To_String_Max_4_Dig(Titan_Er - Titan_Pr);
                    Thorium_Real.Text = Double_To_String_Max_4_Dig(Thorium_Er - Thorium_Pr);
                    Schrott_Real.Text = Double_To_String_Max_4_Dig(Schrott_Er - Schrott_Pr);
                    //Produktionkosten
                    Kupfer_Produktionskosten.Text = Double_To_String_Max_4_Dig(Kupfer_Pr);
                    Schrott_Produktionskosten.Text = Double_To_String_Max_4_Dig(Schrott_Pr);
                    Blei_Produktionskosten.Text = Double_To_String_Max_4_Dig(Blei_Pr);
                    Sand_Produktionskosten.Text = Double_To_String_Max_4_Dig(Sand_Pr);
                    Kohle_Produktionskosten.Text = Double_To_String_Max_4_Dig(Kohle_Pr);
                    Titan_Produktionskosten.Text = Double_To_String_Max_4_Dig(Titan_Pr);
                    Thorium_Produktionskosten.Text = Double_To_String_Max_4_Dig(Thorium_Pr);
                    //Erzeugung
                    Kupfer_Erzeugung.Text = Double_To_String_Max_4_Dig(Kupfer_Er);
                    Schrott_Erzeugung.Text = Double_To_String_Max_4_Dig(Schrott_Er);
                    Blei_Erzeugung.Text = Double_To_String_Max_4_Dig(Blei_Er);
                    Sand_Erzeugung.Text = Double_To_String_Max_4_Dig(Sand_Er);
                    Kohle_Erzeugung.Text = Double_To_String_Max_4_Dig(Kohle_Er);
                    Titan_Erzeugung.Text = Double_To_String_Max_4_Dig(Titan_Er);
                    Thorium_Erzeugung.Text = Double_To_String_Max_4_Dig(Thorium_Er);

                    //Flüssigkeiten
                    //Reale Kernzufur
                    Schlacke_Real.Text = Double_To_String_Max_4_Dig(Schlacke_Er - Schlacke_Pr);
                    Wasser_Real.Text = Double_To_String_Max_4_Dig(Wasser_Er - Wasser_Pr);
                    Kryoflüssigkeit_Real.Text = Double_To_String_Max_4_Dig(Kryoflüssigkeit_Er - Kryoflüssigkeit_Pr);
                    Öl_Real.Text = Double_To_String_Max_4_Dig(Öl_Er - Öl_Pr);
                    //Produktionkosten
                    Schlacke_Produktionskosten.Text = Double_To_String_Max_4_Dig(Schlacke_Pr);
                    Wasser_Produktionskosten.Text = Double_To_String_Max_4_Dig(Wasser_Pr);
                    Kryoflüssigkeit_Produktionskosten.Text = Double_To_String_Max_4_Dig(Kryoflüssigkeit_Pr);
                    Öl_Produktionskosten.Text = Double_To_String_Max_4_Dig(Öl_Pr);
                    //Erzeugung
                    Schlacke_Erzeugung.Text = Double_To_String_Max_4_Dig(Schlacke_Er);
                    Wasser_Erzeugung.Text = Double_To_String_Max_4_Dig(Wasser_Er);
                    Kryoflüssigkeit_Erzeugung.Text = Double_To_String_Max_4_Dig(Kryoflüssigkeit_Er);
                    Öl_Erzeugung.Text = Double_To_String_Max_4_Dig(Öl_Er);
                    //Baukosten
                    Schlacke_Baukosten.Text = "0";
                    Wasser_Baukosten.Text = "0";
                    Kryoflüssigkeit_Baukosten.Text = "0";
                    Öl_Baukosten.Text = "0";

                    //Produkte
                    //Reale Kernzufur
                    SporenPod_Real.Text = Double_To_String_Max_4_Dig(SporenPod_Er - SporenPod_Pr);
                    Metaglas_Real.Text = Double_To_String_Max_4_Dig(Metaglas_Er - Metaglas_Pr);
                    Grafit_Real.Text = Double_To_String_Max_4_Dig(Grafit_Er - Grafit_Pr);
                    Silizium_Real.Text = Double_To_String_Max_4_Dig(Silizium_Er - Silizium_Pr);
                    Pyratit_Real.Text = Double_To_String_Max_4_Dig(Pyratit_Er - Pyratit_Pr);
                    ExplosiveMischung_Real.Text = Double_To_String_Max_4_Dig(ExplosiveMischung_Er - ExplosiveMischung_Pr);
                    Plastanium_Real.Text = Double_To_String_Max_4_Dig(Plastanium_Er - Plastanium_Pr);
                    Phasengewebe_Real.Text = Double_To_String_Max_4_Dig(Phasengewebe_Er - Phasengewebe_Pr);
                    Spannungslegierung_Real.Text = Double_To_String_Max_4_Dig(Spannungslegierung_Er - Spannungslegierung_Pr);
                    Strom_Real.Text = Double_To_String_Max_4_Dig(Strom_Er - Strom_Pr);
                    //Produktionkosten
                    SporenPod_Produktionskosten.Text = Double_To_String_Max_4_Dig(SporenPod_Pr);
                    Metaglas_Produktionskosten.Text = Double_To_String_Max_4_Dig(Metaglas_Pr);
                    Grafit_Produktionskosten.Text = Double_To_String_Max_4_Dig(Grafit_Pr);
                    Silizium_Produktionskosten.Text = Double_To_String_Max_4_Dig(Silizium_Pr);
                    Pyratit_Produktionskosten.Text = Double_To_String_Max_4_Dig(Pyratit_Pr);
                    ExplosiveMischung_Produktionskosten.Text = Double_To_String_Max_4_Dig(ExplosiveMischung_Pr);
                    Plastanium_Produktionskosten.Text = Double_To_String_Max_4_Dig(Plastanium_Pr);
                    Phasengewebe_Produktionskosten.Text = Double_To_String_Max_4_Dig(Phasengewebe_Pr);
                    Spannungslegierung_Produktionskosten.Text = Double_To_String_Max_4_Dig(Spannungslegierung_Pr);
                    Strom_Produktionskosten.Text = Double_To_String_Max_4_Dig(Strom_Pr);
                    //Erzeugung
                    SporenPod_Erzeugung.Text = Double_To_String_Max_4_Dig(SporenPod_Er);
                    Metaglas_Erzeugung.Text = Double_To_String_Max_4_Dig(Metaglas_Er);
                    Grafit_Erzeugung.Text = Double_To_String_Max_4_Dig(Grafit_Er);
                    Silizium_Erzeugung.Text = Double_To_String_Max_4_Dig(Silizium_Er);
                    Pyratit_Erzeugung.Text = Double_To_String_Max_4_Dig(Pyratit_Er);
                    ExplosiveMischung_Erzeugung.Text = Double_To_String_Max_4_Dig(ExplosiveMischung_Er);
                    Plastanium_Erzeugung.Text = Double_To_String_Max_4_Dig(Plastanium_Er);
                    Phasengewebe_Erzeugung.Text = Double_To_String_Max_4_Dig(Phasengewebe_Er);
                    Spannungslegierung_Erzeugung.Text = Double_To_String_Max_4_Dig(Spannungslegierung_Er);
                    Strom_Erzeugung.Text = Double_To_String_Max_4_Dig(Strom_Er);

                    //Fabriken
                    GrafitPresse_Be.Text = Convert.ToString(GrafitPresse_Pr);
                    MultiPresse_Be.Text = Convert.ToString(MultiPresse_Pr);
                    SiliziumSchmelzer_Be.Text = Convert.ToString(SiliziumSchmelzer_Pr);
                    SiliziumSchmelztiegel_Be.Text = Convert.ToString(SiliziumSchmelztiegel_Pr);
                    Brennofen_Be.Text = Convert.ToString(Brennofen_Pr);
                    PlastaniumVerdichter_Be.Text = Convert.ToString(PlastaniumVerdichter_Pr);
                    Phasenweber_Be.Text = Convert.ToString(Phasenweber_Pr);
                    Legierungsschmelze_Be.Text = Convert.ToString(Legierungsschmelze_Pr);
                    PyratitMixer_Be.Text = Convert.ToString(PyratitMixer_Pr);
                    Sprengmixer_Be.Text = Convert.ToString(Sprengmixer_Pr);

                    //Generatoren
                    Verbrennungsgenerator_Be.Text = Convert.ToString(Math.Ceiling(Verbrennungsgenerator_Pr * VerG_Div));
                    ThermischerGenerator_Be.Text = Convert.ToString(Math.Ceiling(ThermischerGenerator_Pr * TerG_Div));
                    Turbinengenerator_Be.Text = Convert.ToString(Math.Ceiling(Turbinengenerator_Pr * TurG_Div));
                    Differenzialgenerator_Be.Text = Convert.ToString(Math.Ceiling(Differenzialgenerator_Pr * DifG_Div));
                    RTGGenerator_Be.Text = Convert.ToString(Math.Ceiling(RTGGenerator_Pr * RTGG_Div));
                    Solarpanel_Be.Text = Convert.ToString(Math.Ceiling(Solarpanel_Pr * SolG_Div));
                    GroßesSolarpanel_Be.Text = Convert.ToString(Math.Ceiling(GroßesSolarpanel_Pr * GSG_Div));
                    ThoriumReaktor_Be.Text = Convert.ToString(Math.Ceiling(ThoriumReaktor_Pr * TorG_Div));
                    Schlaggenerator_Be.Text = Convert.ToString(Math.Ceiling(Schlaggenerator_Pr * SchG_Div));

                    //Bohrer
                    Kupfer_MBohrer_OW_Be.Text = Double_To_String_Max_4_Dig(Kupfer_MB_OW_Value * BM_OW_Div); Kupfer_MBohrer_MW_Be.Text = Double_To_String_Max_4_Dig(Kupfer_MB_MW_Value * BM_MW_Div);
                    Blei_MBohrer_OW_Be.Text = Double_To_String_Max_4_Dig(Blei_MB_OW_Value * BM_OW_Div); Blei_MBohrer_MW_Be.Text = Double_To_String_Max_4_Dig(Blei_MB_MW_Value * BM_MW_Div);
                    Sand_MBohrer_OW_Be.Text = Double_To_String_Max_4_Dig(Sand_MB_OW_Value * BM_OW_Div); Sand_MBohrer_MW_Be.Text = Double_To_String_Max_4_Dig(Sand_MB_MW_Value * BM_MW_Div);
                    Kohle_MBohrer_OW_Be.Text = Double_To_String_Max_4_Dig(Kohle_MB_OW_Value * BM_OW_Div); Kohle_MBohrer_MW_Be.Text = Double_To_String_Max_4_Dig(Kohle_MB_MW_Value * BM_MW_Div);
                    Schrott_MBohrer_OW_Be.Text = Double_To_String_Max_4_Dig(Schrott_MB_OW_Value * BM_OW_Div); Schrott_MBohrer_MW_Be.Text = Double_To_String_Max_4_Dig(Schrott_MB_MW_Value * BM_MW_Div);
                    Kupfer_PBohrer_OW_Be.Text = Double_To_String_Max_4_Dig(Kupfer_PB_OW_Value * BP_OW_Div); Kupfer_PBohrer_MW_Be.Text = Double_To_String_Max_4_Dig(Kupfer_PB_MW_Value * BP_MW_Div);
                    Blei_PBohrer_OW_Be.Text = Double_To_String_Max_4_Dig(Blei_PB_OW_Value * BP_OW_Div); Blei_PBohrer_MW_Be.Text = Double_To_String_Max_4_Dig(Blei_PB_MW_Value * BP_MW_Div);
                    Sand_PBohrer_OW_Be.Text = Double_To_String_Max_4_Dig(Sand_PB_OW_Value * BP_OW_Div); Sand_PBohrer_MW_Be.Text = Double_To_String_Max_4_Dig(Sand_PB_MW_Value * BP_MW_Div);
                    Kohle_PBohrer_OW_Be.Text = Double_To_String_Max_4_Dig(Kohle_PB_OW_Value * BP_OW_Div); Kohle_PBohrer_MW_Be.Text = Double_To_String_Max_4_Dig(Kohle_PB_MW_Value * BP_MW_Div);
                    Titan_PBohrer_OW_Be.Text = Double_To_String_Max_4_Dig(Titan_PB_OW_Value * BP_OW_Div); Titan_PBohrer_MW_Be.Text = Double_To_String_Max_4_Dig(Titan_PB_MW_Value * BP_MW_Div);
                    Schrott_PBohrer_OW_Be.Text = Double_To_String_Max_4_Dig(Schrott_PB_OW_Value * BP_OW_Div); Schrott_PBohrer_MW_Be.Text = Double_To_String_Max_4_Dig(Schrott_PB_MW_Value * BP_MW_Div);
                    Kupfer_LBohrer_OW_Be.Text = Double_To_String_Max_4_Dig(Kupfer_LB_OW_Value * BL_OW_Div); Kupfer_LBohrer_MW_Be.Text = Double_To_String_Max_4_Dig(Kupfer_LB_MW_Value * BL_MW_Div);
                    Blei_LBohrer_OW_Be.Text = Double_To_String_Max_4_Dig(Blei_LB_OW_Value * BL_OW_Div); Blei_LBohrer_MW_Be.Text = Double_To_String_Max_4_Dig(Blei_LB_MW_Value * BL_MW_Div);
                    Sand_LBohrer_OW_Be.Text = Double_To_String_Max_4_Dig(Sand_LB_OW_Value * BL_OW_Div); Sand_LBohrer_MW_Be.Text = Double_To_String_Max_4_Dig(Sand_LB_MW_Value * BL_MW_Div);
                    Kohle_LBohrer_OW_Be.Text = Double_To_String_Max_4_Dig(Kohle_LB_OW_Value * BL_OW_Div); Kohle_LBohrer_MW_Be.Text = Double_To_String_Max_4_Dig(Kohle_LB_MW_Value * BL_MW_Div);
                    Titan_LBohrer_OW_Be.Text = Double_To_String_Max_4_Dig(Titan_LB_OW_Value * BL_OW_Div); Titan_LBohrer_MW_Be.Text = Double_To_String_Max_4_Dig(Titan_LB_MW_Value * BL_MW_Div);
                    Thorium_LBohrer_OW_Be.Text = Double_To_String_Max_4_Dig(Thorium_LB_OW_Value * BL_OW_Div); Thorium_LBohrer_MW_Be.Text = Double_To_String_Max_4_Dig(Thorium_LB_MW_Value * BL_MW_Div);
                    Schrott_LBohrer_OW_Be.Text = Double_To_String_Max_4_Dig(Schrott_LB_OW_Value * BL_OW_Div); Schrott_LBohrer_MW_Be.Text = Double_To_String_Max_4_Dig(Schrott_LB_MW_Value * BL_MW_Div);
                    Kupfer_SBohrer_OW_Be.Text = Double_To_String_Max_4_Dig(Kupfer_SB_OW_Value * BS_OW_Div); Kupfer_SBohrer_MW_Be.Text = Double_To_String_Max_4_Dig(Kupfer_SB_MW_Value * BS_MW_Div);
                    Blei_SBohrer_OW_Be.Text = Double_To_String_Max_4_Dig(Blei_SB_OW_Value * BS_OW_Div); Blei_SBohrer_MW_Be.Text = Double_To_String_Max_4_Dig(Blei_SB_MW_Value * BS_MW_Div);
                    Sand_SBohrer_OW_Be.Text = Double_To_String_Max_4_Dig(Sand_SB_OW_Value * BS_OW_Div); Sand_SBohrer_MW_Be.Text = Double_To_String_Max_4_Dig(Sand_SB_MW_Value * BS_MW_Div);
                    Kohle_SBohrer_OW_Be.Text = Double_To_String_Max_4_Dig(Kohle_SB_OW_Value * BS_OW_Div); Kohle_SBohrer_MW_Be.Text = Double_To_String_Max_4_Dig(Kohle_SB_MW_Value * BS_MW_Div);
                    Titan_SBohrer_OW_Be.Text = Double_To_String_Max_4_Dig(Titan_SB_OW_Value * BS_OW_Div); Titan_SBohrer_MW_Be.Text = Double_To_String_Max_4_Dig(Titan_SB_MW_Value * BS_MW_Div);
                    Thorium_SBohrer_OW_Be.Text = Double_To_String_Max_4_Dig(Thorium_SB_OW_Value * BS_OW_Div); Thorium_SBohrer_MW_Be.Text = Double_To_String_Max_4_Dig(Thorium_SB_MW_Value * BS_MW_Div);
                    Schrott_SBohrer_OW_Be.Text = Double_To_String_Max_4_Dig(Schrott_SB_OW_Value * BS_OW_Div); Schrott_SBohrer_MW_Be.Text = Double_To_String_Max_4_Dig(Schrott_SB_MW_Value * BS_MW_Div);

                    //Pumpe
                    Wasser_MP_Be.Text = Double_To_String_Max_4_Dig(Wasser_MP_Value * MP_Div);
                    Kryoflüssigkeit_MP_Be.Text = Double_To_String_Max_4_Dig(Kryoflüssigkeit_MP_Value * MP_Div);
                    Öl_MP_Be.Text = Double_To_String_Max_4_Dig(Öl_MP_Value * MP_Div);
                    Schlacke_MP_Be.Text = Double_To_String_Max_4_Dig(Schlacke_MP_Value * MP_Div);
                    Wasser_RP_Be.Text = Double_To_String_Max_4_Dig(Wasser_RP_Value * RP_Div);
                    Kryoflüssigkeit_RP_Be.Text = Double_To_String_Max_4_Dig(Kryoflüssigkeit_RP_Value * RP_Div);
                    Öl_RP_Be.Text = Double_To_String_Max_4_Dig(Öl_RP_Value * RP_Div);
                    Schlacke_RP_Be.Text = Double_To_String_Max_4_Dig(Schlacke_RP_Value * RP_Div);
                    Wasser_TP_Be.Text = Double_To_String_Max_4_Dig(Wasser_TP_Value * TP_Div);
                    Kryoflüssigkeit_TP_Be.Text = Double_To_String_Max_4_Dig(Kryoflüssigkeit_TP_Value * TP_Div);
                    Öl_TP_Be.Text = Double_To_String_Max_4_Dig(Öl_TP_Value * TP_Div);
                    Schlacke_TP_Be.Text = Double_To_String_Max_4_Dig(Schlacke_TP_Value * TP_Div);

                    //secundär Rohstoffe
                    WasserExtractor_Be.Text = Convert.ToString(WasserExtractor_Pr);
                    Kultivierer_Be.Text = Convert.ToString(Kultivierer_Pr);
                    ÖlExtractor_Be.Text = Convert.ToString(ÖlExtractor_Pr);
                    Sporenpresse_Be.Text = Convert.ToString(Sporenpresse_Pr);
                    Pulverisierer_Be.Text = Convert.ToString(Pulverisierer_Pr);
                    Kohlenzentriefuge_Be.Text = Convert.ToString(Kohlenzentriefuge_Pr);
                    Kryoflüssigkeitsmixer_Be.Text = Convert.ToString(Kryoflüssigkeitsmixer_Pr);
                    Schmelzer_Be.Text = Convert.ToString(Schmelzer_Pr);
                    Trenner_Be.Text = Convert.ToString(Trenner_Pr);
                    GroßerTrenner_Be.Text = Convert.ToString(GroßerTrenner_Pr);

                    //Baukosten
                    Kupfer_Baukosten.Text = Convert.ToString(
                        //Fabriken
                        (GrafitPresse + GrafitPresse_Pr) * 75 +
                        (SiliziumSchmelzer + SiliziumSchmelzer_Pr) * 30 +
                        (Brennofen + Brennofen_Pr) * 60 +
                        (PyratitMixer + PyratitMixer_Pr) * 50 +
                        //Generatoren
                        (Verbrennungsgenerator + Verbrennungsgenerator_Pr) * 25 +
                        (ThermischerGenerator + ThermischerGenerator_Pr) * 40 +
                        (Turbinengenerator + Turbinengenerator_Pr) * 35 +
                        (Differenzialgenerator + Differenzialgenerator_Pr) * 70 +
                        //Bohrer
                        (MB_MW_all() + MB_OW_all()) * 12 + (PB_MW_all() + PB_OW_all()) * 18 +
                        (LB_MW_all() + LB_OW_all()) * 35 + (SB_MW_all() + SB_OW_all()) * 65 +
                        //Pumpen
                        MP_all() * 15 + RP_all() * 70 + TP_all() * 80 +
                        //secundär Rohstoffe
                        (WasserExtractor + WasserExtractor_Pr) * 30 +
                        (Kultivierer + Kultivierer_Pr) * 25 +
                        (ÖlExtractor + ÖlExtractor_Pr) * 150 +
                        (Pulverisierer + Pulverisierer_Pr) * 30 +
                        (Schmelzer + Schmelzer_Pr) * 30 +
                        (Trenner + Trenner_Pr) * 30 +
                        //Mauern
                        Kupfermauer * 6 +
                        GroßeKupfermauer * 24 +
                        //Schutzeinrichtungen
                        Batterie * 5 +
                        Reparateur * 25 +
                        Reparaturpunkt * 30 +
                        //Geschütze
                        Doppelgeschütz * 35 +
                        Luftgeschütz * 85 +
                        Scatter * 25 +
                        Hail * 40 +
                        Welle * 25 +
                        Lancer * 60 +
                        Arcus * 50 +
                        Salve * 100 +
                        Zünder * 225 +
                        Zerstörer * 150 +
                        Zyklon * 200 +
                        Foreshadow * 1000 +
                        Phantom * 900 +
                        Meltdown * 1200 +
                        //Truppen Produktion
                        Bodenfabrik_Zw * 50 +
                        Luftfabrik_Zw * 60 +
                        Wasserfabrik_Zw * 150 +
                        HinzufügenderRekonstrukeur_Zw * 200);
                    Schrott_Baukosten.Text = "0";
                    Blei_Baukosten.Text = Convert.ToString(
                        //Fabriken
                        (GrafitPresse + GrafitPresse_Pr) * 30 +
                        (MultiPresse + MultiPresse_Pr) * 100 +
                        (SiliziumSchmelzer + SiliziumSchmelzer_Pr) * 25 +
                        (Brennofen + Brennofen_Pr) * 30 +
                        (PlastaniumVerdichter + PlastaniumVerdichter_Pr) * 115 +
                        (Phasenweber + Phasenweber_Pr) * 120 +
                        (Legierungsschmelze + Legierungsschmelze_Pr) * 80 +
                        (PyratitMixer + PyratitMixer_Pr) * 25 +
                        (Sprengmixer + Sprengmixer_Pr) * 30 +
                        //Generatoren
                        (Verbrennungsgenerator + Verbrennungsgenerator_Pr) * 15 +
                        (ThermischerGenerator + ThermischerGenerator_Pr) * 50 +
                        (Turbinengenerator + Turbinengenerator_Pr) * 40 +
                        (Differenzialgenerator + Differenzialgenerator_Pr) * 100 +
                        (RTGGenerator + RTGGenerator_Pr) * 100 +
                        (Solarpanel + Solarpanel_Pr) * 10 +
                        (GroßesSolarpanel + GroßesSolarpanel_Pr) * 80 +
                        (ThoriumReaktor + ThoriumReaktor_Pr) * 300 +
                        (Schlaggenerator + Schlaggenerator_Pr) * 500 +
                        //secundär Rohstoffe
                        (WasserExtractor + WasserExtractor_Pr) * 30 +
                        (Kultivierer + Kultivierer_Pr) * 25 +
                        (ÖlExtractor + ÖlExtractor_Pr) * 115 +
                        (Sporenpresse + Sporenpresse_Pr) * 35 +
                        (Pulverisierer + Pulverisierer_Pr) * 25 +
                        (Kohlenzentriefuge + Kohlenzentriefuge_Pr) * 30 +
                        (Kryoflüssigkeitsmixer + Kryoflüssigkeitsmixer_Pr) * 65 +
                        (Schmelzer + Schmelzer_Pr) * 35 +
                        //Schutzeinrichtungen
                        Batterie * 20 +
                        GroßeBatterie * 40 +
                        Reparateur * 30 +
                        Reparaturprojektor * 100 +
                        BeschleunigungsProjektor * 100 +
                        BeschleunigungsMaschine * 200 +
                        KraftfeldProjektor * 100 +
                        SchockMine * 25 +
                        Reparaturpunkt * 30 +
                        //Geschütze
                        Luftgeschütz * 45 +
                        Welle * 75 +
                        Lancer * 70 +
                        Arcus * 50 +
                        Tsunami * 400 +
                        Meltdown * 350 +
                        //Truppen Produktion
                        Bodenfabrik_Zw * 120 +
                        Luftfabrik_Zw * 70 +
                        Wasserfabrik_Zw * 130 +
                        HinzufügenderRekonstrukeur_Zw * 120 +
                        MultiplikativerRekonstrukeur_Zw * 650 +
                        ExponenziellerRekonstrukeur_Zw * 2000 +
                        TretrativerRekonstrukeur_Zw * 4000
                        );
                    Sand_Baukosten.Text = "0";
                    Kohle_Baukosten.Text = "0";
                    Titan_Baukosten.Text = Convert.ToString(
                        //Fabriken
                        (MultiPresse + MultiPresse_Pr) * 100 +
                        (SiliziumSchmelztiegel + SiliziumSchmelztiegel_Pr) * 120 +
                        (PlastaniumVerdichter + PlastaniumVerdichter_Pr) * 80 +
                        (Sprengmixer + Sprengmixer_Pr) * 20 +
                        //Generatoren
                        (Differenzialgenerator + Differenzialgenerator_Pr) * 50 +
                        //Bohrer
                        (LB_MW_all() + LB_OW_all()) * 20 + (SB_MW_all() + SB_OW_all()) * 50 +
                        //Pumpen
                        RP_all() * 35 + TP_all() * 40 +
                        //secundär Rohstoffe
                        (Kohlenzentriefuge + Kohlenzentriefuge_Pr) * 20 +
                        (Kryoflüssigkeitsmixer + Kryoflüssigkeitsmixer_Pr) * 60 +
                        (Trenner + Trenner_Pr) * 25 +
                        (GroßerTrenner + GroßerTrenner_Pr) * 100 +
                        //Mauern
                        Titanmauer * 6 +
                        GroßeTitanmauer * 24 +
                        Tor * 6 +
                        GroßesTor * 24 +
                        //Schutzeinrichtungen
                        GroßeBatterie * 20 +
                        Behälter * 100 +
                        Tresor * 250 +
                        Reparaturprojektor * 25 +
                        BeschleunigungsProjektor * 75 +
                        BeschleunigungsMaschine * 130 +
                        KraftfeldProjektor * 75 +
                        //Geschütze
                        Lancer * 30 +
                        Parallax * 90 +
                        Schwärmer * 35 +
                        Salve * 50 +
                        Segment * 40 +
                        Tsunami * 250 +
                        Zerstörer * 60 +
                        Zyklon * 125 +
                        //Truppen Produktion
                        MultiplikativerRekonstrukeur_Zw * 350 +
                        ExponenziellerRekonstrukeur_Zw * 2000
                        );
                    Thorium_Baukosten.Text = Convert.ToString(
                        //Fabriken
                        (Phasenweber + Phasenweber_Pr) * 75 +
                        (Legierungsschmelze + Legierungsschmelze_Pr) * 70 +
                        //Generatoren
                        (RTGGenerator + RTGGenerator_Pr) * 50 +
                        (ThoriumReaktor + ThoriumReaktor_Pr) * 150 +
                        (Schlaggenerator + Schlaggenerator_Pr) * 100 +
                        //Bohrer
                        (SB_MW_all() + SB_OW_all()) * 75 +
                         //Pumpen
                         TP_all() * 35 +
                        //secundär Rohstoffe
                        (ÖlExtractor + ÖlExtractor_Pr) * 115 +
                        //Mauern
                        Thoriummauer * 6 +
                        GroßeThoriummauer * 24 +
                        //Schutzeinrichtungen
                        Tresor * 125 +
                        Reparaturstation * 80 +
                        //Geschütze
                        Segment * 40 +
                        Tsunami * 100 +
                        Zünder * 100 +
                        Phantom * 250 +
                        //Truppen Produktion
                        MultiplikativerRekonstrukeur_Zw * 650 +
                        ExponenziellerRekonstrukeur_Zw * 750 +
                        TretrativerRekonstrukeur_Zw * 1000
                        );

                    //Baukosten
                    SporenPod_Baukosten.Text = "0";
                    Metaglas_Baukosten.Text = Convert.ToString(
                        //Fabriken
                        (SiliziumSchmelztiegel + SiliziumSchmelztiegel_Pr) * 80 +
                        //Generatoren
                        (ThermischerGenerator + ThermischerGenerator_Pr) * 40 +
                        (Differenzialgenerator + Differenzialgenerator_Pr) * 50 +
                        (ThoriumReaktor + ThoriumReaktor_Pr) * 50 +
                        (Schlaggenerator + Schlaggenerator_Pr) * 250 +
                        //Pumpen
                        MP_all() * 10 + RP_all() * 50 + TP_all() * 90 +
                        //secundär Rohstoffe
                        (WasserExtractor + WasserExtractor_Pr) * 30 +
                        //Mauern
                        Phasenmauer * 2 +
                        GroßePhasenmauer * 8 +
                        //Geschütze
                        Welle * 45 +
                        Tsunami * 100 +
                        Foreshadow * 600
                        );
                    Grafit_Baukosten.Text = Convert.ToString(
                        //Fabriken
                        (MultiPresse + MultiPresse_Pr) * 50 +
                        (Brennofen + Brennofen_Pr) * 30 +
                        (PlastaniumVerdichter + PlastaniumVerdichter_Pr) * 60 +
                        //Generatoren
                        (ThermischerGenerator + ThermischerGenerator_Pr) * 35 +
                        (Turbinengenerator + Turbinengenerator_Pr) * 25 +
                        (ThoriumReaktor + ThoriumReaktor_Pr) * 150 +
                        (Schlaggenerator + Schlaggenerator_Pr) * 400 +
                        //Bohrer
                        (PB_MW_all() + PB_OW_all()) * 10 +
                        (LB_MW_all() + LB_OW_all()) * 30 +
                        //secundär Rohstoffe
                        (WasserExtractor + WasserExtractor_Pr) * 30 +
                        (ÖlExtractor + ÖlExtractor_Pr) * 175 +
                        (Kohlenzentriefuge + Kohlenzentriefuge_Pr) * 40 +
                        (Schmelzer + Schmelzer_Pr) * 45 +
                        (GroßerTrenner + GroßerTrenner_Pr) * 140 +
                        //Geschütze
                        Welle * 45 +
                        Tsunami * 100 +
                        Foreshadow * 600
                        );
                    Silizium_Baukosten.Text = Convert.ToString(
                        //Fabriken
                        (MultiPresse + MultiPresse_Pr) * 25 +
                        (SiliziumSchmelztiegel + SiliziumSchmelztiegel_Pr) * 60 +
                        (PlastaniumVerdichter + PlastaniumVerdichter_Pr) * 80 +
                        (Phasenweber + Phasenweber_Pr) * 130 +
                        (Legierungsschmelze + Legierungsschmelze_Pr) * 80 +
                        //Generatoren
                        (Verbrennungsgenerator + Verbrennungsgenerator_Pr) * 0 +
                        (ThermischerGenerator + ThermischerGenerator_Pr) * 35 +
                        (Turbinengenerator + Turbinengenerator_Pr) * 30 +
                        (Differenzialgenerator + Differenzialgenerator_Pr) * 65 +
                        (RTGGenerator + RTGGenerator_Pr) * 75 +
                        (Solarpanel + Solarpanel_Pr) * 15 +
                        (GroßesSolarpanel + GroßesSolarpanel_Pr) * 110 +
                        (ThoriumReaktor + ThoriumReaktor_Pr) * 200 +
                        (Schlaggenerator + Schlaggenerator_Pr) * 300 +
                        //Bohrer
                        (LB_MW_all() + LB_OW_all()) * 30 + (SB_MW_all() + SB_OW_all()) * 60 +
                        //Pumpen
                        MP_all() * 78 + RP_all() * 20 + TP_all() * 30 +
                        //secundär Rohstoffe
                        (Kultivierer + Kultivierer_Pr) * 10 +
                        (ÖlExtractor + ÖlExtractor_Pr) * 75 +
                        (Sporenpresse + Sporenpresse_Pr) * 30 +
                        (Kryoflüssigkeitsmixer + Kryoflüssigkeitsmixer_Pr) * 40 +
                        (GroßerTrenner + GroßerTrenner_Pr) * 150 +
                        //Mauern
                        Tor * 4 +
                        GroßesTor * 16 +
                        //Schutzeinrichtungen
                        GroßeBatterie * 20 +
                        Reparaturprojektor * 40 +
                        BeschleunigungsProjektor * 75 +
                        BeschleunigungsMaschine * 130 +
                        KraftfeldProjektor * 125 +
                        SchockMine * 12 +
                        Reparaturpunkt * 20 +
                        Reparaturstation * 90 +
                        //Geschütze
                        Lancer * 60 +
                        Parallax * 120 +
                        Schwärmer * 30 +
                        Segment * 130 +
                        Foreshadow * 600 +
                        Meltdown * 325 +
                        //Truppen Produktion
                        Bodenfabrik_Zw * 80 +
                        HinzufügenderRekonstrukeur_Zw * 90 +
                        MultiplikativerRekonstrukeur_Zw * 450 +
                        ExponenziellerRekonstrukeur_Zw * 1000 +
                        TretrativerRekonstrukeur_Zw * 3000
                        );
                    Pyratit_Baukosten.Text = "0";
                    ExplosiveMischung_Baukosten.Text = "0";
                    Plastanium_Baukosten.Text = Convert.ToString(
                        //Fabriken
                        (SiliziumSchmelztiegel + SiliziumSchmelztiegel_Pr) * 35 +
                        //Generatoren
                        (RTGGenerator + RTGGenerator_Pr) * 75 +
                        //Mauern
                        Plastaniummauer * 5 +
                        GroßePlastaniummauer * 20 +
                        //Schutzeinrichtungen
                        BeschleunigungsProjektor * 30 +
                        BeschleunigungsMaschine * 80 +
                        Reparaturstation * 60 +
                        //Geschütze
                        Schwärmer * 45 +
                        Zyklon * 80 +
                        Foreshadow * 200 +
                        Phantom * 175 +
                        //Truppen Produktion
                        ExponenziellerRekonstrukeur_Zw * 450 +
                        TretrativerRekonstrukeur_Zw * 600
                        );
                    Phasengewebe_Baukosten.Text = Convert.ToString(
                        //Generatoren
                        (Differenzialgenerator + Differenzialgenerator_Pr) * 75 +
                        //Mauern
                        Phasenmauer * 6 +
                        GroßePhasenmauer * 24 +
                        //Geschütze
                        Segment * 40 +
                        //Truppen Produktion
                        ExponenziellerRekonstrukeur_Zw * 600 +
                        TretrativerRekonstrukeur_Zw * 600
                        );
                    Spannungslegierung_Baukosten.Text = Convert.ToString(
                        //Generatoren
                        (Schlaggenerator + Schlaggenerator_Pr) * 250 +
                        //secundär Rohstoffe
                        (GroßerTrenner + GroßerTrenner_Pr) * 70 +
                        //Mauern
                        Spannungsmauer * 6 +
                        GroßeSpannungsmauer * 24 +
                        //Schutzeinrichtungen
                        BeschleunigungsProjektor * 120 +
                        //Geschütze
                        Foreshadow * 300 +
                        Phantom * 250 +
                        Meltdown * 325 +
                        //Truppen Produktion
                        TretrativerRekonstrukeur_Zw * 800
                        );
                    Strom_Baukosten.Text = "0";

                }
            }
            else
            {
                Kupfer_Baukosten.Text = Convert.ToString(
                        //Fabriken
                        Convert.ToInt64(GrafitPresse_Zu.Value) + Convert.ToInt64(GrafitPresse_Be.Text) * 75 +
                        Convert.ToInt64(SiliziumSchmelzer_Zu.Value) + Convert.ToInt64(SiliziumSchmelzer_Be.Text) * 30 +
                        Convert.ToInt64(Brennofen_Zu.Value) + Convert.ToInt64(Brennofen_Be.Text) * 60 +
                        Convert.ToInt64(PyratitMixer_Zu.Value) + Convert.ToInt64(PyratitMixer_Be.Text) * 50 +
                        //Generatoren
                        Convert.ToInt64(Verbrennungsgenerator_Zu.Value) + Convert.ToInt64(Verbrennungsgenerator_Be.Text) * 25 +
                        Convert.ToInt64(ThermischerGenerator_Zu.Value) + Convert.ToInt64(ThermischerGenerator_Be.Text) * 40 +
                        Convert.ToInt64(Turbinengenerator_Zu.Value) + Convert.ToInt64(Turbinengenerator_Be.Text) * 35 +
                        Convert.ToInt64(Differenzialgenerator_Zu.Value) + Convert.ToInt64(Differenzialgenerator_Be.Text) * 70 +
                        //Bohrer
                        (MB_MW_all() + MB_OW_all()) * 12 + (PB_MW_all() + PB_OW_all()) * 18 +
                        (LB_MW_all() + LB_OW_all()) * 35 + (SB_MW_all() + SB_OW_all()) * 65 +
                        //Pumpen
                        MP_all() * 15 + RP_all() * 70 + TP_all() * 80 +
                        //secundär Rohstoffe
                        Convert.ToInt64(WasserExtractor_Zu.Value) + Convert.ToInt64(WasserExtractor_Be.Text) * 30 +
                        Convert.ToInt64(Kultivierer_Zu.Value) + Convert.ToInt64(Kultivierer_Be.Text) * 25 +
                        Convert.ToInt64(ÖlExtractor_Zu.Value) + Convert.ToInt64(ÖlExtractor_Be.Text) * 150 +
                        Convert.ToInt64(Pulverisierer_Zu.Value) + Convert.ToInt64(Pulverisierer_Be.Text) * 30 +
                        Convert.ToInt64(Schmelzer_Zu.Value) + Convert.ToInt64(Schmelzer_Be.Text) * 30 +
                        Convert.ToInt64(Trenner_Zu.Value) + Convert.ToInt64(Trenner_Be.Text) * 30 +
                        //Mauern
                        Convert.ToInt64(Kupfermauer_Zu.Value) * 6 +
                        Convert.ToInt64(GroßeKupfermauer_Zu.Value) * 24 +
                        //Schutzeinrichtungen
                        Convert.ToInt64(Batterie_Zu.Value) * 5 +
                        Convert.ToInt64(Reparateur_Zu.Value) * 25 +
                        Convert.ToInt64(Reparaturpunkt_Zu.Value) * 30 +
                        //Geschütze
                        Convert.ToInt64(Doppelgeschütz_Zu.Value) * 35 +
                        Convert.ToInt64(Luftgeschütz_Zu.Value) * 85 +
                        Convert.ToInt64(Scatter_Zu.Value) * 25 +
                        Convert.ToInt64(Hail_Zu.Value) * 40 +
                        Convert.ToInt64(Welle_Zu.Value) * 25 +
                        Convert.ToInt64(Lancer_Zu.Value) * 60 +
                        Convert.ToInt64(Arcus_Zu.Value) * 50 +
                        Convert.ToInt64(Salve_Zu.Value) * 100 +
                        Convert.ToInt64(Zünder_Zu.Value) * 225 +
                        Convert.ToInt64(Zerstörer_Zu.Value) * 150 +
                        Convert.ToInt64(Zyklon_Zu.Value) * 200 +
                        Convert.ToInt64(Foreshadow_Zu.Value) * 1000 +
                        Convert.ToInt64(Phantom_Zu.Value) * 900 +
                        Convert.ToInt64(Meltdown_Zu.Value) * 1200 +
                        //Truppen Produktion
                        (Convert.ToInt64(Bodenfabrik_Be.Text) + Convert.ToInt64(Bodenfabrik_Zu.Value)) * 50 +
                        (Convert.ToInt64(Luftfabrik_Be.Text) + Convert.ToInt64(Luftfabrik_Zu.Value)) * 60 +
                        (Convert.ToInt64(Wasserfabrik_Be.Text) + Convert.ToInt64(Wasserfabrik_Zu.Value)) * 150 +
                        (Convert.ToInt64(HinzufügenderRekonstrukeur_Be.Text) + Convert.ToInt64(HinzufügenderRekonstrukeur_Zu.Value)) * 200
                        );
                Blei_Baukosten.Text = Convert.ToString(
                        //Fabriken
                        (GrafitPresse_Zu.Value) + Convert.ToInt64(GrafitPresse_Be.Text) * 30 +
                        (MultiPresse_Zu.Value) + Convert.ToInt64(MultiPresse_Be.Text) * 100 +
                        (SiliziumSchmelzer_Zu.Value) + Convert.ToInt64(SiliziumSchmelzer_Be.Text) * 25 +
                        (Brennofen_Zu.Value) + Convert.ToInt64(Brennofen_Be.Text) * 30 +
                        (PlastaniumVerdichter_Zu.Value) + Convert.ToInt64(PlastaniumVerdichter_Be.Text) * 115 +
                        (Phasenweber_Zu.Value) + Convert.ToInt64(Phasenweber_Be.Text) * 120 +
                        (Legierungsschmelze_Zu.Value) + Convert.ToInt64(Legierungsschmelze_Be.Text) * 80 +
                        (PyratitMixer_Zu.Value) + Convert.ToInt64(PyratitMixer_Be.Text) * 25 +
                        (Sprengmixer_Zu.Value) + Convert.ToInt64(Sprengmixer_Be.Text) * 30 +
                        //Generatoren
                        (Verbrennungsgenerator_Zu.Value) + Convert.ToInt64(Verbrennungsgenerator_Be.Text) * 15 +
                        (ThermischerGenerator_Zu.Value) + Convert.ToInt64(ThermischerGenerator_Be.Text) * 50 +
                        (Turbinengenerator_Zu.Value) + Convert.ToInt64(Turbinengenerator_Be.Text) * 40 +
                        (Differenzialgenerator_Zu.Value) + Convert.ToInt64(Differenzialgenerator_Be.Text) * 100 +
                        (RTGGenerator_Zu.Value) + Convert.ToInt64(RTGGenerator_Be.Text) * 100 +
                        (Solarpanel_Zu.Value) + Convert.ToInt64(Solarpanel_Be.Text) * 10 +
                        (GroßesSolarpanel_Zu.Value) + Convert.ToInt64(GroßesSolarpanel_Be.Text) * 80 +
                        (ThoriumReaktor_Zu.Value) + Convert.ToInt64(ThoriumReaktor_Be.Text) * 300 +
                        (Schlaggenerator_Zu.Value) + Convert.ToInt64(Schlaggenerator_Be.Text) * 500 +
                        //secundär Rohstoffe
                        (WasserExtractor_Zu.Value) + Convert.ToInt64(WasserExtractor_Be.Text) * 30 +
                        (Kultivierer_Zu.Value) + Convert.ToInt64(Kultivierer_Be.Text) * 25 +
                        (ÖlExtractor_Zu.Value) + Convert.ToInt64(ÖlExtractor_Be.Text) * 115 +
                        (Sporenpresse_Zu.Value) + Convert.ToInt64(Sporenpresse_Be.Text) * 35 +
                        (Pulverisierer_Zu.Value) + Convert.ToInt64(Pulverisierer_Be.Text) * 25 +
                        (Kohlenzentriefuge_Zu.Value) + Convert.ToInt64(Kohlenzentriefuge_Be.Text) * 30 +
                        (Kryoflüssigkeitsmixer_Zu.Value) + Convert.ToInt64(Kryoflüssigkeitsmixer_Be.Text) * 65 +
                        (Schmelzer_Zu.Value) + Convert.ToInt64(Schmelzer_Be.Text) * 35 +
                        //Schutzeinrichtungen
                        Convert.ToInt64(Batterie_Zu.Value) * 20 +
                        Convert.ToInt64(GroßeBatterie_Zu.Value) * 40 +
                        Convert.ToInt64(Reparateur_Zu.Value) * 30 +
                        Convert.ToInt64(Reparaturprojektor_Zu.Value) * 100 +
                        Convert.ToInt64(BeschleunigungsProjektor_Zu.Value) * 100 +
                        Convert.ToInt64(BeschleunigungsMaschine_Zu.Value) * 200 +
                        Convert.ToInt64(KraftfeldProjektor_Zu.Value) * 100 +
                        Convert.ToInt64(SchockMine_Zu.Value) * 25 +
                        Convert.ToInt64(Reparaturpunkt_Zu.Value) * 30 +
                        //Geschütze
                        Convert.ToInt64(Luftgeschütz_Zu.Value) * 45 +
                        Convert.ToInt64(Welle_Zu.Value) * 75 +
                        Convert.ToInt64(Lancer_Zu.Value) * 70 +
                        Convert.ToInt64(Arcus_Zu.Value) * 50 +
                        Convert.ToInt64(Tsunami_Zu.Value) * 400 +
                        Convert.ToInt64(Meltdown_Zu.Value) * 350 +
                        //Truppen Produktion
                        (Convert.ToInt64(Bodenfabrik_Be.Text) + Convert.ToInt64(Bodenfabrik_Zu.Value)) * 120 +
                        (Convert.ToInt64(Luftfabrik_Be.Text) + Convert.ToInt64(Luftfabrik_Zu.Value)) * 70 +
                        (Convert.ToInt64(Wasserfabrik_Be.Text) + Convert.ToInt64(Wasserfabrik_Zu.Value)) * 130 +
                        (Convert.ToInt64(HinzufügenderRekonstrukeur_Be.Text) + Convert.ToInt64(HinzufügenderRekonstrukeur_Zu.Value)) * 120 +
                        (Convert.ToInt64(MultiplikativerRekonstrukeur_Be.Text) + Convert.ToInt64(MultiplikativerRekonstrukeur_Zu.Value)) * 650 +
                        (Convert.ToInt64(ExponenziellerRekonstrukeur_Be.Text) + Convert.ToInt64(ExponenziellerRekonstrukeur_Zu.Value)) * 2000 +
                        (Convert.ToInt64(TretrativerRekonstrukeur_Be.Text) + Convert.ToInt64(TretrativerRekonstrukeur_Zu.Value)) * 4000
                        );
                Titan_Baukosten.Text = Convert.ToString(
                        //Fabriken
                        (MultiPresse_Zu.Value) + Convert.ToInt64(MultiPresse_Be.Text) * 100 +
                        (SiliziumSchmelztiegel_Zu.Value) + Convert.ToInt64(SiliziumSchmelztiegel_Be.Text) * 120 +
                        (PlastaniumVerdichter_Zu.Value) + Convert.ToInt64(PlastaniumVerdichter_Be.Text) * 80 +
                        (Sprengmixer_Zu.Value) + Convert.ToInt64(Sprengmixer_Be.Text) * 20 +
                        //Generatoren
                        (Differenzialgenerator_Zu.Value) + Convert.ToInt64(Differenzialgenerator_Be.Text) * 50 +
                        //Bohrer
                        (LB_MW_all() + LB_OW_all()) * 20 + (SB_MW_all() + SB_OW_all()) * 50 +
                        //Pumpen
                        RP_all() * 35 + TP_all() * 40 +
                        //secundär Rohstoffe
                        (Kohlenzentriefuge_Zu.Value) + Convert.ToInt64(Kohlenzentriefuge_Be.Text) * 20 +
                        (Kryoflüssigkeitsmixer_Zu.Value) + Convert.ToInt64(Kryoflüssigkeitsmixer_Be.Text) * 60 +
                        (Trenner_Zu.Value) + Convert.ToInt64(Trenner_Be.Text) * 25 +
                        (GroßerTrenner_Zu.Value) + Convert.ToInt64(GroßerTrenner_Be.Text) * 100 +
                        //Mauern
                        Convert.ToInt64(Titanmauer_Zu.Value) * 6 +
                        Convert.ToInt64(GroßeTitanmauer_Zu.Value) * 24 +
                        Convert.ToInt64(Tor_Zu.Value) * 6 +
                        Convert.ToInt64(GroßesTor_Zu.Value) * 24 +
                        //Schutzeinrichtungen
                        Convert.ToInt64(GroßeBatterie_Zu.Value) * 20 +
                        Convert.ToInt64(Behälter_Zu.Value) * 100 +
                        Convert.ToInt64(Tresor_Zu.Value) * 250 +
                        Convert.ToInt64(Reparaturprojektor_Zu.Value) * 25 +
                        Convert.ToInt64(BeschleunigungsProjektor_Zu.Value) * 75 +
                        Convert.ToInt64(BeschleunigungsMaschine_Zu.Value) * 130 +
                        Convert.ToInt64(KraftfeldProjektor_Zu.Value) * 75 +
                        //Geschütze
                        Convert.ToInt64(Lancer_Zu.Value) * 30 +
                        Convert.ToInt64(Parallax_Zu.Value) * 90 +
                        Convert.ToInt64(Schwärmer_Zu.Value) * 35 +
                        Convert.ToInt64(Salve_Zu.Value) * 50 +
                        Convert.ToInt64(Segment_Zu.Value) * 40 +
                        Convert.ToInt64(Tsunami_Zu.Value) * 250 +
                        Convert.ToInt64(Zerstörer_Zu.Value) * 60 +
                        Convert.ToInt64(Zyklon_Zu.Value) * 125 +
                        //Truppen Produktion
                        (Convert.ToInt64(MultiplikativerRekonstrukeur_Be.Text) + Convert.ToInt64(MultiplikativerRekonstrukeur_Zu.Value)) * 350 +
                        (Convert.ToInt64(ExponenziellerRekonstrukeur_Be.Text) + Convert.ToInt64(ExponenziellerRekonstrukeur_Zu.Value)) * 2000
                        );
                Thorium_Baukosten.Text = Convert.ToString(
                        //Fabriken
                        (Phasenweber_Zu.Value) + Convert.ToInt64(Phasenweber_Be.Text) * 75 +
                        (Legierungsschmelze_Zu.Value) + Convert.ToInt64(Legierungsschmelze_Be.Text) * 70 +
                        //Generatoren
                        (RTGGenerator_Zu.Value) + Convert.ToInt64(RTGGenerator_Be.Text) * 50 +
                        (ThoriumReaktor_Zu.Value) + Convert.ToInt64(ThoriumReaktor_Be.Text) * 150 +
                        (Schlaggenerator_Zu.Value) + Convert.ToInt64(Schlaggenerator_Be.Text) * 100 +
                        //Bohrer
                        (SB_MW_all() + SB_OW_all()) * 75 +
                         //Pumpen
                         TP_all() * 35 +
                        //secundär Rohstoffe
                        Convert.ToInt64(ÖlExtractor_Zu.Value) + Convert.ToInt64(ÖlExtractor_Be.Text) * 115 +
                        //Mauern
                        Convert.ToInt64(Thoriummauer_Zu.Value) * 6 +
                        Convert.ToInt64(GroßeThoriummauer_Zu.Value) * 24 +
                        //Schutzeinrichtungen
                        Convert.ToInt64(Tresor_Zu.Value) * 125 +
                        Convert.ToInt64(Reparaturstation_Zu.Value) * 80 +
                        //Geschütze
                        Convert.ToInt64(Segment_Zu.Value) * 40 +
                        Convert.ToInt64(Tsunami_Zu.Value) * 100 +
                        Convert.ToInt64(Zünder_Zu.Value) * 100 +
                        Convert.ToInt64(Phantom_Zu.Value) * 250 +
                        //Truppen Produktion
                        (Convert.ToInt64(MultiplikativerRekonstrukeur_Be.Text) + Convert.ToInt64(MultiplikativerRekonstrukeur_Zu.Value)) * 650 +
                        (Convert.ToInt64(ExponenziellerRekonstrukeur_Be.Text) + Convert.ToInt64(ExponenziellerRekonstrukeur_Zu.Value)) * 750 +
                        (Convert.ToInt64(TretrativerRekonstrukeur_Be.Text) + Convert.ToInt64(TretrativerRekonstrukeur_Zu.Value)) * 1000
                        );
                Metaglas_Baukosten.Text = Convert.ToString(
                        //Fabriken
                        Convert.ToInt64(SiliziumSchmelztiegel_Zu.Value) + Convert.ToInt64(SiliziumSchmelztiegel_Be.Text) * 80 +
                        //Generatoren
                        Convert.ToInt64(ThermischerGenerator_Zu.Value) + Convert.ToInt64(ThermischerGenerator_Be.Text) * 40 +
                        Convert.ToInt64(Differenzialgenerator_Zu.Value) + Convert.ToInt64(Differenzialgenerator_Be.Text) * 50 +
                        Convert.ToInt64(ThoriumReaktor_Zu.Value) + Convert.ToInt64(ThoriumReaktor_Be.Text) * 50 +
                        Convert.ToInt64(Schlaggenerator_Zu.Value) + Convert.ToInt64(Schlaggenerator_Be.Text) * 250 +
                        //Pumpen
                        MP_all() * 10 + RP_all() * 50 + TP_all() * 90 +
                        //secundär Rohstoffe
                        Convert.ToInt64(WasserExtractor_Zu.Value) + Convert.ToInt64(WasserExtractor_Be.Text) * 30 +
                        //Mauern
                        Convert.ToInt64(Phasenmauer_Zu.Value) * 2 +
                        Convert.ToInt64(GroßePhasenmauer_Zu.Value) * 8 +
                        //Geschütze
                        Convert.ToInt64(Welle_Zu.Value) * 45 +
                        Convert.ToInt64(Tsunami_Zu.Value) * 100 +
                        Convert.ToInt64(Foreshadow_Zu.Value) * 600
                        );
                Silizium_Baukosten.Text = Convert.ToString(
                        //Fabriken
                        (Convert.ToInt64(MultiPresse_Zu.Value) + Convert.ToInt64(MultiPresse_Be.Text)) * 25 +
                        (Convert.ToInt64(SiliziumSchmelztiegel_Zu.Value) + Convert.ToInt64(SiliziumSchmelztiegel_Be.Text)) * 60 +
                        (Convert.ToInt64(PlastaniumVerdichter_Zu.Value) + Convert.ToInt64(PlastaniumVerdichter_Be.Text)) * 80 +
                        (Convert.ToInt64(Phasenweber_Zu.Value) + Convert.ToInt64(Phasenweber_Be.Text)) * 130 +
                        (Convert.ToInt64(Legierungsschmelze_Zu.Value) + Convert.ToInt64(Legierungsschmelze_Be.Text)) * 80 +
                        //Generatoren
                        (Convert.ToInt64(Verbrennungsgenerator_Zu.Value) + Convert.ToInt64(Verbrennungsgenerator_Be.Text)) * 0 +
                        (Convert.ToInt64(ThermischerGenerator_Zu.Value) + Convert.ToInt64(ThermischerGenerator_Be.Text)) * 35 +
                        (Convert.ToInt64(Turbinengenerator_Zu.Value) + Convert.ToInt64(Turbinengenerator_Be.Text)) * 30 +
                        (Convert.ToInt64(Differenzialgenerator_Zu.Value) + Convert.ToInt64(Differenzialgenerator_Be.Text)) * 65 +
                        (Convert.ToInt64(RTGGenerator_Zu.Value) + Convert.ToInt64(RTGGenerator_Be.Text)) * 75 +
                        (Convert.ToInt64(Solarpanel_Zu.Value) + Convert.ToInt64(Solarpanel_Be.Text)) * 15 +
                        (Convert.ToInt64(GroßesSolarpanel_Zu.Value) + Convert.ToInt64(GroßesSolarpanel_Be.Text)) * 110 +
                        (Convert.ToInt64(ThoriumReaktor_Zu.Value) + Convert.ToInt64(ThoriumReaktor_Be.Text)) * 200 +
                        (Convert.ToInt64(Schlaggenerator_Zu.Value) + Convert.ToInt64(Schlaggenerator_Be.Text)) * 300 +
                        //Bohrer
                        (LB_MW_all() + LB_OW_all()) * 30 + (SB_MW_all() + SB_OW_all()) * 60 +
                        //Pumpen
                        MP_all() * 78 + RP_all() * 20 + TP_all() * 30 +
                        //secundär Rohstoffe
                        Convert.ToInt64(Kultivierer_Zu.Value + Kultivierer_Be.Text) * 10 +
                        Convert.ToInt64(ÖlExtractor_Zu.Value + ÖlExtractor_Be.Text) * 75 +
                        Convert.ToInt64(Sporenpresse_Zu.Value + Sporenpresse_Be.Text) * 30 +
                        Convert.ToInt64(Kryoflüssigkeitsmixer_Zu.Value + Kryoflüssigkeitsmixer_Be.Text) * 40 +
                        Convert.ToInt64(GroßerTrenner_Zu.Value + GroßerTrenner_Be.Text) * 150 +
                        //Mauern
                        Convert.ToInt64(Tor_Zu.Value) * 4 +
                        Convert.ToInt64(GroßesTor_Zu.Value) * 16 +
                        //Schutzeinrichtungen
                        Convert.ToInt64(GroßeBatterie_Zu.Value) * 20 +
                        Convert.ToInt64(Reparaturprojektor_Zu.Value) * 40 +
                        Convert.ToInt64(BeschleunigungsProjektor_Zu.Value) * 75 +
                        Convert.ToInt64(BeschleunigungsMaschine_Zu.Value) * 130 +
                        Convert.ToInt64(KraftfeldProjektor_Zu.Value) * 125 +
                        Convert.ToInt64(SchockMine_Zu.Value) * 12 +
                        Convert.ToInt64(Reparaturpunkt_Zu.Value) * 20 +
                        Convert.ToInt64(Reparaturstation_Zu.Value) * 90 +
                //Geschütze
                        Convert.ToInt64(Lancer_Zu.Value) * 60 +
                        Convert.ToInt64(Parallax_Zu.Value) * 120 +
                        Convert.ToInt64(Schwärmer_Zu.Value) * 30 +
                        Convert.ToInt64(Segment_Zu.Value) * 130 +
                        Convert.ToInt64(Foreshadow_Zu.Value) * 600 +
                        Convert.ToInt64(Meltdown_Zu.Value) * 325 +
                        //Truppen Produktion
                        (Convert.ToInt64(Bodenfabrik_Be.Text) + Convert.ToInt64(Bodenfabrik_Zu.Value)) * 80 +
                        (Convert.ToInt64(HinzufügenderRekonstrukeur_Be.Text) + Convert.ToInt64(HinzufügenderRekonstrukeur_Zu.Value)) * 90 +
                        (Convert.ToInt64(MultiplikativerRekonstrukeur_Be.Text) + Convert.ToInt64(MultiplikativerRekonstrukeur_Zu.Value)) * 450 +
                        (Convert.ToInt64(ExponenziellerRekonstrukeur_Be.Text) + Convert.ToInt64(ExponenziellerRekonstrukeur_Zu.Value)) * 1000 +
                        (Convert.ToInt64(TretrativerRekonstrukeur_Be.Text) + Convert.ToInt64(TretrativerRekonstrukeur_Zu.Value)) * 3000
                        );
                Plastanium_Baukosten.Text = Convert.ToString(
                        //Fabriken
                        (Convert.ToInt64(SiliziumSchmelztiegel_Zu.Value) + Convert.ToInt64(SiliziumSchmelztiegel_Be.Text)) * 35 +
                        //Generatoren
                        (Convert.ToInt64(RTGGenerator_Zu.Value) + Convert.ToInt64(RTGGenerator_Be.Text)) * 75 +
                        //Mauern
                        Convert.ToInt64(Plastaniummauer_Zu.Value) * 5 +
                        Convert.ToInt64(GroßePlastaniummauer_Zu.Value) * 20 +
                        //Schutzeinrichtungen
                        Convert.ToInt64(BeschleunigungsProjektor_Zu.Value) * 30 +
                        Convert.ToInt64(BeschleunigungsMaschine_Zu.Value) * 80 +
                        Convert.ToInt64(Reparaturstation_Zu.Value) * 60 +
                        //Geschütze
                        Convert.ToInt64(Schwärmer_Zu.Value) * 45 +
                        Convert.ToInt64(Zyklon_Zu.Value) * 80 +
                        Convert.ToInt64(Foreshadow_Zu.Value) * 200 +
                        Convert.ToInt64(Phantom_Zu.Value) * 175 +
                        //Truppen Produktion
                        (Convert.ToInt64(ExponenziellerRekonstrukeur_Be.Text) + Convert.ToInt64(ExponenziellerRekonstrukeur_Zu.Value)) * 450 +
                        (Convert.ToInt64(TretrativerRekonstrukeur_Be.Text) + Convert.ToInt64(TretrativerRekonstrukeur_Zu.Value)) * 600
                        );
                Phasengewebe_Baukosten.Text = Convert.ToString(
                        //Generatoren
                        (Convert.ToInt64(Differenzialgenerator_Be.Text) + Convert.ToInt64(Differenzialgenerator_Zu.Value)) * 75 +
                        //Mauern
                        Convert.ToInt64(Phasenmauer_Zu.Value) * 6 +
                        Convert.ToInt64(GroßePhasenmauer_Zu.Value) * 24 +
                        //Geschütze
                        Convert.ToInt64(Segment_Zu.Value) * 40 +
                        //Truppen Produktion
                        (Convert.ToInt64(ExponenziellerRekonstrukeur_Be.Text) + Convert.ToInt64(ExponenziellerRekonstrukeur_Zu.Value)) * 600 +
                        (Convert.ToInt64(TretrativerRekonstrukeur_Be.Text) + Convert.ToInt64(TretrativerRekonstrukeur_Zu.Value)) * 600
                        );
                Spannungslegierung_Baukosten.Text = Convert.ToString(
                        //Generatoren
                        (Convert.ToInt64(Schlaggenerator_Be.Text) + Convert.ToInt64(Schlaggenerator_Zu.Value)) * 250 +
                        //secundär Rohstoffe
                        (Convert.ToInt64(GroßerTrenner_Be.Text) + Convert.ToInt64(GroßerTrenner_Zu.Value)) * 70 +
                        //Mauern
                        Convert.ToInt64(Spannungsmauer_Zu.Value) * 6 +
                        Convert.ToInt64(GroßeSpannungsmauer_Zu.Value) * 24 +
                        //Schutzeinrichtungen
                        Convert.ToInt64(BeschleunigungsProjektor_Zu.Value) * 120 +
                        //Geschütze
                        Convert.ToInt64(Foreshadow_Zu.Value) * 300 +
                        Convert.ToInt64(Phantom_Zu.Value) * 250 +
                        Convert.ToInt64(Meltdown_Zu.Value) * 325 +
                        //Truppen Produktion
                        (Convert.ToInt64(TretrativerRekonstrukeur_Be.Text) + Convert.ToInt64(TretrativerRekonstrukeur_Zu.Value)) * 800
                        );
            }
        }

        string Double_To_String_Max_4_Dig(double Value)
        {
            if (Double.IsNaN(Value) || Value < 0.0001)
            {
                return "0";
            }

            //Möglichkeiten:
            //Math.Round(example, 4);
            //Math.Round(0.12367, digits: 4, MidpointRounding.ToZero);
            //string[] specifiers = { "C", "E", "e", "F", "G", "N", "P",
            //                        "R", "#,000.000", "0.###E-000",
            //                        "000,000,000,000.00###" };
            // ==> .ToString({specifiers}{Zahl})

            if (Value / 100000 < 1)
            {
                return Math.Round(Value, 4).ToString();
            }
            if (Value / 1000000 < 1)
            {
                return Math.Round(Value, 3).ToString();
            }
            if (Value / 10000000 < 1)
            {
                return Math.Round(Value, 2).ToString();
            }
            if (Value / 100000000 < 1)
            {
                return Math.Round(Value, 1).ToString();
            }
            else
            {
                return Math.Round(Value).ToString();
            }
        }

        //Rohstoffe
        private void Kupfer_Wunsch_ValueChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                Calculate_New_Values();
            }
        }

        private void Blei_Wunsch_ValueChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                Calculate_New_Values();
            }
        }

        private void Sand_Wunsch_ValueChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                Calculate_New_Values();
            }
        }

        private void Kohle_Wunsch_ValueChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                Calculate_New_Values();
            }
        }

        private void Titan_Wunsch_ValueChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                Calculate_New_Values();
            }
        }

        private void Thorium_Wunsch_ValueChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                Calculate_New_Values();
            }
        }

        private void Schrott_Wunsch_ValueChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                Calculate_New_Values();
            }
        }

        //Flüssigkeiten
        private void Wasser_Wunsch_ValueChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                Calculate_New_Values();
            }
        }

        private void Kryoflüssigkeit_Wunsch_ValueChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                Calculate_New_Values();
            }
        }

        private void Öl_Wunsch_ValueChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                Calculate_New_Values();
            }
        }

        private void Schlacke_Wunsch_ValueChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                Calculate_New_Values();
            }
        }

        //Produkte
        private void SporenPod_Wunsch_ValueChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                Calculate_New_Values();
            }
        }

        private void Metaglas_Wunsch_ValueChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                Calculate_New_Values();
            }
        }

        private void Grafit_Wunsch_ValueChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                Calculate_New_Values();
            }
        }

        private void Silizium_Wunsch_ValueChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                Calculate_New_Values();
            }
        }

        private void Pyratit_Wunsch_ValueChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                Calculate_New_Values();
            }
        }

        private void ExplosiveMischung_Wunsch_ValueChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                Calculate_New_Values();
            }
        }

        private void Plastanium_Wunsch_ValueChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                Calculate_New_Values();
            }
        }

        private void Phasengewebe_Wunsch_ValueChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                Calculate_New_Values();
            }
        }

        private void Spannungslegierung_Wunsch_ValueChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                Calculate_New_Values();
            }
        }

        private void Strom_Wunsch_ValueChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                Calculate_New_Values();
            }
        }

        //Bohrer
        private void Kupfer_MBohrer_OW_Zu_ValueChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                Calculate_New_Values();
            }
        }

        private void Blei_MBohrer_OW_Zu_ValueChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                Calculate_New_Values();
            }
        }

        private void Sand_MBohrer_OW_Zu_ValueChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                Calculate_New_Values();
            }
        }

        private void Kohle_MBohrer_OW_Zu_ValueChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                Calculate_New_Values();
            }
        }

        private void Schrott_MBohrer_OW_Zu_ValueChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                Calculate_New_Values();
            }
        }

        private void Kupfer_MBohrer_MW_Zu_ValueChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                Calculate_New_Values();
            }
        }

        private void Blei_MBohrer_MW_Zu_ValueChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                Calculate_New_Values();
            }
        }

        private void Sand_MBohrer_MW_Zu_ValueChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                Calculate_New_Values();
            }
        }

        private void Kohle_MBohrer_MW_Zu_ValueChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                Calculate_New_Values();
            }
        }

        private void Schrott_MBohrer_MW_Zu_ValueChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                Calculate_New_Values();
            }
        }

        private void MBohrer_OW_Div_ValueChanged(object sender, EventArgs e)
        {
            Switch_Awelebles();
            if (!checkBox1.Checked)
            {
                Bohrer_Div_ValueChanged(1);
                Calculate_New_Values();
            }
        }

        private void MBohrer_MW_Div_ValueChanged(object sender, EventArgs e)
        {
            Switch_Awelebles();
            if (!checkBox1.Checked)
            {
                Bohrer_Div_ValueChanged(2);
                Calculate_New_Values();
            }
        }

        private void Kupfer_PBohrer_OW_Zu_ValueChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                Calculate_New_Values();
            }
        }

        private void Blei_PBohrer_OW_Zu_ValueChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                Calculate_New_Values();
            }
        }

        private void Sand_PBohrer_OW_Zu_ValueChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                Calculate_New_Values();
            }
        }

        private void Kohle_PBohrer_OW_Zu_ValueChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                Calculate_New_Values();
            }
        }

        private void Titan_PBohrer_OW_Zu_ValueChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                Calculate_New_Values();
            }
        }

        private void Schrott_PBohrer_OW_Zu_ValueChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                Calculate_New_Values();
            }
        }

        private void PBohrer_OW_Div_ValueChanged(object sender, EventArgs e)
        {
            Switch_Awelebles();
            if (!checkBox1.Checked)
            {
                Bohrer_Div_ValueChanged(3);
                Calculate_New_Values();
            }
        }

        private void Kupfer_PBohrer_MW_Zu_ValueChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                Calculate_New_Values();
            }
        }

        private void Blei_PBohrer_MW_Zu_ValueChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                Calculate_New_Values();
            }
        }

        private void Sand_PBohrer_MW_Zu_ValueChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                Calculate_New_Values();
            }
        }

        private void Kohle_PBohrer_MW_Zu_ValueChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                Calculate_New_Values();
            }
        }

        private void Titan_PBohrer_MW_Zu_ValueChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                Calculate_New_Values();
            }
        }

        private void Schrott_PBohrer_MW_Zu_ValueChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                Calculate_New_Values();
            }
        }

        private void PBohrer_MW_Div_ValueChanged(object sender, EventArgs e)
        {
            Switch_Awelebles();
            if (!checkBox1.Checked)
            {
                Bohrer_Div_ValueChanged(4);
                Calculate_New_Values();
            }
        }

        private void Kupfer_LBohrer_OW_Zu_ValueChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                Calculate_New_Values();
            }
        }

        private void Blei_LBohrer_OW_Zu_ValueChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                Calculate_New_Values();
            }
        }

        private void Sand_LBohrer_OW_Zu_ValueChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                Calculate_New_Values();
            }
        }

        private void Kohle_LBohrer_OW_Zu_ValueChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                Calculate_New_Values();
            }
        }

        private void Titan_LBohrer_OW_Zu_ValueChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                Calculate_New_Values();
            }
        }

        private void Thorium_LBohrer_OW_Zu_ValueChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                Calculate_New_Values();
            }
        }

        private void Schrott_LBohrer_OW_Zu_ValueChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                Calculate_New_Values();
            }
        }

        private void LBohrer_OW_Div_ValueChanged(object sender, EventArgs e)
        {
            Switch_Awelebles();
            if (!checkBox1.Checked)
            {
                Bohrer_Div_ValueChanged(5);
                Calculate_New_Values();
            }
        }

        private void Kupfer_LBohrer_MW_Zu_ValueChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                Calculate_New_Values();
            }
        }

        private void Blei_LBohrer_MW_Zu_ValueChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                Calculate_New_Values();
            }
        }

        private void Sand_LBohrer_MW_Zu_ValueChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                Calculate_New_Values();
            }
        }

        private void Kohle_LBohrer_MW_Zu_ValueChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                Calculate_New_Values();
            }
        }

        private void Titan_LBohrer_MW_Zu_ValueChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                Calculate_New_Values();
            }
        }

        private void Thorium_LBohrer_MW_Zu_ValueChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                Calculate_New_Values();
            }
        }

        private void Schrott_LBohrer_MW_Zu_ValueChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                Calculate_New_Values();
            }
        }

        private void LBohrer_MW_Div_ValueChanged(object sender, EventArgs e)
        {
            Switch_Awelebles();
            if (!checkBox1.Checked)
            {
                Bohrer_Div_ValueChanged(6);
                Calculate_New_Values();
            }
        }

        private void Kupfer_SBohrer_OW_Zu_ValueChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                Calculate_New_Values();
            }
        }

        private void Blei_SBohrer_OW_Zu_ValueChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                Calculate_New_Values();
            }
        }

        private void Sand_SBohrer_OW_Zu_ValueChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                Calculate_New_Values();
            }
        }

        private void Kohle_SBohrer_OW_Zu_ValueChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                Calculate_New_Values();
            }
        }

        private void Titan_SBohrer_OW_Zu_ValueChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                Calculate_New_Values();
            }
        }

        private void Thorium_SBohrer_OW_Zu_ValueChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                Calculate_New_Values();
            }
        }

        private void Schrott_SBohrer_OW_Zu_ValueChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                Calculate_New_Values();
            }
        }

        private void SBohrer_OW_Div_ValueChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                Bohrer_Div_ValueChanged(7);
                Calculate_New_Values();
            }
        }

        private void Kupfer_SBohrer_MW_Zu_ValueChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                Calculate_New_Values();
            }
        }

        private void Blei_SBohrer_MW_Zu_ValueChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                Calculate_New_Values();
            }
        }

        private void Sand_SBohrer_MW_Zu_ValueChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                Calculate_New_Values();
            }
        }

        private void Kohle_SBohrer_MW_Zu_ValueChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                Calculate_New_Values();
            }
        }

        private void Titan_SBohrer_MW_Zu_ValueChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                Calculate_New_Values();
            }
        }

        private void Thorium_SBohrer_MW_Zu_ValueChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                Calculate_New_Values();
            }
        }

        private void Schrott_SBohrer_MW_Zu_ValueChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                Calculate_New_Values();
            }
        }

        private void SBohrer_MW_Div_ValueChanged(object sender, EventArgs e)
        {
            Switch_Awelebles();
            if (!checkBox1.Checked)
            {
                Bohrer_Div_ValueChanged(8);
                Calculate_New_Values();
            }
        }

        //Pumpen
        private void Wasser_MP_Zu_ValueChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                Calculate_New_Values();
            }
        }

        private void Kryoflüssigkeit_MP_Zu_ValueChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                Calculate_New_Values();
            }
        }

        private void Öl_MP_Zu_ValueChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                Calculate_New_Values();
            }
        }

        private void Schlacke_MP_Zu_ValueChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                Calculate_New_Values();
            }
        }

        private void Wasser_RP_Zu_ValueChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                Calculate_New_Values();
            }
        }

        private void Kryoflüssigkeit_RP_Zu_ValueChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                Calculate_New_Values();
            }
        }

        private void Öl_RP_Zu_ValueChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                Calculate_New_Values();
            }
        }

        private void Schlacke_RP_Zu_ValueChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                Calculate_New_Values();
            }
        }

        private void Wasser_TP_Zu_ValueChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                Calculate_New_Values();
            }
        }

        private void Kryoflüssigkeit_TP_Zu_ValueChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                Calculate_New_Values();
            }
        }

        private void Öl_TP_Zu_ValueChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                Calculate_New_Values();
            }
        }

        private void Schlacke_TP_Zu_ValueChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                Calculate_New_Values();
            }
        }

        private void MPumpe_Div_ValueChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                Pumpen_Div_ValueChanged(1);
                Calculate_New_Values();
            }
        }

        private void RPumpe_Div_ValueChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                Pumpen_Div_ValueChanged(2);
                Calculate_New_Values();
            }
        }

        private void TPumpe_Div_ValueChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                Pumpen_Div_ValueChanged(3);
                Calculate_New_Values();
            }
        }

        //Fabriken
        private void GrafitPresse_Zu_ValueChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                Calculate_New_Values();
            }
        }

        private void MultiPresse_Zu_ValueChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                Calculate_New_Values();
            }
        }

        private void SiliziumSchmelzer_Zu_ValueChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                Calculate_New_Values();
            }
        }

        private void SiliziumSchmelztiegel_Zu_ValueChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                Calculate_New_Values();
            }
        }

        private void Brennofen_Zu_ValueChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                Calculate_New_Values();
            }
        }

        private void PlastaniumVerdichter_Zu_ValueChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                Calculate_New_Values();
            }
        }

        private void Phasenweber_Zu_ValueChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                Calculate_New_Values();
            }
        }

        private void Legierungsschmelze_Zu_ValueChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                Calculate_New_Values();
            }
        }

        private void PyratitMixer_Zu_ValueChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                Calculate_New_Values();
            }
        }

        private void Sprengmixer_Zu_ValueChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                Calculate_New_Values();
            }
        }

        private void GrafitPresse_Div_ValueChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                Rohstoffproduktion_Ver_SelectedIndexChanged(1);
                Calculate_New_Values();
            }
        }

        private void MultiPresse_Div_ValueChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                Rohstoffproduktion_Ver_SelectedIndexChanged(2);
                Calculate_New_Values();
            }
        }

        private void SiliziumSchmelzer_Div_ValueChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                Rohstoffproduktion_Ver_SelectedIndexChanged(3);
                Calculate_New_Values();
            }
        }

        private void SiliziumSchmelztiegel_Div_ValueChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                Rohstoffproduktion_Ver_SelectedIndexChanged(4);
                Calculate_New_Values();
            }
        }

        private void Rohstoffproduktion_Ver_SelectedIndexChanged(short a)
        {
            bool Grafit = false, Silizium = false, Öl = false;
            Error_s = "";

            if (GrafitPresse_Div.Value == 0 && MultiPresse_Div.Value == 0)// || (GrafitPresse_Div.Value + MultiPresse_Div.Value) != 100)
            {
                Error_s += "Grafit-Presse-Verteilung, Multi-Presse-Verteilung\n";
                Grafit = true;
            }
            if (SiliziumSchmelzer_Div.Value == 0 && SiliziumSchmelztiegel_Div.Value == 0)// || (SiliziumSchmelzer_Div.Value + SiliziumSchmelztiegel_Div.Value) == 0)
            {
                Error_s += "Silizium-Schmelzer-Verteilung, Siliium-Schmelztigel-Verteilung\n";
                Silizium = true;
            }
            if (ÖlExtractor_Div.Value == 0 && Sporenpresse_Div.Value == 0)// || (ÖlExtractor_Div.Value + Sporenpresse_Div.Value) == 0)
            {
                Error_s += "Öl-Extractor-Verteilung, Sporen-Presse-Verteilung\n";
                Öl = true;
            }

            if (Error_s.Length > 0)
            {
                Error_s += "The following values ​​preserve 0:\n" + Error_s;

                if (Grafit)
                {
                    Error_s += "The Grafit-Presse-Verteilung value is set to 100%\nThe Multi-Presse-Verteilung value is set to 0%\n";
                }
                if (Silizium)
                {
                    Error_s += "The Silizium-Schmelzer-Verteilung value is set to 100%\nThe Silizium-Schmelztiegel-Verteilung value is set to 0%\n";
                }
                if (Öl)
                {
                    Error_s += "The Sporen-Presse-Verteilung value is set to 100%\nThe Öl-Extractor-Verteilung value is set to 0%\n";
                }
                //Massege
                // Initializes the variables to pass to the MessageBox.Show method.
                string message = Error_s;
                string caption = "Error Detected in Input";
                MessageBoxButtons buttons = MessageBoxButtons.OK;

                // Displays the MessageBox.
                MessageBox.Show(message, caption, buttons);

                if (GrafitPresse_Div.Value != 100)
                {
                    GrafitPresse_Div.Value = 100;
                    R_count++;
                }
                if (MultiPresse_Div.Value != 0)
                {
                    MultiPresse_Div.Value = 0;
                    R_count++;
                }
                if (SiliziumSchmelzer_Div.Value != 100)
                {
                    SiliziumSchmelzer_Div.Value = 100;
                    R_count++;
                }
                if (SiliziumSchmelztiegel_Div.Value != 0)
                {
                    SiliziumSchmelztiegel_Div.Value = 0;
                    R_count++;
                }
                if (Sporenpresse_Div.Value != 100)
                {
                    Sporenpresse_Div.Value = 100;
                    R_count++;
                }
                if (ÖlExtractor_Div.Value != 0)
                {
                    ÖlExtractor_Div.Value = 0;
                    R_count++;
                }
            }

            //Fabriken
            double GP_alt = Convert.ToUInt32(GrafitPresse_Div.Value),
                   MP_alt = Convert.ToUInt32(MultiPresse_Div.Value),
                   SS_alt = Convert.ToUInt32(SiliziumSchmelzer_Div.Value),
                   ST_alt = Convert.ToUInt32(SiliziumSchmelztiegel_Div.Value),
                   ÖE_alt = Convert.ToUInt32(ÖlExtractor_Div.Value),
                   SP_alt = Convert.ToUInt32(Sporenpresse_Div.Value),
                   beta;
            //Rest, Prozente;



            if (R_count == 0)
            {
                R_count = 1;
                //          Convert.ToUInt32((GP_alt > 0) ? 1 : 0) +
                //          Convert.ToUInt32((MP_alt > 0) ? 1 : 0) +
                //          Convert.ToUInt32((SS_alt > 0) ? 1 : 0) +
                //          Convert.ToUInt32((ST_alt > 0) ? 1 : 0) +
                //          Convert.ToUInt32((ÖE_alt > 0) ? 1 : 0) +
                //          Convert.ToUInt32((SP_alt > 0) ? 1 : 0)
                //          - 1;
                //switch (a)
                //{
                //    case 1:
                //        Rest = 100 - GP_alt;
                //        Prozente = MP_alt + SS_alt + ST_alt + ÖE_alt + SP_alt;
                //        break;
                //    case 2:
                //        Rest = 100 - MP_alt;
                //        Prozente = GP_alt + SS_alt + ST_alt + ÖE_alt + SP_alt;
                //        break;
                //    case 3:
                //        Rest = 100 - SS_alt;
                //        Prozente = GP_alt + MP_alt + ST_alt + ÖE_alt + SP_alt;
                //        break;
                //    case 4:
                //        Rest = 100 - ST_alt;
                //        Prozente = GP_alt + MP_alt + SS_alt + ÖE_alt + SP_alt;
                //        break;
                //    case 5:
                //        Rest = 100 - ÖE_alt;
                //        Prozente = GP_alt + MP_alt + SS_alt + ST_alt + SP_alt;
                //        break;
                //    case 6:
                //        Rest = 100 - SP_alt;
                //        Prozente = GP_alt + MP_alt + SS_alt + ST_alt + ÖE_alt;
                //        break;
                //    default:
                //        Rest = 0;
                //        Prozente = 100;
                //        break;
                //}

                //Adjust Value
                if (a == 1)
                {
                    MultiPresse_Div.Value = Convert.ToDecimal(100 - GP_alt);
                }
                if (a == 2)
                {
                    GrafitPresse_Div.Value = Convert.ToDecimal(100 - MP_alt);
                }
                if (a == 3)
                {
                    SiliziumSchmelztiegel_Div.Value = Convert.ToDecimal(100 - SS_alt);
                }
                if (a == 4)
                {
                    SiliziumSchmelzer_Div.Value = Convert.ToDecimal(100 - ST_alt);
                }
                if (a == 5)
                {
                    Sporenpresse_Div.Value = Convert.ToDecimal(100 - ÖE_alt);
                }
                if (a == 6)
                {
                    ÖlExtractor_Div.Value = Convert.ToDecimal(100 - SP_alt);
                }
                if (a == 0)
                {
                    if (GrafitPresse_Div.Value + MultiPresse_Div.Value != 100)
                    {
                        beta = (GP_alt + MP_alt) / 100;

                        MultiPresse_Div.Value = Convert.ToDecimal(MP_alt / beta);
                        GrafitPresse_Div.Value = Convert.ToDecimal(GP_alt / beta);
                    }
                    if (SiliziumSchmelzer_Div.Value + SiliziumSchmelztiegel_Div.Value != 100)
                    {
                        beta = (SS_alt + ST_alt) / 100;

                        SiliziumSchmelztiegel_Div.Value = Convert.ToDecimal(ST_alt / beta);
                        SiliziumSchmelzer_Div.Value = Convert.ToDecimal(SS_alt / beta);
                    }
                    if (ÖlExtractor_Div.Value + Sporenpresse_Div.Value != 100)
                    {
                        beta = (ÖE_alt + SP_alt) / 100;

                        Sporenpresse_Div.Value = Convert.ToDecimal(SP_alt / beta);
                        ÖlExtractor_Div.Value = Convert.ToDecimal(ÖE_alt / beta);
                    }
                }
            }
            else
            {
                R_count--;
            }

            Switch_Awelebles();
        }

        //secundär Rohstoffe
        private void WasserExtractor_Zu_ValueChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                Calculate_New_Values();
            }
        }

        private void Kultivierer_Zu_ValueChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                Calculate_New_Values();
            }
        }

        private void ÖlExtractor_Zu_ValueChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                Calculate_New_Values();
            }
        }

        private void Sporenpresse_Zu_ValueChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                Calculate_New_Values();
            }
        }

        private void Pulverisierer_Zu_ValueChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                Calculate_New_Values();
            }
        }

        private void Kohlenzentriefuge_Zu_ValueChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                Calculate_New_Values();
            }
        }

        private void Kryoflüssigkeitsmixer_Zu_ValueChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                Calculate_New_Values();
            }
        }

        private void Schmelzer_Zu_ValueChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                Calculate_New_Values();
            }
        }

        private void Trenner_Zu_ValueChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                Calculate_New_Values();
            }
        }

        private void GroßerTrenner_Zu_ValueChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                Calculate_New_Values();
            }
        }

        private void ÖlExtractor_Ver_ValueChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                Rohstoffproduktion_Ver_SelectedIndexChanged(5);
                Calculate_New_Values();
            }
        }

        private void Sporenpresse_Ver_ValueChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                Rohstoffproduktion_Ver_SelectedIndexChanged(6);
                Calculate_New_Values();
            }
        }

        //Generatoren
        private void Verbrennungsgenerator_Zu_ValueChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                Calculate_New_Values();
            }
        }

        private void ThermischerGenerator_Zu_ValueChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                Calculate_New_Values();
            }
        }

        private void Turbinengenerator_Zu_ValueChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                Calculate_New_Values();
            }
        }

        private void Differenzialgenerator_Zu_ValueChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                Calculate_New_Values();
            }
        }

        private void RTGGenerator_Zu_ValueChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                Calculate_New_Values();
            }
        }

        private void Solarpanel_Zu_ValueChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                Calculate_New_Values();
            }
        }

        private void GroßesSolarpanel_Zu_ValueChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                Calculate_New_Values();
            }
        }

        private void ThoriumReaktor_Zu_ValueChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                Calculate_New_Values();
            }
        }

        private void Schlaggenerator_Zu_ValueChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                Calculate_New_Values();
            }
        }

        private void Verbrennungsgenerator_Energie_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                Calculate_New_Values();
            }
        }

        private void Turbinengenerator_Energie_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                Calculate_New_Values();
            }
        }

        private void RTGGenerator_Energie_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                Calculate_New_Values();
            }
        }

        private void Verbrennungsgenerator_Div_ValueChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                Generatoren_Div_ValueChanged(1);
                Calculate_New_Values();
            }
        }

        private void ThermischerGenerator_Div_ValueChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                Generatoren_Div_ValueChanged(2);
                Calculate_New_Values();
            }
        }

        private void Turbinengenerator_Div_ValueChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                Generatoren_Div_ValueChanged(3);
                Calculate_New_Values();
            }
        }

        private void Differenzialgenerator_Div_ValueChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                Generatoren_Div_ValueChanged(4);
                Calculate_New_Values();
            }
        }

        private void RTGGenerator_Div_ValueChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                Generatoren_Div_ValueChanged(5);
                Calculate_New_Values();
            }
        }

        private void Solarpanel_Div_ValueChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                Generatoren_Div_ValueChanged(6);
                Calculate_New_Values();
            }
        }

        private void GroßesSolarpanel_Div_ValueChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                Generatoren_Div_ValueChanged(7);
                Calculate_New_Values();
            }
        }

        private void ThoriumReaktor_Div_ValueChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                Generatoren_Div_ValueChanged(8);
                Calculate_New_Values();
            }
        }

        private void Schlaggenerator_Div_ValueChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                Generatoren_Div_ValueChanged(9);
                Calculate_New_Values();
            }
        }

        //Schutzeinrichtungen
        private void Batterie_Zu_ValueChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                Calculate_New_Values(false);
            }
        }

        private void GroßeBatterie_Zu_ValueChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                Calculate_New_Values(false);
            }
        }

        private void Behälter_Zu_ValueChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                Calculate_New_Values(false);
            }
        }

        private void Tresor_Zu_ValueChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                Calculate_New_Values(false);
            }
        }

        private void Reparateur_Zu_ValueChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                Calculate_New_Values();
            }
        }

        private void Reparaturprojektor_Zu_ValueChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                Calculate_New_Values();
            }
        }

        private void BeschleunigungsProjektor_Zu_ValueChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                Calculate_New_Values();
            }
        }

        private void BeschleunigungsMaschine_Zu_ValueChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                Calculate_New_Values();
            }
        }

        private void SchockMine_Zu_ValueChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                Calculate_New_Values(false);
            }
        }

        private void Reparaturstation_Zu_ValueChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                Calculate_New_Values();
            }
        }

        private void Reparaturstation_Kühlung_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                Calculate_New_Values();
            }
        }

        //Mauern
        private void Kupfermauer_Zu_ValueChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                Calculate_New_Values(false);
            }
        }

        private void GroßeKupfermauer_Zu_ValueChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                Calculate_New_Values(false);
            }
        }

        private void Titanmauer_Zu_ValueChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                Calculate_New_Values(false);
            }
        }

        private void GroßeTitanmauer_Zu_ValueChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                Calculate_New_Values(false);
            }
        }

        private void Thoriummauer_Zu_ValueChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                Calculate_New_Values(false);
            }
        }

        private void GroßeThoriummauer_Zu_ValueChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                Calculate_New_Values(false);
            }
        }

        private void Phasenmauer_Zu_ValueChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                Calculate_New_Values(false);
            }
        }

        private void GroßePhasenmauer_Zu_ValueChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                Calculate_New_Values(false);
            }
        }

        private void Spannungsmauer_Zu_ValueChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                Calculate_New_Values(false);
            }
        }

        private void GroßeSpannungsmauer_Zu_ValueChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                Calculate_New_Values(false);
            }
        }

        private void Plastaniummauer_Zu_ValueChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                Calculate_New_Values(false);
            }
        }

        private void GroßePlastaniummauer_Zu_ValueChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                Calculate_New_Values(false);
            }
        }

        private void Tor_Zu_ValueChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                Calculate_New_Values(false);
            }
        }

        private void GroßesTor_Zu_ValueChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                Calculate_New_Values(false);
            }
        }

        //Geschütze
        private void Doppelgeschütz_Zu_ValueChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                Calculate_New_Values();
            }
        }

        private void Luftgeschütz_Zu_ValueChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                Calculate_New_Values();
            }
        }

        private void Scatter_Zu_ValueChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                Calculate_New_Values();
            }
        }

        private void Hail_Zu_ValueChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                Calculate_New_Values();
            }
        }

        private void Welle_Zu_ValueChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                Calculate_New_Values();
            }
        }

        private void Lancer_Zu_ValueChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                Calculate_New_Values();
            }
        }

        private void Arcus_Zu_ValueChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                Calculate_New_Values();
            }
        }

        private void Parallax_Zu_ValueChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                Calculate_New_Values();
            }
        }

        private void Schwärmer_Zu_ValueChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                Calculate_New_Values();
            }
        }

        private void Salve_Zu_ValueChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                Calculate_New_Values();
            }
        }

        private void Segment_Zu_ValueChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                Calculate_New_Values();
            }
        }

        private void Tsunami_Zu_ValueChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                Calculate_New_Values();
            }
        }

        private void Zünder_Zu_ValueChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                Calculate_New_Values();
            }
        }

        private void Zerstörer_Zu_ValueChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                Calculate_New_Values();
            }
        }

        private void Zyklon_Zu_ValueChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                Calculate_New_Values();
            }
        }

        private void Foreshadow_Zu_ValueChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                Calculate_New_Values();
            }
        }

        private void Phantom_Zu_ValueChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                Calculate_New_Values();
            }
        }

        private void Meltdown_Zu_ValueChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                Calculate_New_Values();
            }
        }

        private void KraftfeldProjektor_Zu_ValueChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                Calculate_New_Values();
            }
        }

        private void Doppelgeschütz_Munition_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                Calculate_New_Values();
            }
        }

        private void Luftgeschütz_Munition_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                Calculate_New_Values();
            }
        }

        private void Scatter_Munition_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                Calculate_New_Values();
            }
        }

        private void Hail_Munition_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                Calculate_New_Values();
            }
        }

        private void Welle_Munition_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                Calculate_New_Values();
            }
        }

        private void Schwärmer_Munition_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                Calculate_New_Values();
            }
        }

        private void Salve_Munition_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                Calculate_New_Values();
            }
        }

        private void Tsunami_Munition_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                Calculate_New_Values();
            }
        }

        private void Zünder_Munition_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                Calculate_New_Values();
            }
        }

        private void Zerstörer_Munition_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                Calculate_New_Values();
            }
        }

        private void Zyklon_Munition_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                Calculate_New_Values();
            }
        }

        private void Phantom_Munition_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                Calculate_New_Values();
            }
        }

        private void KraftfeldProjektor_Versterkung_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                Calculate_New_Values();
            }
        }

        private void Doppelgeschütz_Kühlung_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                Calculate_New_Values();
            }
        }

        private void Luftgeschütz_Kühlung_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                Calculate_New_Values();
            }
        }

        private void Scatter_Kühlung_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                Calculate_New_Values();
            }
        }

        private void Hail_Kühlung_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                Calculate_New_Values();
            }
        }

        private void Lancer_Kühlung_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                Calculate_New_Values();
            }
        }

        private void Arcus_Kühlung_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                Calculate_New_Values();
            }
        }

        private void Schwärmer_Kühlung_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                Calculate_New_Values();
            }
        }

        private void Salve_Kühlung_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                Calculate_New_Values();
            }
        }

        private void Zünder_Kühlung_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                Calculate_New_Values();
            }
        }

        private void Zerstörer_Kühlung_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                Calculate_New_Values();
            }
        }

        private void Zyklon_Kühlung_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                Calculate_New_Values();
            }
        }

        private void Foreshadow_Kühlung_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                Calculate_New_Values();
            }
        }

        private void Phantom_Kühlung_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                Calculate_New_Values();
            }
        }

        private void Meltdown_Kühlung_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                Calculate_New_Values();
            }
        }

        private void KraftfeldProjektor_Kühlung_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                Calculate_New_Values();
            }
        }

        //Truppen Produktion
        private void Bodenfabrik_Zu_ValueChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                Calculate_New_Values();
            }
        }

        private void Luftfabrik_Zu_ValueChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                Calculate_New_Values();
            }
        }

        private void Wasserfabrik_Zu_ValueChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                Calculate_New_Values();
            }
        }

        private void HinzufügenderRekonstrukeur_Zu_ValueChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                Calculate_New_Values();
            }
        }

        private void MultiplikativerRekonstrukeur_Zu_ValueChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                Calculate_New_Values();
            }
        }

        private void ExponenziellerRekonstrukeur_Zu_ValueChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                Calculate_New_Values();
            }
        }

        private void TretrativerRekonstrukeur_Zu_ValueChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                Calculate_New_Values();
            }
        }

        private void Reparaturpunkt_Zu_ValueChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                Calculate_New_Values();
            }
        }

        private void Truppen_Per_Sec_ValueChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                Calculate_New_Values();
            }
        }

        //Truppen Wasser
        private void Risso_Zu_ValueChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                Calculate_New_Values();
            }
        }

        private void Minke_Zu_ValueChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                Calculate_New_Values();
            }
        }

        private void Bryde_Zu_ValueChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                Calculate_New_Values();
            }
        }

        private void Sei_Zu_ValueChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                Calculate_New_Values();
            }
        }

        private void Omura_Zu_ValueChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                Calculate_New_Values();
            }
        }

        private void Retusa_Zu_ValueChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                Calculate_New_Values();
            }
        }

        private void Oxynoe_Zu_ValueChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                Calculate_New_Values();
            }
        }

        private void Cyerce_Zu_ValueChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                Calculate_New_Values();
            }
        }

        private void Aegires_Zu_ValueChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                Calculate_New_Values();
            }
        }

        private void Navanax_Zu_ValueChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                Calculate_New_Values();
            }
        }

        //Truppen Luft
        private void Flare_Zu_ValueChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                Calculate_New_Values();
            }
        }

        private void Horizont_Zu_ValueChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                Calculate_New_Values();
            }
        }

        private void Zenit_Zu_ValueChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                Calculate_New_Values();
            }
        }

        private void Antumbra_Zu_ValueChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                Calculate_New_Values();
            }
        }

        private void Eclipse_Zu_ValueChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                Calculate_New_Values();
            }
        }

        private void Mono_Zu_ValueChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                Calculate_New_Values();
            }
        }

        private void Poly_Zu_ValueChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                Calculate_New_Values();
            }
        }

        private void Mega_Zu_ValueChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                Calculate_New_Values();
            }
        }

        private void Quad_Zu_ValueChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                Calculate_New_Values();
            }
        }

        private void Okt_Zu_ValueChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                Calculate_New_Values();
            }
        }

        //Truppen Land
        private void Dagger_Zu_ValueChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                Calculate_New_Values();
            }
        }

        private void Mace_Zu_ValueChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                Calculate_New_Values();
            }
        }

        private void Fortress_Zu_ValueChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                Calculate_New_Values();
            }
        }

        private void Scepter_Zu_ValueChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                Calculate_New_Values();
            }
        }

        private void Reign_Zu_ValueChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                Calculate_New_Values();
            }
        }

        private void Nova_Zu_ValueChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                Calculate_New_Values();
            }
        }

        private void Pulsar_Zu_ValueChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                Calculate_New_Values();
            }
        }

        private void Quasar_Zu_ValueChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                Calculate_New_Values();
            }
        }

        private void Vela_Zu_ValueChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                Calculate_New_Values();
            }
        }

        private void Korvus_Zu_ValueChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                Calculate_New_Values();
            }
        }

        private void Crawler_Zu_ValueChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                Calculate_New_Values();
            }
        }

        private void Atrax_Zu_ValueChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                Calculate_New_Values();
            }
        }

        private void Spirokt_Zu_ValueChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                Calculate_New_Values();
            }
        }

        private void Arkyid_Zu_ValueChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                Calculate_New_Values();
            }
        }

        private void Toxopid_Zu_ValueChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                Calculate_New_Values();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Reset_All();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                button2.Enabled = true;
            }
            else
            {
                button2.Enabled = false;
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Bohrer_Div_ValueChanged(0);
            Pumpen_Div_ValueChanged(0);
            Generatoren_Div_ValueChanged(0);
            Rohstoffproduktion_Ver_SelectedIndexChanged(0);
            Calculate_New_Values();
        }

        private void Bohrer_Div_ValueChanged(short a)
        {
            //Bohrer
            double BM_OW_Div = Convert.ToDouble(MBohrer_OW_Div.Value),
                   BM_MW_Div = Convert.ToDouble(MBohrer_MW_Div.Value),
                   BP_OW_Div = Convert.ToDouble(PBohrer_OW_Div.Value),
                   BP_MW_Div = Convert.ToDouble(PBohrer_MW_Div.Value),
                   BL_OW_Div = Convert.ToDouble(LBohrer_OW_Div.Value),
                   BL_MW_Div = Convert.ToDouble(LBohrer_MW_Div.Value),
                   BS_OW_Div = Convert.ToDouble(SBohrer_OW_Div.Value),
                   BS_MW_Div = Convert.ToDouble(SBohrer_MW_Div.Value),
                   Rest, Prozente;

            if (B_count == 0)
            {
                Error_s = "";
                if ((BM_OW_Div + BM_MW_Div + BP_OW_Div + BP_MW_Div + BL_OW_Div + BL_MW_Div + BS_OW_Div + BS_MW_Div) < 0.0001)
                {
                    Error_s = "Because the sum of the drill distribution is incorect,\n" +
                        "it will be reseted\nthe drill distribution will be adjusted";
                    if (BM_OW_Div != 0)
                    {
                        BM_OW_Div = 0;
                        B_count++;
                    }
                    if (BM_MW_Div != 0)
                    {
                        BM_MW_Div = 0;
                        B_count++;
                    }
                    if (BP_OW_Div != 0)
                    {
                        BP_OW_Div = 0;
                        B_count++;
                    }
                    if (BP_MW_Div != 0)
                    {
                        BP_MW_Div = 0;
                        B_count++;
                    }
                    if (BL_OW_Div != 0)
                    {
                        BL_OW_Div = 0;
                        B_count++;
                    }
                    if (BL_MW_Div != 0)
                    {
                        BL_MW_Div = 0;
                        B_count++;
                    }
                    if (BS_OW_Div != 0)
                    {
                        BS_OW_Div = 0;
                        B_count++;
                    }
                    if (BS_MW_Div != 100)
                    {
                        BS_MW_Div = 100;
                        B_count++;
                    }
                    a = 0;

                    //Massege
                    // Initializes the variables to pass to the MessageBox.Show method.
                    string message = Error_s;
                    string caption = "Error Detected in Input";
                    MessageBoxButtons buttons = MessageBoxButtons.OK;

                    // Displays the MessageBox.
                    MessageBox.Show(message, caption, buttons);
                }

                B_count = Convert.ToUInt32((BM_OW_Div > 0) ? 1 : 0) +
                          Convert.ToUInt32((BM_MW_Div > 0) ? 1 : 0) +
                          Convert.ToUInt32((BP_OW_Div > 0) ? 1 : 0) +
                          Convert.ToUInt32((BP_MW_Div > 0) ? 1 : 0) +
                          Convert.ToUInt32((BL_OW_Div > 0) ? 1 : 0) +
                          Convert.ToUInt32((BL_MW_Div > 0) ? 1 : 0) +
                          Convert.ToUInt32((BS_OW_Div > 0) ? 1 : 0) +
                          Convert.ToUInt32((BS_MW_Div > 0) ? 1 : 0)
                          - 1; ;
                switch (a)
                {
                    case 1:
                        Rest = 100 - BM_OW_Div;
                        Prozente = BM_MW_Div + BP_OW_Div + BP_MW_Div + BL_OW_Div +
                            BL_MW_Div + BS_OW_Div + BS_MW_Div;
                        break;
                    case 2:
                        Rest = 100 - BM_MW_Div;
                        Prozente = BM_OW_Div + BP_OW_Div + BP_MW_Div + BL_OW_Div +
                            BL_MW_Div + BS_OW_Div + BS_MW_Div;
                        break;
                    case 3:
                        Rest = 100 - BP_OW_Div;
                        Prozente = BM_OW_Div + BM_MW_Div + BP_MW_Div + BL_OW_Div +
                            BL_MW_Div + BS_OW_Div + BS_MW_Div;
                        break;
                    case 4:
                        Rest = 100 - BP_MW_Div;
                        Prozente = BM_OW_Div + BM_MW_Div + BP_OW_Div + BL_OW_Div +
                            BL_MW_Div + BS_OW_Div + BS_MW_Div;
                        break;
                    case 5:
                        Rest = 100 - BL_OW_Div;
                        Prozente = BM_OW_Div + BM_MW_Div + BP_OW_Div + BP_MW_Div +
                            BL_MW_Div + BS_OW_Div + BS_MW_Div;
                        break;
                    case 6:
                        Rest = 100 - BL_MW_Div;
                        Prozente = BM_OW_Div + BM_MW_Div + BP_OW_Div + BP_MW_Div +
                            BL_OW_Div + BS_OW_Div + BS_MW_Div;
                        break;
                    case 7:
                        Rest = 100 - BS_OW_Div;
                        Prozente = BM_OW_Div + BM_MW_Div + BP_OW_Div + BP_MW_Div +
                            BL_OW_Div + BL_MW_Div + BS_MW_Div;
                        break;
                    case 8:
                        Rest = 100 - BS_MW_Div;
                        Prozente = BM_OW_Div + BM_MW_Div + BP_OW_Div + BP_MW_Div +
                            BL_OW_Div + BL_MW_Div + BS_OW_Div;
                        break;
                    default:
                        Rest = 100;
                        Prozente = BM_OW_Div + BM_MW_Div + BP_OW_Div + BP_MW_Div +
                            BL_OW_Div + BL_MW_Div + BS_OW_Div + BS_MW_Div;
                        if (Prozente == 0)
                        {
                            Prozente = 100;
                        }
                        break;
                }

                if ((Rest + Prozente) < 100)
                {
                    Prozente = 100 - Rest;
                }

                if (a != 1)
                {
                    MBohrer_OW_Div.Value = Convert.ToDecimal((BM_OW_Div / Prozente) * Rest);
                }
                if (a != 2)
                {
                    MBohrer_MW_Div.Value = Convert.ToDecimal((BM_MW_Div / Prozente) * Rest);
                }
                if (a != 3)
                {
                    PBohrer_OW_Div.Value = Convert.ToDecimal((BP_OW_Div / Prozente) * Rest);
                }
                if (a != 4)
                {
                    PBohrer_MW_Div.Value = Convert.ToDecimal((BP_MW_Div / Prozente) * Rest);
                }
                if (a != 5)
                {
                    LBohrer_OW_Div.Value = Convert.ToDecimal((BL_OW_Div / Prozente) * Rest);
                }
                if (a != 6)
                {
                    LBohrer_MW_Div.Value = Convert.ToDecimal((BL_MW_Div / Prozente) * Rest);
                }
                if (a != 7)
                {
                    SBohrer_OW_Div.Value = Convert.ToDecimal((BS_OW_Div / Prozente) * Rest);
                }
                if (a != 8)
                {
                    SBohrer_MW_Div.Value = Convert.ToDecimal((BS_MW_Div / Prozente) * Rest);
                }

            }
            else
            {
                B_count--;
            }


        }

        private void Pumpen_Div_ValueChanged(short a)
        {
            if (Wasser_Extraktor_Div.ReadOnly == true)
            {
                Wasser_Extraktor_Div.Value = 0;
            }

            //Pumpen
            double MP_Div = Convert.ToDouble(MPumpe_Div.Value),
                   RP_Div = Convert.ToDouble(RPumpe_Div.Value),
                   TP_Div = Convert.ToDouble(TPumpe_Div.Value),
                   WE_Div = Convert.ToDouble(Wasser_Extraktor_Div.Value),
                   Rest, Prozente;

            if (P_count == 0)
            {
                Error_s = "";
                if ((MP_Div + RP_Div + TP_Div + WE_Div) < 0.0001)
                {
                    Error_s = "Because the sum of the pumps distribution is incorect,\n" +
                    "it will be reseted\nthe pumps distribution will be adjusted";
                    if (MP_Div != 0)
                    {
                        MP_Div = 0;
                        P_count++;
                    }
                    if (RP_Div != 0)
                    {
                        RP_Div = 0;
                        P_count++;
                    }
                    if (WE_Div != 0)
                    {
                        WE_Div = 0;
                        P_count++;
                    }
                    if (TP_Div != 100)
                    {
                        TP_Div = 100;
                        P_count++;
                    }
                    a = 0;

                    //Massege
                    // Initializes the variables to pass to the MessageBox.Show method.
                    string message = Error_s;
                    string caption = "Error Detected in Input";
                    MessageBoxButtons buttons = MessageBoxButtons.OK;

                    // Displays the MessageBox.
                    MessageBox.Show(message, caption, buttons);
                }

                P_count = Convert.ToUInt32((MP_Div > 0) ? 1 : 0) +
                          Convert.ToUInt32((RP_Div > 0) ? 1 : 0) +
                          Convert.ToUInt32((TP_Div > 0) ? 1 : 0) +
                          Convert.ToUInt32((WE_Div > 0) ? 1 : 0)
                          - 1;
                switch (a)
                {
                    case 1:
                        Rest = 100 - MP_Div;
                        Prozente = WE_Div + RP_Div + TP_Div;
                        break;
                    case 2:
                        Rest = 100 - RP_Div;
                        Prozente = WE_Div + MP_Div + TP_Div;
                        break;
                    case 3:
                        Rest = 100 - TP_Div;
                        Prozente = WE_Div + MP_Div + RP_Div;
                        break;
                    case 4:
                        Rest = 100 - WE_Div;
                        Prozente = MP_Div + RP_Div + TP_Div;
                        break;
                    default:
                        Rest = 100;
                        Prozente = MP_Div + RP_Div + TP_Div + WE_Div;
                        if (Prozente == 0)
                        {
                            Prozente = 100;
                        }
                        break;
                }

                if ((Rest + Prozente) < 100)
                {
                    Prozente = 100 - Rest;
                }

                if (a != 1)
                {
                    MPumpe_Div.Value = Convert.ToDecimal((MP_Div / Prozente) * Rest);
                }
                if (a != 2)
                {
                    RPumpe_Div.Value = Convert.ToDecimal((RP_Div / Prozente) * Rest);
                }
                if (a != 3)
                {
                    TPumpe_Div.Value = Convert.ToDecimal((TP_Div / Prozente) * Rest);
                }
                if (a != 4)
                {
                    Wasser_Extraktor_Div.Value = Convert.ToDecimal((WE_Div / Prozente) * Rest);
                }

            }
            else
            {
                P_count--;
            }
        }

        private void Wasser_Extraktor_Div_ValueChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                Pumpen_Div_ValueChanged(4);
                Calculate_New_Values();
            }
        }

        private void Generatoren_Div_ValueChanged(short a)
        {
            if (Stromberechnung_off)
            {
                return;
            }
            //Generatoren
            double VeG_Div = Convert.ToDouble(Verbrennungsgenerator_Div.Value),
                   ThG_Div = Convert.ToDouble(ThermischerGenerator_Div.Value),
                   TuG_Div = Convert.ToDouble(Turbinengenerator_Div.Value),
                   DiG_Div = Convert.ToDouble(Differenzialgenerator_Div.Value),
                   RTG_Div = Convert.ToDouble(RTGGenerator_Div.Value),
                   SoG_Div = Convert.ToDouble(Solarpanel_Div.Value),
                   GSG_Div = Convert.ToDouble(GroßesSolarpanel_Div.Value),
                   ThR_Div = Convert.ToDouble(ThoriumReaktor_Div.Value),
                   ScR_Div = Convert.ToDouble(Schlaggenerator_Div.Value),
                   Rest, Prozente;

            if (G_count == 0)
            {
                Error_s = "";
                if ((VeG_Div + ThG_Div + TuG_Div + DiG_Div + RTG_Div + SoG_Div + GSG_Div + ThR_Div + ScR_Div) < 0.0001)
                {
                    Error_s = "Because the sum of the generator distribution is incorect,\n" +
                        "it will be reseted\nthe generator distribution will be adjusted";
                    if (VeG_Div != 0)
                    {
                        VeG_Div = 0;
                        G_count++;
                    }
                    if (ThG_Div != 0)
                    {
                        ThG_Div = 0;
                        G_count++;
                    }
                    if (TuG_Div != 0)
                    {
                        TuG_Div = 0;
                        G_count++;
                    }
                    if (DiG_Div != 0)
                    {
                        DiG_Div = 0;
                        G_count++;
                    }
                    if (RTG_Div != 0)
                    {
                        RTG_Div = 0;
                        G_count++;
                    }
                    if (SoG_Div != 0)
                    {
                        SoG_Div = 0;
                        G_count++;
                    }
                    if (GSG_Div != 0)
                    {
                        GSG_Div = 0;
                        G_count++;
                    }
                    if (ThR_Div != 0)
                    {
                        ThR_Div = 0;
                        G_count++;
                    }
                    if (ScR_Div != 100)
                    {
                        ScR_Div = 100;
                        G_count++;
                    }
                    a = 0;

                    //Massege
                    // Initializes the variables to pass to the MessageBox.Show method.
                    string message = Error_s;
                    string caption = "Error Detected in Input";
                    MessageBoxButtons buttons = MessageBoxButtons.OK;

                    // Displays the MessageBox.
                    MessageBox.Show(message, caption, buttons);
                }


                G_count = Convert.ToUInt32((VeG_Div > 0) ? 1 : 0) +
                          Convert.ToUInt32((ThG_Div > 0) ? 1 : 0) +
                          Convert.ToUInt32((TuG_Div > 0) ? 1 : 0) +
                          Convert.ToUInt32((DiG_Div > 0) ? 1 : 0) +
                          Convert.ToUInt32((RTG_Div > 0) ? 1 : 0) +
                          Convert.ToUInt32((SoG_Div > 0) ? 1 : 0) +
                          Convert.ToUInt32((GSG_Div > 0) ? 1 : 0) +
                          Convert.ToUInt32((ThR_Div > 0) ? 1 : 0) +
                          Convert.ToUInt32((ScR_Div > 0) ? 1 : 0)
                          - 1; ;
                switch (a)
                {
                    case 1:
                        Rest = 100 - VeG_Div;
                        Prozente = ThG_Div + TuG_Div + DiG_Div + RTG_Div + SoG_Div + GSG_Div + ThR_Div + ScR_Div;
                        break;
                    case 2:
                        Rest = 100 - ThG_Div;
                        Prozente = VeG_Div + TuG_Div + DiG_Div + RTG_Div + SoG_Div + GSG_Div + ThR_Div + ScR_Div;
                        break;
                    case 3:
                        Rest = 100 - TuG_Div;
                        Prozente = VeG_Div + ThG_Div + DiG_Div + RTG_Div + SoG_Div + GSG_Div + ThR_Div + ScR_Div;
                        break;
                    case 4:
                        Rest = 100 - DiG_Div;
                        Prozente = VeG_Div + ThG_Div + TuG_Div + RTG_Div + SoG_Div + GSG_Div + ThR_Div + ScR_Div;
                        break;
                    case 5:
                        Rest = 100 - RTG_Div;
                        Prozente = VeG_Div + ThG_Div + TuG_Div + DiG_Div + SoG_Div + GSG_Div + ThR_Div + ScR_Div;
                        break;
                    case 6:
                        Rest = 100 - SoG_Div;
                        Prozente = VeG_Div + ThG_Div + TuG_Div + DiG_Div + RTG_Div + GSG_Div + ThR_Div + ScR_Div;
                        break;
                    case 7:
                        Rest = 100 - GSG_Div;
                        Prozente = VeG_Div + ThG_Div + TuG_Div + DiG_Div + RTG_Div + SoG_Div + ThR_Div + ScR_Div;
                        break;
                    case 8:
                        Rest = 100 - ThR_Div;
                        Prozente = VeG_Div + ThG_Div + TuG_Div + DiG_Div + RTG_Div + SoG_Div + GSG_Div + ScR_Div;
                        break;
                    case 9:
                        Rest = 100 - ScR_Div;
                        Prozente = VeG_Div + ThG_Div + TuG_Div + DiG_Div + RTG_Div + SoG_Div + GSG_Div + ThR_Div;
                        break;
                    default:
                        Rest = 100;
                        Prozente = VeG_Div + ThG_Div + TuG_Div + DiG_Div + RTG_Div + SoG_Div + GSG_Div + ThR_Div + ScR_Div;
                        if (Prozente == 0)
                        {
                            Prozente = 100;
                        }
                        break;
                }

                if ((Rest + Prozente) < 100)
                {
                    Prozente = 100 - Rest;
                }

                if (a != 1)
                {
                    Verbrennungsgenerator_Div.Value = Convert.ToDecimal((VeG_Div / Prozente) * Rest);
                }
                if (a != 2)
                {
                    ThermischerGenerator_Div.Value = Convert.ToDecimal((ThG_Div / Prozente) * Rest);
                }
                if (a != 3)
                {
                    Turbinengenerator_Div.Value = Convert.ToDecimal((TuG_Div / Prozente) * Rest);
                }
                if (a != 4)
                {
                    Differenzialgenerator_Div.Value = Convert.ToDecimal((DiG_Div / Prozente) * Rest);
                }
                if (a != 5)
                {
                    RTGGenerator_Div.Value = Convert.ToDecimal((RTG_Div / Prozente) * Rest);
                }
                if (a != 6)
                {
                    Solarpanel_Div.Value = Convert.ToDecimal((SoG_Div / Prozente) * Rest);
                }
                if (a != 7)
                {
                    GroßesSolarpanel_Div.Value = Convert.ToDecimal((GSG_Div / Prozente) * Rest);
                }
                if (a != 8)
                {
                    ThoriumReaktor_Div.Value = Convert.ToDecimal((ThR_Div / Prozente) * Rest);
                }
                if (a != 9)
                {
                    Schlaggenerator_Div.Value = Convert.ToDecimal((ScR_Div / Prozente) * Rest);
                }

            }
            else
            {
                G_count--;
            }
        }

        private void Stromberechnung_on_off_CheckedChanged(object sender, EventArgs e)
        {
            Stromberechnung_off = Stromberechnung_on_off.Checked;
            if (!checkBox1.Checked)
            {
                Calculate_New_Values();
            }
        }
    }
}
