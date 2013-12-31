/*
 * Created by SharpDevelop.
 * User: Arran
 * Date: 31/12/2013
 * Time: 17:40
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections;
using System.Collections.Generic;
namespace AuditTrailer.Application.Authorisation
{
	/// <summary>
	/// Description of PasswordStrengthValidationResult.
	/// </summary>
	public class PasswordStrengthValidationResult
	{
		public bool PasswordStrongEnough { get; set; }
		public List<string> ValidationErrors { get; set; }
	}
}
