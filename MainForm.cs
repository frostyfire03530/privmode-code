/*
 * Created by SharpDevelop.
 * User: Frosty
 * Date: 10/17/2013
 * Time: 9:34 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace Privmode_Code
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		void MainFormLoad(object sender, EventArgs e)
		{
			
		}
		
		void Label1Click(object sender, EventArgs e)
		{
			
		}
		
		void Label2Click(object sender, EventArgs e)
		{
			
		}
		
		void MenuStrip1ItemClicked(object sender, ToolStripItemClickedEventArgs e)
		{
			
		}
		
		void aboutToolStripMenuItem1Clicked(object sender, EventArgs e){
			MessageBox.Show(
				"Privmode Code calculates the \"priv\" password\n" +
				"used to unlock certain commands and advanced settings in\n" +
				"ROMMON mode on certain networking equipment.\n\n" +
				"Written in C# by: Nathan J. Waters\n\n" +
				"Algorithm by: Roman S. Emelyanov (http://ers.msk.ru/)\n\n" +
				"2013.10.18",
				"About Privmode Code"
			);
		}
		
		void getPassword(object sender, EventArgs e){
			label4.ForeColor = System.Drawing.Color.IndianRed;
			label4.Text = "";
			Regex pattern = new Regex("[^abcdefABCDEF01234567890]");
			string cookiePassword;
			string cookieString = cookieTextbox.Text;
			cookieString = cookieString.Replace(" ", string.Empty).Replace(":", string.Empty);
			int cookieLength = cookieString.Length;
			bool isCookieLengthGood = false;
			bool isCookieCharsGood = false;
			int cookieType = 0;
				
			if (radioButton1.Checked){
				cookieType = 8;
			}
			else if(radioButton2.Checked){
				cookieType = 5;
			}
			if (cookieLength == 32){
				isCookieLengthGood = true;
			}
			else{
				label4.Text = "The hex number length does not match 32.";
				return;
			}
			if (pattern.IsMatch(cookieString)){
			    label4.Text = "Somewhere there is an incorrect hex value.";
			    return;
			}
			else{
				isCookieCharsGood = true;
			}
			if(isCookieLengthGood && isCookieCharsGood){
				cookiePassword = calcPassword(cookieString, cookieType);
				label4.ForeColor = System.Drawing.Color.ForestGreen;
				label4.Text = "Success! Password is: " + cookiePassword;
				//textBox2.Text = cookiePassword;
			}
		}
		void getPassword(){
			label4.ForeColor = System.Drawing.Color.IndianRed;
			label4.Text = "";
			Regex pattern = new Regex("[^abcdefABCDEF01234567890]");
			string cookiePassword;
			string cookieString = cookieTextbox.Text;
			cookieString = cookieString.Replace(" ", string.Empty).Replace(":", string.Empty);
			int cookieLength = cookieString.Length;
			bool isCookieLengthGood = false;
			bool isCookieCharsGood = false;
			int cookieType = 0;
				
			if (radioButton1.Checked){
				cookieType = 8;
			}
			else if(radioButton2.Checked){
				cookieType = 5;
			}
			if (cookieLength == 32){
				isCookieLengthGood = true;
			}
			else{
				label4.Text = "The hex number length does not match 32.";
				return;
			}
			if (pattern.IsMatch(cookieString)){
			    label4.Text = "Somewhere there is an incorrect hex value.";
			    return;
			}
			else{
				isCookieCharsGood = true;
			}
			if(isCookieLengthGood && isCookieCharsGood){
				cookiePassword = calcPassword(cookieString, cookieType);
				label4.ForeColor = System.Drawing.Color.ForestGreen;
				label4.Text = "Success! Password is: " + cookiePassword;
				//textBox2.Text = cookiePassword;
			}
		}		
		public string calcPassword(string userInput, int cookieType){
			string[] hexSegments = new string[8];
			int hexSum = 0;
			double decimalCalc;
			int intHex;
			string hexString;
			int firstNum = 0;
			int endNum = 4;
			for(int i = 0; i < cookieType; i++){
					for(int j = firstNum ; j < endNum ; j++){
						hexSegments[i] += userInput[j];
					}
				firstNum += 4;
				endNum += 4;
				hexSum += Convert.ToInt32(hexSegments[i], 16);
			}
			decimalCalc = hexSum % Math.Pow(2, 16);
			intHex = Convert.ToInt32(decimalCalc);
			hexString = intHex.ToString("X");
			if (hexString.Length < 4){
				hexString = "0"+hexString;
			}
			userInput = hexString;
			return userInput;
		}
		
		void Label5Click(object sender, EventArgs e)
		{
			
		}
		
		void RadioButton1CheckedChanged(object sender, EventArgs e)
		{
			getPassword();
		}
		
		void RadioButton2CheckedChanged(object sender, EventArgs e)
		{
			getPassword();
		}
	}
}