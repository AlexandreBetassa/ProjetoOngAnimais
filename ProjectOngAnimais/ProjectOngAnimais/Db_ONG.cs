﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32.SafeHandles;

namespace ProjectOngAnimais
{
    internal class Db_ONG
    {
        string conexao = "Data Source = DESKTOP-49RHHLK\\MSSQL;Initial Catalog=ong_adocao;Persist Security Info=True;User ID=sa;Password=834500";
        SqlConnection conn;

        public Db_ONG()
        {
            conn = new SqlConnection(conexao);
        }

        public void InsertTablePessoa(Pessoa pessoa)
        {
            int row;
            try
            {
                conn.Open();
                string sql = $"insert into dbo.pessoa (cpf, nome, sexo, telefone, endereco, dataNascimento, status) values ('{pessoa.Cpf}' , " +
                    $"'{pessoa.Nome}', '{pessoa.Sexo}', '{pessoa.Telefone}', '{pessoa.End}', '{pessoa.DataNascimento}', '{pessoa.Status}');";
                SqlCommand cmd = new SqlCommand(sql, conn);
                row = cmd.ExecuteNonQuery();
                Console.WriteLine(row);
                Console.ReadKey();
            }
            catch (SqlException e)
            {
                switch (e.Number)
                {
                    case 2627:
                        Console.WriteLine("Já existe um usuário cadastrado com esse CPF!!!");
                        break;
                    case 2628:
                        Console.WriteLine("Valor de cadeia de caracteres acima do permitido!!!");
                        break;
                    default:
                        break;
                }

                Console.WriteLine(e);
                Utils.Pause();
            }
            conn.Close();
        }

        public void SelectTablePessoa(string sql)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            using (SqlDataReader r = cmd.ExecuteReader())
            {
                while (r.Read())
                {
                    Console.WriteLine($"Nome: {r.GetString(1)}");
                    Console.WriteLine($"CPF: {r.GetString(0)}");
                    Console.WriteLine($"Sexo: {r.GetString(2)}");
                    Console.WriteLine($"Tel: {r.GetString(3)}");
                    Console.WriteLine($"Endereço: {r.GetString(4)}");
                    Console.WriteLine($"Data de nascimento: {r.GetDateTime(5).ToShortDateString()}");
                    Console.WriteLine();
                }
            }
            conn.Close();
        }

        public void DeleteDataPessoa(String cpf)
        {
            conn.Open();
            string sql = $"update dbo.pessoa set status = 'I' where cpf = '{cpf}'";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public void UpdateTable(String sql)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public void InsertTablePet(Pet pet)
        {
            conn.Open();
            string sql = $"insert into dbo.pet (familiaPet, racaPet, sexoPet, nomePet, disponivel) " +
                $"values ('{pet.TipoPet}', '{pet.Raca}', '{pet.SexoPet}', '{pet.NomePet}', '{pet.PetDisponivel}');";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public void SelectTablePet(string sql)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);

            using (SqlDataReader r = cmd.ExecuteReader())
            {
                while (r.Read())
                {
                    Console.WriteLine($"Chip de Identificação: {r.GetInt32(0)}");
                    Console.WriteLine($"Familia: {r.GetString(1)}");
                    Console.WriteLine($"Raça: {r.GetString(2)}");
                    Console.WriteLine($"Sexo: {r.GetString(3)}");
                    Console.WriteLine($"Nome: {r.GetString(4)}\n");
                }
            }
            conn.Close();
        }

        public void InsertRegAdocao(string sql)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }
    }
}
