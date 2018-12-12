﻿/**
 * Outlook integration for SuiteCRM.
 * @package Outlook integration for SuiteCRM
 * @copyright SalesAgility Ltd http://www.salesagility.com
 *
 * This program is free software; you can redistribute it and/or modify
 * it under the terms of the GNU LESSER GENERAL PUBLIC LICENCE as published by
 * the Free Software Foundation; either version 3 of the License, or
 * (at your option) any later version.
 *
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 *
 * You should have received a copy of the GNU LESSER GENERAL PUBLIC LICENCE
 * along with this program; if not, see http://www.gnu.org/licenses
 * or write to the Free Software Foundation,Inc., 51 Franklin Street,
 * Fifth Floor, Boston, MA 02110-1301  USA
 *
 * @author SalesAgility <info@salesagility.com>
 */

using System;
using System.Text.RegularExpressions;

namespace SuiteCRMAddIn.BusinessLogic
{
    public class CrmIdValidationPolicy
    {
        public string Key { get; private set; }
        public string Value { get; private set; }
        /// <summary>
        /// Selectable policies
        /// </summary>
        public enum Policy
        {
            Strict,
            Relaxed
        }

        /// <summary>
        ///     Test and demo data includes ids which do not match the pattern normally generated by CRM.
        /// </summary>
        private const string RelaxedPattern = "[0-9a-z-_]+";

        /// <summary>
        ///     Validates Guids as generated by CRM
        /// </summary>
        private const string StrictPattern = "[a-f0-9-]{36}";

        /// <summary>
        ///     Returns an appropriate validation pattern for the specified policy.
        /// </summary>
        /// <param name="policy">The policy selected.</param>
        /// <returns>An appropriate validation pattern for the specified policy.</returns>
        public static Regex GetValidationPattern(Policy policy)
        {
            Regex result;

            switch (policy)
            {
                case Policy.Relaxed:
                    result = new Regex(RelaxedPattern);
                    break;
                case Policy.Strict:
                    result = new Regex(StrictPattern);
                    break;
                default:
                    result = new Regex(StrictPattern);
                    break;
            }

            return result;
        }
    }
}