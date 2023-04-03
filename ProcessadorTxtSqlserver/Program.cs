using System;
using System.IO;
using System.Data.SqlClient;
using System.Globalization;
using System.Runtime.Serialization;


string connectionString = "Server=192.168.0.100\\sqlexpress02;Database=AluraCurso;User Id=su;Password=230917;";

// Defina a pasta a ser monitorada
string pastaMonitorada = @"C:\temp\monitorada";
string pastaBackup = @"C:\temp\monitorada\backup";


FileSystemWatcher watcher = new FileSystemWatcher(pastaMonitorada,
    "*.txt");



    watcher.Created += (sender, e) =>
    {
        if (File.Exists(e.FullPath))
        {
            Console.WriteLine("Arquivo criado: " + e.FullPath);

          
            using (var arquivo = new StreamReader(e.FullPath))
            {
                using (var conexao = new SqlConnection(connectionString))
                {
                    conexao.Open();

                    try
                    {

                        while (!arquivo.EndOfStream)
                        {
                            string[] linha = arquivo.ReadLine().Split(';');
                            string codigo = linha[0];
                            string descritor = linha[1];
                            string sabor = linha[2];
                            string tamanho = linha[3];
                            string embalagem = linha[4];
                            string preco = linha[5];

                            string comandoInserir = "INSERT INTO produtos (codigo, descritor, sabor,tamanho,embalagem,preco_lista) VALUES (@cod, @desc, @sab,@tam,@emb,@prec)";
                            SqlCommand comando = new SqlCommand(comandoInserir, conexao);
                            comando.Parameters.AddWithValue("@cod", codigo);
                            comando.Parameters.AddWithValue("@desc", descritor);
                            comando.Parameters.AddWithValue("@sab", sabor);
                            comando.Parameters.AddWithValue("@tam", tamanho);
                            comando.Parameters.AddWithValue("@emb", embalagem);
                            comando.Parameters.AddWithValue("@prec", preco);


                            int registrosAfetados = comando.ExecuteNonQuery();
                            Console.WriteLine("Registros afetados: " + registrosAfetados);



                            string nomeArquivoBackup = Path.Combine(pastaBackup, e.Name);
                            File.Copy(e.FullPath, nomeArquivoBackup);


                            //arquivo.Close();
                            // Apague o arquivo original

                            Console.WriteLine("Arquivo movido para backup: " + nomeArquivoBackup);
                        }

                    }
                    catch (Exception)
                    {

                        throw;
                    }
                    finally
                    {
                        arquivo.Close();
                        File.Delete(e.FullPath);
                        conexao.Close();
                    }
                   

                }
            }
        }
    };



watcher.EnableRaisingEvents = true;

Console.WriteLine("Pressione qualquer tecla para sair...");
Console.ReadKey();
