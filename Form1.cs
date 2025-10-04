using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Windows.Forms;

namespace KelimeDefteri
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public class Entry
        {
            [JsonPropertyName("id")]
            public long Id { get; set; }
            [JsonPropertyName("collectionId")]
            public long CollectionId { get; set; }
            [JsonPropertyName("word")]
            public string Word { get; set; }
            [JsonPropertyName("meaning")]
            public string Meaning { get; set; }
            [JsonPropertyName("note")]
            public string Note { get; set; }
            [JsonPropertyName("color")]
            public int Color { get; set; }
            [JsonPropertyName("type")]
            public int Type { get; set; }
            [JsonPropertyName("example")]
            public string Example { get; set; }
            [JsonPropertyName("synonym")]
            public string Synonym { get; set; }
            [JsonPropertyName("antonym")]
            public string Antonym { get; set; }
            [JsonPropertyName("hidden")]
            public bool Hidden { get; set; }
            [JsonPropertyName("stared")]
            public bool Stared { get; set; }
            [JsonPropertyName("score")]
            public int Score { get; set; }
            [JsonPropertyName("lastAnswer")]
            public long LastAnswer { get; set; }
            [JsonPropertyName("lastTime")]
            public long LastTime { get; set; }
        }

        public class Collection
        {
            [JsonPropertyName("id")]
            public long Id { get; set; }
            [JsonPropertyName("name")]
            public string Name { get; set; }
            [JsonPropertyName("color")]
            public int Color { get; set; }
            [JsonPropertyName("icon")]
            public string Icon { get; set; }
            [JsonPropertyName("hideIcon")]
            public bool HideIcon { get; set; }
            [JsonPropertyName("wordLanguage")]
            public string WordLanguage { get; set; }
            [JsonPropertyName("meaningLanguage")]
            public string MeaningLanguage { get; set; }
            [JsonPropertyName("archived")]
            public bool Archived { get; set; }
        }

        public class KelimeDefteri
        {
            [JsonPropertyName("backupTime")]
            public long BackupTime { get; set; }
            [JsonPropertyName("entries")]
            public List<Entry> Entries { get; set; }
            [JsonPropertyName("collections")]
            public List<Collection> Collections { get; set; }
            [JsonPropertyName("logs")]
            public List<object> Logs { get; set; }
        }

        private void btnCreateJson_Click(object sender, EventArgs e)
        {
            lblStatus.Text = "";
            var entries = new List<Entry>();
            long timestamp = DateTimeOffset.Now.ToUnixTimeMilliseconds();
            string collectionName = txtCollectionName.Text.Trim();
            if (string.IsNullOrWhiteSpace(collectionName))
            {
                lblStatus.Text = "Hata: Koleksiyon ismi boþ olamaz!";
                return;
            }

            string[] lines = txtInput.Text.Split(new[] { "\r\n", "\n" }, StringSplitOptions.None);
            int idCounter = 0;
            foreach (string line in lines)
            {
                if (string.IsNullOrWhiteSpace(line))
                    continue;

                var parts = line.Split('=', StringSplitOptions.TrimEntries);
                if (parts.Length != 2 || string.IsNullOrWhiteSpace(parts[0]) || string.IsNullOrWhiteSpace(parts[1]))
                {
                    lblStatus.Text += $"Hatalý satýr atlandý: '{line}'\n";
                    continue;
                }

                var entry = new Entry
                {
                    Id = timestamp + idCounter,
                    CollectionId = timestamp,
                    Word = parts[0],
                    Meaning = parts[1],
                    Note = "",
                    Color = 0,
                    Type = 0,
                    Example = "",
                    Synonym = "",
                    Antonym = "",
                    Hidden = false,
                    Stared = false,
                    Score = 0,
                    LastAnswer = 0,
                    LastTime = 0
                };

                entries.Add(entry);
                idCounter++;
            }

            if (entries.Count == 0)
            {
                lblStatus.Text = "Hata: Geçerli kelime girilmedi.";
                return;
            }

            var collection = new Collection
            {
                Id = timestamp,
                Name = collectionName,
                Color = 0,
                Icon = "eng",
                HideIcon = false,
                WordLanguage = "en",
                MeaningLanguage = "tr",
                Archived = false
            };

            var kelimeDefteri = new KelimeDefteri
            {
                BackupTime = timestamp,
                Entries = entries,
                Collections = new List<Collection> { collection },
                Logs = new List<object>()
            };

            var options = new JsonSerializerOptions
            {
                WriteIndented = true,
                Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
            };
            string json = JsonSerializer.Serialize(kelimeDefteri, options);
            string fileName = $"{collectionName}.json";
            File.WriteAllText(fileName, json);
            lblStatus.Text = $"JSON dosyasý '{fileName}' olarak kaydedildi.";
        }

        private void btnReadTxt_Click(object sender, EventArgs e)
        {
            lblStatus.Text = "";
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
                openFileDialog.Title = "TXT Dosyasý Seç";
                openFileDialog.InitialDirectory = Application.StartupPath;

                if (openFileDialog.ShowDialog() != DialogResult.OK)
                {
                    lblStatus.Text = "Hata: Dosya seçilmedi!";
                    return;
                }

                string filePath = openFileDialog.FileName;
                var entries = new List<Entry>();
                long timestamp = DateTimeOffset.Now.ToUnixTimeMilliseconds();
                string collectionName = txtCollectionName.Text.Trim();
                if (string.IsNullOrWhiteSpace(collectionName))
                {
                    lblStatus.Text = "Hata: Koleksiyon ismi boþ olamaz!";
                    return;
                }

                try
                {
                    string[] lines = File.ReadAllLines(filePath);
                    int idCounter = 0;
                    foreach (string line in lines)
                    {
                        if (string.IsNullOrWhiteSpace(line))
                            continue;

                        var parts = line.Split('=', StringSplitOptions.TrimEntries);
                        if (parts.Length != 2 || string.IsNullOrWhiteSpace(parts[0]) || string.IsNullOrWhiteSpace(parts[1]))
                        {
                            lblStatus.Text += $"Hatalý satýr atlandý: '{line}'\n";
                            continue;
                        }

                        var entry = new Entry
                        {
                            Id = timestamp + idCounter,
                            CollectionId = timestamp,
                            Word = parts[0],
                            Meaning = parts[1],
                            Note = "",
                            Color = 0,
                            Type = 0,
                            Example = "",
                            Synonym = "",
                            Antonym = "",
                            Hidden = false,
                            Stared = false,
                            Score = 0,
                            LastAnswer = 0,
                            LastTime = 0
                        };

                        entries.Add(entry);
                        idCounter++;
                    }

                    if (entries.Count == 0)
                    {
                        lblStatus.Text = "Hata: TXT dosyasýnda geçerli kelime bulunamadý.";
                        return;
                    }

                    var collection = new Collection
                    {
                        Id = timestamp,
                        Name = collectionName,
                        Color = 0,
                        Icon = "eng",
                        HideIcon = false,
                        WordLanguage = "en",
                        MeaningLanguage = "tr",
                        Archived = false
                    };

                    var kelimeDefteri = new KelimeDefteri
                    {
                        BackupTime = timestamp,
                        Entries = entries,
                        Collections = new List<Collection> { collection },
                        Logs = new List<object>()
                    };

                    var options = new JsonSerializerOptions
                    {
                        WriteIndented = true,
                        Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
                    };
                    string json = JsonSerializer.Serialize(kelimeDefteri, options);
                    string fileName = $"{collectionName}.json";
                    File.WriteAllText(fileName, json);
                    lblStatus.Text = $"JSON dosyasý '{fileName}' olarak kaydedildi (TXT’den).";
                }
                catch (Exception ex)
                {
                    lblStatus.Text = $"Hata: TXT okunurken sorun oluþtu: {ex.Message}";
                }
            }
        }

        private void btnJsonToTxt_Click(object sender, EventArgs e)
        {
            lblStatus.Text = "";
            string txtContent = txtInput.Text.Trim();
            string collectionName = txtCollectionName.Text.Trim();
            if (string.IsNullOrWhiteSpace(txtContent))
            {
                lblStatus.Text = "Hata: Kelime listesi boþ!";
                return;
            }
            if (string.IsNullOrWhiteSpace(collectionName))
            {
                lblStatus.Text = "Hata: Koleksiyon ismi boþ olamaz!";
                return;
            }

            var txtLines = new List<string>();
            string[] lines = txtInput.Text.Split(new[] { "\r\n", "\n" }, StringSplitOptions.None);
            foreach (string line in lines)
            {
                if (string.IsNullOrWhiteSpace(line))
                    continue;

                var parts = line.Split('=', StringSplitOptions.TrimEntries);
                if (parts.Length != 2 || string.IsNullOrWhiteSpace(parts[0]) || string.IsNullOrWhiteSpace(parts[1]))
                {
                    lblStatus.Text += $"Hatalý satýr atlandý: '{line}'\n";
                    continue;
                }

                txtLines.Add($"{parts[0]} = {parts[1]}");
            }

            if (txtLines.Count == 0)
            {
                lblStatus.Text = "Hata: Geçerli kelime bulunamadý.";
                return;
            }

            try
            {
                string fileName = $"{collectionName}.txt";
                File.WriteAllLines(fileName, txtLines);
                lblStatus.Text = $"'{fileName}' dosyasý oluþturuldu.";
            }
            catch (Exception ex)
            {
                lblStatus.Text = $"Hata: TXT dosyasý yazýlýrken sorun oluþtu: {ex.Message}";
            }
        }

        private void btnLoadJson_Click(object sender, EventArgs e)
        {
            lblStatus.Text = "";
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "JSON Files (*.json)|*.json|All Files (*.*)|*.*";
                openFileDialog.Title = "JSON Dosyasý Seç";
                openFileDialog.InitialDirectory = Application.StartupPath;

                if (openFileDialog.ShowDialog() != DialogResult.OK)
                {
                    lblStatus.Text = "Hata: Dosya seçilmedi!";
                    return;
                }

                string jsonFilePath = openFileDialog.FileName;

                try
                {
                    string jsonContent = File.ReadAllText(jsonFilePath);
                    var options = new JsonSerializerOptions
                    {
                        PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                    };
                    var kelimeDefteri = JsonSerializer.Deserialize<KelimeDefteri>(jsonContent, options);

                    if (kelimeDefteri?.Entries == null || kelimeDefteri.Entries.Count == 0)
                    {
                        lblStatus.Text = "Hata: JSON dosyasýnda geçerli kelime bulunamadý.";
                        return;
                    }

                    var txtLines = new List<string>();
                    foreach (var entry in kelimeDefteri.Entries)
                    {
                        txtLines.Add($"{entry.Word} = {entry.Meaning}");
                    }

                    txtInput.Text = string.Join(Environment.NewLine, txtLines);
                    txtCollectionName.Text = kelimeDefteri.Collections[0].Name;
                    lblStatus.Text = $"JSON dosyasý '{Path.GetFileName(jsonFilePath)}' yüklendi ve kelimeler textbox’ta gösterildi.";
                }
                catch (Exception ex)
                {
                    lblStatus.Text = $"Hata: JSON okunurken sorun oluþtu: {ex.Message}";
                }
            }
        }
    }
}