﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RelojCliente.Negocios;
using RelojCliente.Entidad;
using System.Data;
using System.Data.SqlClient;


namespace RelojCliente.Negocios
{
    class ClsNcliente
    {
        internal DataTable MtdListarClientes()
        {
            ClsConexionSQL conn = new ClsConexionSQL();
            DataTable result = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter();
            SqlCommand command = new SqlCommand();
            command.Connection = conn.Conectar();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "USP_S_ListarClientes";
            command.ExecuteNonQuery();
            adapter.SelectCommand = command;
            adapter.Fill(result);
            command.Connection = conn.Desconectar();

            return result;
        }

        internal object MtdFiltrarCliente(string filtro)
        {
            ClsConexionSQL conn = new ClsConexionSQL();
            DataTable result = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter();
            SqlCommand command = new SqlCommand();
            command.Connection = conn.Conectar();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "USP_S_FiltrarCliente";
            command.Parameters.Add(new SqlParameter("fil", SqlDbType.VarChar));
            command.Parameters["fil"].Value = filtro;
            command.ExecuteNonQuery();
            adapter.SelectCommand = command;
            adapter.Fill(result);
            command.Connection = conn.Desconectar();

            return result;
        }

        internal DataTable MtdBusquedaCliente(string dni)
        {
            ClsConexionSQL conn = new ClsConexionSQL();
            DataTable result = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter();
            SqlCommand command = new SqlCommand();
            command.Connection = conn.Conectar();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "USP_S_BusquedaCliente";
            command.Parameters.Add(new SqlParameter("d", SqlDbType.VarChar));
            command.Parameters["d"].Value = dni;
            command.ExecuteNonQuery();
            adapter.SelectCommand = command;
            adapter.Fill(result);
            command.Connection = conn.Desconectar();

            return result;
        }

        internal bool MtdGuardarCliente(ClsEcliente e)
        {
            try
            {
                ClsConexionSQL objConexion = new ClsConexionSQL();
                SqlCommand command = new SqlCommand();
                SqlDataAdapter adapter = new SqlDataAdapter();
                command.Connection = objConexion.Conectar();
                command.CommandText = "USP_I_AgregarCliente";
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("d", SqlDbType.VarChar));
                command.Parameters.Add(new SqlParameter("nom", SqlDbType.VarChar));
                command.Parameters.Add(new SqlParameter("ape", SqlDbType.VarChar));
                command.Parameters.Add(new SqlParameter("cor", SqlDbType.VarChar));
                command.Parameters.Add(new SqlParameter("tel", SqlDbType.VarChar));
                command.Parameters.Add(new SqlParameter("est", SqlDbType.VarChar));
                //command.Parameters.Add(new SqlParameter("idd", SqlDbType.VarChar));
                command.Parameters["d"].Value = e.Dni;
                command.Parameters["nom"].Value = e.Nombres;
                command.Parameters["ape"].Value = e.Apellidos;
                command.Parameters["cor"].Value = e.Correo;
                command.Parameters["tel"].Value = e.Telefono;
                command.Parameters["est"].Value = e.Estado;
                //command.Parameters["idd"].Value = e.IdDispositivo;
                command.ExecuteNonQuery();
                command.Connection = objConexion.Desconectar();

                return true;
            }
            catch (Exception ex)
            {
                return false;
                throw ex;
            }
        }

        internal bool MtdModificarCliente(ClsEcliente e)
        {
            try
            {
                ClsConexionSQL objConexion = new ClsConexionSQL();
                SqlCommand command = new SqlCommand();
                SqlDataAdapter adapter = new SqlDataAdapter();
                command.Connection = objConexion.Conectar();
                command.CommandText = "USP_U_ModificarCliente";
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("d", SqlDbType.VarChar));
                command.Parameters.Add(new SqlParameter("nom", SqlDbType.VarChar));
                command.Parameters.Add(new SqlParameter("ape", SqlDbType.VarChar));
                command.Parameters.Add(new SqlParameter("cor", SqlDbType.VarChar));
                command.Parameters.Add(new SqlParameter("tel", SqlDbType.VarChar));
                command.Parameters.Add(new SqlParameter("est", SqlDbType.VarChar));
                //command.Parameters.Add(new SqlParameter("idd", SqlDbType.VarChar));
                command.Parameters["d"].Value = e.Dni;
                command.Parameters["nom"].Value = e.Nombres;
                command.Parameters["ape"].Value = e.Apellidos;
                command.Parameters["cor"].Value = e.Correo;
                command.Parameters["tel"].Value = e.Telefono;
                command.Parameters["est"].Value = e.Estado;
                //command.Parameters["idd"].Value = e.IdDispositivo;
                command.ExecuteNonQuery();
                command.Connection = objConexion.Desconectar();

                return true;
            }
            catch (Exception ex)
            {
                return false;
                throw ex;
            }
        }
    }
}
