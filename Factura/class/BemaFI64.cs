using System;

using System.Runtime.InteropServices;

namespace Factura.Fiscales

{

	public class BemaFI64
	{	

		private string validar_impresora(int iretorno)
		{
			string mensaje = "";
			mensaje = Analisa_iRetorno(iretorno);
			if (mensaje != "") return mensaje;
			mensaje = Analisa_RetornoImpresora();
			return mensaje;
		}
		public string cabecera_factura(string ruc, string cliente, string direccion)
        {
			string mensaje = "";
			int iretorno = 0;
			iretorno = Bematech_FI_AbrePuertaSerial();
			mensaje = this.validar_impresora(iretorno);
			if (mensaje != "") return mensaje;

			iretorno = BemaFI64.Bematech_FI_AbreComprobanteDeVentaEx(ruc, cliente, direccion);
			mensaje = this.validar_impresora(iretorno);
			if (mensaje != "") return mensaje;
			return mensaje;
		}
		public string detalle_factura(string codigo, string descripcion, string cantidad, int cuantosdecimales, string preciounitario)
		{
			string mensaje = "";
			int iretorno = 0;
			iretorno = Bematech_FI_VendeArticulo(codigo, descripcion, "FF", "I", cantidad, cuantosdecimales, preciounitario, "%", "0100");
			mensaje = this.validar_impresora(iretorno);
			if (mensaje != "") return mensaje;
			return mensaje;
		}
		public string footer_factura()
        {
			string mensaje = "";
			int iretorno = 0;
			iretorno = Bematech_FI_IniciaCierreCupon("A", "%", "0000");
			mensaje = this.validar_impresora(iretorno);
			if (mensaje != "") return mensaje;
			iretorno = Bematech_FI_EfectuaFormaPago("Efectivo", "5000,00");
			mensaje = this.validar_impresora(iretorno);
			if (mensaje != "") return mensaje;
			iretorno = Bematech_FI_CierraCupon("Tarjeta", "A", "%", "0000", "5000,00", "Vuelva Siempre!");
			mensaje = this.validar_impresora(iretorno);
			if (mensaje != "") return mensaje;
			iretorno = Bematech_FI_CierraPuertaSerial();
			mensaje = this.validar_impresora(iretorno);
			return mensaje;
		}
		public string ReporteZ()
		{
			string mensaje = "";
			int iretorno = 0;
			iretorno = Bematech_FI_AbrePuertaSerial();
			mensaje = this.validar_impresora(iretorno);
			if (mensaje != "") return mensaje;
			iretorno = Bematech_FI_ReduccionZ("", "");
			mensaje = this.validar_impresora(iretorno);
			if (mensaje != "") return mensaje;
			iretorno = Bematech_FI_CierraPuertaSerial();
			mensaje = this.validar_impresora(iretorno);
			return mensaje;
		}
		public string ReporteX()
		{
			string mensaje = "";
			int iretorno = 0;
			iretorno = Bematech_FI_AbrePuertaSerial();
			iretorno = Bematech_FI_LecturaX();
				mensaje = this.validar_impresora(iretorno);
				if (mensaje != "") return mensaje;
			iretorno = Bematech_FI_CierraPuertaSerial();
			mensaje = this.validar_impresora(iretorno);
			return mensaje;
		}
		/*
		private void mnuAnulaComprobante_Click(object sender, System.EventArgs e)
		{
			IRetorno = BemaFI64.Bematech_FI_AnulaCupon();					
			BemaFI64.Analisa_iRetorno(IRetorno);
			BemaFI64.Analisa_RetornoImpresora();
		}

		private void mnuDevolucionArticulo_Click(object sender, System.EventArgs e)
		{
			IRetorno = BemaFI64.Bematech_FI_DevolucionArticulo("123","Boligrafo","FF","I","15",3,"50,00","%","0000");
			BemaFI64.Analisa_iRetorno(IRetorno);
			BemaFI64.Analisa_RetornoImpresora();
		}

		private void mnuAbreNotaCredito_Click(object sender, System.EventArgs e)
		{
			IRetorno = BemaFI64.Bematech_FI_AbreNotaDeCredito("Fulano","123456789101112","123.456.789-10","01","01","06","09","37","56","123456","Gracias, Vuelva Siempre");
			BemaFI64.Analisa_iRetorno(IRetorno);
			BemaFI64.Analisa_RetornoImpresora();
		}

		private void mnuAnulaArticulo_Click(object sender, System.EventArgs e)
		{
			IRetorno = BemaFI64.Bematech_FI_AnulaArticuloAnterior();
			BemaFI64.Analisa_iRetorno(IRetorno);
			BemaFI64.Analisa_RetornoImpresora();
		}

		private void mnuAutenticacion_Click(object sender, System.EventArgs e)
		{
			IRetorno = BemaFI64.Bematech_FI_Autenticacion();
			BemaFI64.Analisa_iRetorno(IRetorno);
			BemaFI64.Analisa_RetornoImpresora();
		}

		private void mnuAbrirInforme_Click(object sender, System.EventArgs e)
		{
			IRetorno = BemaFI64.Bematech_FI_InformeGerencial("Escriba su texto aqui");
			BemaFI64.Analisa_iRetorno(IRetorno);
			BemaFI64.Analisa_RetornoImpresora();
		}

		private void mnuCerrarInforme_Click(object sender, System.EventArgs e)
		{
			IRetorno = BemaFI64.Bematech_FI_CierraInformeGerencial();
			BemaFI64.Analisa_iRetorno(IRetorno);
			BemaFI64.Analisa_RetornoImpresora();
		}

		private void mnuAbrirComprobanteNoFiscalVinculado_Click(object sender, System.EventArgs e)
		{
			IRetorno = BemaFI64.Bematech_FI_AbreComprobanteNoFiscalVinculado("Tarjeta","","");
			BemaFI64.Analisa_iRetorno(IRetorno);
			BemaFI64.Analisa_RetornoImpresora();
		}

		private void mnuUtilizarComprobanteNoFiscalVinculado_Click(object sender, System.EventArgs e)
		{
			IRetorno = BemaFI64.Bematech_FI_ImprimeComprobanteNoFiscalVinculado("Escriba su texto aquí");
			BemaFI64.Analisa_iRetorno(IRetorno);
			BemaFI64.Analisa_RetornoImpresora();
		}

		private void mnuCerrarComprobanteNoFiscalVinculado_Click(object sender, System.EventArgs e)
		{
			IRetorno = BemaFI64.Bematech_FI_CierraComprobanteNoFiscalVinculado();
			BemaFI64.Analisa_iRetorno(IRetorno);
			BemaFI64.Analisa_RetornoImpresora();
		}

		private void mnuSangria_Click(object sender, System.EventArgs e)
		{
			IRetorno = BemaFI64.Bematech_FI_Sangria("5000,00");
			BemaFI64.Analisa_iRetorno(IRetorno);
			BemaFI64.Analisa_RetornoImpresora();
		}

		private void mnuProvision_Click(object sender, System.EventArgs e)
		{
			IRetorno = BemaFI64.Bematech_FI_Provision("3000,00","Efectivo");
			BemaFI64.Analisa_iRetorno(IRetorno);
			BemaFI64.Analisa_RetornoImpresora();
		}


		private void mnuLecturaXSerial_Click(object sender, System.EventArgs e)
		{
			IRetorno = BemaFI64.Bematech_FI_LecturaXSerial();
			BemaFI64.Analisa_iRetorno(IRetorno);
			BemaFI64.Analisa_RetornoImpresora();
		}

		private void mnuProgramaAlicuota_Click(object sender, System.EventArgs e)
		{
			IRetorno = BemaFI64.Bematech_FI_ProgramaAlicuota("0500",0);
			BemaFI64.Analisa_iRetorno(IRetorno);
			BemaFI64.Analisa_RetornoImpresora();
		}

		private void mnuProgramaRedondeo_Click(object sender, System.EventArgs e)
		{
			IRetorno = BemaFI64.Bematech_FI_ProgramaRedondeo();
			BemaFI64.Analisa_iRetorno(IRetorno);
			BemaFI64.Analisa_RetornoImpresora();
		}

		private void mnuProgramaCaracter_Click(object sender, System.EventArgs e)
		{
			IRetorno = BemaFI64.Bematech_FI_ProgramaCaracterAutenticacion("001,002,004,008,016,032,064,128,064,032,016,008,004,002,129,129,129,129");
			BemaFI64.Analisa_iRetorno(IRetorno);
			BemaFI64.Analisa_RetornoImpresora();
		}

		private void mnuProgramaTruncamiento_Click(object sender, System.EventArgs e)
		{
			IRetorno = BemaFI64.Bematech_FI_ProgramaTruncamiento();
			BemaFI64.Analisa_iRetorno(IRetorno);
			BemaFI64.Analisa_RetornoImpresora();
		}

		private void mnuIncrementos_Click(object sender, System.EventArgs e)
		{
			string Incrementos = new string('\x20',14);
			IRetorno = BemaFI64.Bematech_FI_Agregado(ref Incrementos);
			BemaFI64.Analisa_iRetorno(IRetorno);
			BemaFI64.Analisa_RetornoImpresora();
			MessageBox.Show("Total de Incrementos\n" + Incrementos,"Bematech",MessageBoxButtons.OK);
		}

		private void mnuAlicuotasRegistradas_Click(object sender, System.EventArgs e)
		{
			string Alicuotas = new string('\x20',79);
			IRetorno = BemaFI64.Bematech_FI_RetornoAlicuotas(ref Alicuotas);
			BemaFI64.Analisa_iRetorno(IRetorno);
			BemaFI64.Analisa_RetornoImpresora();
			MessageBox.Show("Alicuotas Programadas : " + Alicuotas,"Bematech",MessageBoxButtons.OK);
		}

		private void mnuAnulaciones_Click(object sender, System.EventArgs e)
		{
			string NumCupones = new string('\x20',4);
			IRetorno = BemaFI64.Bematech_FI_NumeroCuponesAnulados(ref NumCupones);
			BemaFI64.Analisa_iRetorno(IRetorno);
			BemaFI64.Analisa_RetornoImpresora();
			MessageBox.Show("Numero de cupones anulados: " + NumCupones,"Bematech",MessageBoxButtons.OK);
		
		}

		private void mnuDatosUltimaReduccion_Click(object sender, System.EventArgs e)
		{
			string Datos = new string('\x20',613);
			IRetorno = BemaFI64.Bematech_FI_DatosUltimaReduccion(ref Datos);
			BemaFI64.Analisa_iRetorno(IRetorno);
			BemaFI64.Analisa_RetornoImpresora();
			MessageBox.Show("Datos de la Última Reducción Z: \n\n" + Datos,"Bematech",MessageBoxButtons.OK);
		
		}

		private void mnuDescuentos_Click(object sender, System.EventArgs e)
		{
			string ValorDescuentos = new string('\x20',14);
			IRetorno = BemaFI64.Bematech_FI_Descuentos(ref ValorDescuentos);
			BemaFI64.Analisa_iRetorno(IRetorno);
			BemaFI64.Analisa_RetornoImpresora();
			MessageBox.Show("Valor de los Descuentos : " + ValorDescuentos,"Bematech",MessageBoxButtons.OK);
		
		}

		private void mnuAbrirGaveta_Click(object sender, System.EventArgs e)
		{
			IRetorno = BemaFI64.Bematech_FI_AccionaGaveta();			
			BemaFI64.Analisa_iRetorno(IRetorno);
			BemaFI64.Analisa_RetornoImpresora();
		}

		private void mnuStatusGaveta_Click(object sender, System.EventArgs e)
		{
			int EstadoGaveta;
			IRetorno = BemaFI64.Bematech_FI_VerificaEstadoGaveta(out EstadoGaveta);
			BemaFI64.Analisa_iRetorno(IRetorno);
			BemaFI64.Analisa_RetornoImpresora();
			if (EstadoGaveta == 1)
			{
				MessageBox.Show("Gaveta abierta","Bematech",MessageBoxButtons.OK);
			}
			else
				MessageBox.Show("Gaveta cerrada","Bematech",MessageBoxButtons.OK);
			}
	}
}*/

		#region Funciones de tratamiento de error

		/// <summary>
		/// Función para analisar los retorno de la impresora (ST1 y ST2).
		/// </summary>
		public string Analisa_RetornoImpresora()
			{
				int ACK,ST1,ST2;
				string Errores = "";
				ACK = ST1 = ST2 =0;

				Bematech_FI_RetornoImpresora(ref ACK,ref ST1,ref ST2);

				#region Tratando o ST1
				if ( ST1 >= 128)
				{
					ST1 = ST1 - 128;
					Errores += "BIT 7 - Fin de Papel" + '\x0D';				
				}
				if ( ST1 >= 64)
				{
					ST1 = ST1 - 64;
					Errores += "BIT 6 - Poco Papel" + '\x0D';
				}
				if ( ST1 >= 32)
				{
					ST1 = ST1 - 32;
					Errores += "BIT 5 - Error en el Reloj" + '\x0D';
				}
				if ( ST1 >= 16)
				{
					ST1 = ST1 - 16;
					Errores += "BIT 4 - Impresora en ERROR" + '\x0D';
				}
				if ( ST1 >= 8)
				{
					ST1 = ST1 - 8;
					Errores += "BIT 3 - CMD não iniciado com ESC" + '\x0D';
				}
				if ( ST1 >= 4)
				{
					ST1 = ST1 - 4;
					Errores += "BIT 2 - Comando Inexistente" + '\x0D';
				}
				if ( ST1 >= 2)
				{
					ST1 = ST1 - 2;
					Errores += "BIT 1 - Comprobante Abierto" + '\x0D';
				}
				if ( ST1 >= 1)
				{
					ST1 = ST1 - 1;
					Errores += "BIT 0 - Nº de Parámetros Inválidos" + '\x0D';
				}
				#endregion

				#region Tratando o ST2
				if ( ST2 >= 128)
				{
					ST2 = ST2 - 128;
					Errores += "BIT 7 - Tipo de Parámetro Inválido" + '\x0D';
				}
				if ( ST2 >= 64)
				{
					ST2 = ST2 - 64;
					Errores += "BIT 6 - Memória Fiscal Llena" + '\x0D';
				}
				if ( ST2 >= 32)
				{
					ST2 = ST2 - 32;
					Errores += "BIT 5 - CMOS noo Volátil" + '\x0D';
				}
				if ( ST2 >= 16)
				{
					ST2 = ST2 - 16;
					Errores += "BIT 4 - Alicuota no programada" + '\x0D';
				}
				if ( ST2 >= 8)
				{
					ST2 = ST2 - 8;
					Errores += "BIT 3 - Alicuotas llenas" + '\x0D';
				}
				if ( ST2 >= 4)
				{
					ST2 = ST2 - 4;
					Errores += "BIT 2 - Anulación no permitida" + '\x0D';
				}
				if ( ST2 >= 2)
				{
					ST2 = ST2 - 2;
					Errores += "BIT 1 - RIF no programado" + '\x0D';
				}
				if ( ST2 >= 1)
				{
					ST2 = ST2 - 1;
					Errores += "BIT 0 - Comando no ejecutado" + '\x0D';
				}

				#endregion
				

			return Errores;
			}

			/// <summary>
		/// Função que analiza o retorno da função.
		/// </summary>
		/// <param name="IRetorno">Inteiro com o valor a ser analizado.</param>
			public string Analisa_iRetorno(int IRetorno)
			{
				string MSG = "";
				


				switch(IRetorno)
				{
					case  0: 
						MSG = "Error de Comunicación !";


						break;
					case -1: 
						MSG = "Error de ejecución en la función. Verifique!";


						break;
					case -2: 
						MSG = "Parámetro Inválido !";


						break;
					case -3: 
						MSG = "Alicuota no programada !";
						break;
					case -4: 
						MSG = "Archivo BemaFI64.INI no encontrado. Verifique!";
						break;
					case -5: 
						MSG = "Error al abrir el puerto de comunicación";


						break;
					case -6: 
						MSG = "Impresora apagada o desconectada.";
						break;
					case -7: 
						MSG = "Banco no registrado en el Archivo BemaFI64.ini";
						break;
					case -8: 
						MSG = "Error al crear o Grabar en el archivo Retorno.txt o Status.txt.";


						break;
					case -18: 
						MSG = "No fué posíble abrir el archivo INTPOS.001!";
						break;
					case -19: 
						MSG = "Parámetros diferentes!";
						break;
					case -20: 
						MSG = "Transación anulada por el operador!";
						break;
					case -21: 
						MSG = "La transación no fué aprobada!";
						break;
					case -22: 
						MSG = "No fué posible finalizar la impresión!";
						break;
					case -23: MSG = "No fué posible finalizar la operación!";
						break;
					case -24: MSG = "No fué posible finalizar la operación!";
						break;
					case -25: MSG = "Totalizador no fiscal no programado.";
						break;
					case -26: MSG = "Transación ya efectuada!";
						break;
					case -27: Analisa_RetornoImpresora();
						break;
					case -28: MSG = "No hay informaciones para imprimir!";
						break;
				}
			return MSG;
				

			}

		
		#endregion

		#region DECLARACIÓN DE LAS FUNCIONES DE LA BEMAFI64.DLL   

		#region Funciones de Inicialización     
		[DllImport("BemaFi64.dll")]  public static extern int Bematech_FI_ProgramaAlicuota(string Alicuota, int ICMS_ISS);     
		[DllImport("BemaFi64.dll")]  public static extern int Bematech_FI_ProgramaRedondeo();   
		[DllImport("BemaFi64.dll")]  public static extern int Bematech_FI_ProgramaTruncamiento();   
		#endregion   

		#region Funciones del Cupon Fiscal   
		[DllImport("BemaFi64.dll")]  public static extern int Bematech_FI_AbreComprobanteDeVenta(string RIF, string Nombre);   
		[DllImport("BemaFi64.dll")]  public static extern int Bematech_FI_AbreComprobanteDeVentaEx(string RIF, string Nombre, string Direccion);  
		[DllImport("BemaFi64.dll")]  public static extern int Bematech_FI_VendeArticulo(string Codigo, string Descripcion, string Alicuota, string TipoCantidad, string Cantidad, int CasasDecimales, string ValorUnitario, string TipoDescuento, string Descuento);     
		[DllImport("BemaFi64.dll")]  public static extern int Bematech_FI_AnulaArticuloAnterior();    
		[DllImport("BemaFi64.dll")]  public static extern int Bematech_FI_AnulaCupon();     
		[DllImport("BemaFi64.dll")]  public static extern int Bematech_FI_CierraCupon(string FormaPago, string IncrementoDescuento, string TipoIncrementoDescuento, string ValorIncrementoDescuento, string ValorPago, string Mensaje);   
		[DllImport("BemaFi64.dll")]  public static extern int Bematech_FI_IniciaCierreCupon(string IncrementoDescuento, string TipoIncrementoDescuento, string ValorIncrementoDescuento);   
		[DllImport("BemaFi64.dll")]  public static extern int Bematech_FI_EfectuaFormaPago(string FormaPago, string ValorFormaPago);    
		[DllImport("BemaFi64.dll")]  public static extern int Bematech_FI_FinalizaCierreCupon(string Mensaje);   
		[DllImport("BemaFi64.dll")]  public static extern int Bematech_FI_DevolucionArticulo(string Codigo, string Descripcion, string Alicuota, string TipoCantidad, string Cantidad, int CasasDecimales, string ValorUnit, string TipoDescuento, string ValorDesc);
		[DllImport("BemaFi64.dll")]  public static extern int Bematech_FI_AbreNotaDeCredito(string Nombre, string NumeroSerie, string RIF, string Dia, string Mes, string Ano, string Hora, string Minuto, string Segundo, string COO, string MsjPromocional);   
		#endregion   

		#region Funciones de los Informes Fiscales   
		[DllImport("BemaFi64.dll")]  public static extern int Bematech_FI_LecturaX();   
		[DllImport("BemaFi64.dll")]  public static extern int Bematech_FI_LecturaXSerial();   
		[DllImport("BemaFi64.dll")]  public static extern int Bematech_FI_ReduccionZ(string Fecha, string Hora);   
		[DllImport("BemaFi64.dll")]  public static extern int Bematech_FI_InformeGerencial(string Texto);   
		[DllImport("BemaFi64.dll")]  public static extern int Bematech_FI_CierraInformeGerencial();   
		#endregion   

		#region Funciones de las Operaciones No Fiscales   
		[DllImport("BemaFi64.dll")]  public static extern int Bematech_FI_RecebimientoNoFiscal(string IndiceTotalizador, string Valor, string FormaPago);   
		[DllImport("BemaFi64.dll")]  public static extern int Bematech_FI_AbreComprobanteNoFiscalVinculado(string FormaPago, string Valor, string NumeroCupon);   
		[DllImport("BemaFi64.dll")]  public static extern int Bematech_FI_ImprimeComprobanteNoFiscalVinculado(string Texto);   
		[DllImport("BemaFi64.dll")]  public static extern int Bematech_FI_CierraComprobanteNoFiscalVinculado();   
		[DllImport("BemaFi64.dll")]  public static extern int Bematech_FI_Sangria(string Valor);   
		[DllImport("BemaFi64.dll")]  public static extern int Bematech_FI_Provision(string Valor, string FormaPago);   
		#endregion   

		#region Funciones de Informaciones de la Impresora   
		[DllImport("BemaFi64.dll")]  public static extern int Bematech_FI_Agregado([MarshalAs(UnmanagedType.VBByRefStr)] ref string ValorIncrementos);   
		[DllImport("BemaFi64.dll")]  public static extern int Bematech_FI_Cancelamientos([MarshalAs(UnmanagedType.VBByRefStr)] ref string ValorCancelamientos);   
		[DllImport("BemaFi64.dll")]  public static extern int Bematech_FI_DatosUltimaReduccion([MarshalAs(UnmanagedType.VBByRefStr)] ref string DatosReduccion);   
		[DllImport("BemaFi64.dll")]  public static extern int Bematech_FI_Descuentos([MarshalAs(UnmanagedType.VBByRefStr)] ref string ValorDescuentos);   
		[DllImport("BemaFi64.dll")]  public static extern int Bematech_FI_NumeroCuponesAnulados([MarshalAs(UnmanagedType.VBByRefStr)] ref string NumeroCancelamientos);   
        [DllImport("BemaFi64.dll")]  public static extern int Bematech_FI_RetornoAlicuotas([MarshalAs(UnmanagedType.VBByRefStr)] ref string Alicuotas); 

		#endregion   

		#region Funciones de Autenticación y Gaveta de Efectivo   
		[DllImport("BemaFI64.dll")]  public static extern int Bematech_FI_AccionaGaveta();   
		[DllImport("BemaFI64.dll")]  public static extern int Bematech_FI_Autenticacion();   
		[DllImport("BemaFI64.dll")]  public static extern int Bematech_FI_ProgramaCaracterAutenticacion(string Parametros);   
		[DllImport("BemaFI64.dll")]  public static extern int Bematech_FI_VerificaEstadoGaveta(out int EstadoGaveta);   
		#endregion   

		#region Otras Funciones    
		[DllImport("BemaFi64.dll")]  public static extern int Bematech_FI_AbrePuertaSerial();     
		[DllImport("BemaFi64.dll")]  public static extern int Bematech_FI_CierraPuertaSerial();     
		[DllImport("BemaFi64.dll")]  public static extern int Bematech_FI_RetornoImpresora(ref int ACK, ref int ST1, ref int ST2);   
	  
		#endregion 

		#endregion
	}
}
