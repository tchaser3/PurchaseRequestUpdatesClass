/* Title:       Purchase Request Update Class
 * Date:        1-23-20
 * Author:      Terry Holmes
 * 
 * Description: This is the class for the updates */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewEventLogDLL;

namespace PurchaseRequestUpdateDLL
{
    public class PurchaseRequestUpdateClass
    {
        EventLogClass TheEventLogClass = new EventLogClass();

        PurchaseRequestUpdatesDataSet aPurchaseRequestUpdatesDataSet;
        PurchaseRequestUpdatesDataSetTableAdapters.purchaserequestupdatesTableAdapter aPurchaseRequestUpdatesTableAdapter;

        InsertPurchaseRequestUpdateEntryTableAdapters.QueriesTableAdapter aInsertPurchaseRequestUpdateTableAdapter;

        FindPurchaseRequestUpdatesByPONumberDataSet aFindPurchaseRequestUpdatesByPONumberDataSet;
        FindPurchaseRequestUpdatesByPONumberDataSetTableAdapters.FindPurchaseRequestUpdatesByPONumberTableAdapter aFindPurchaseRequestUpdatesByPONumberTableAdapter;

        public FindPurchaseRequestUpdatesByPONumberDataSet FindPurchaseRequestUpdatesByPONumber(int intPONumber)
        {
            try
            {
                aFindPurchaseRequestUpdatesByPONumberDataSet = new FindPurchaseRequestUpdatesByPONumberDataSet();
                aFindPurchaseRequestUpdatesByPONumberTableAdapter = new FindPurchaseRequestUpdatesByPONumberDataSetTableAdapters.FindPurchaseRequestUpdatesByPONumberTableAdapter();
                aFindPurchaseRequestUpdatesByPONumberTableAdapter.Fill(aFindPurchaseRequestUpdatesByPONumberDataSet.FindPurchaseRequestUpdatesByPONumber, intPONumber);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Purchase Request Updates Class // Find Purchase Request Updates By PO Number " + Ex.Message);
            }

            return aFindPurchaseRequestUpdatesByPONumberDataSet;
        }
        public bool InsertPurchaseRequestUpdate(int intPONumber, DateTime datTransactionDate, int intEmployeeID, string strRequestUpdate)
        {
            bool blnFatalError = false;

            try
            {
                aInsertPurchaseRequestUpdateTableAdapter = new InsertPurchaseRequestUpdateEntryTableAdapters.QueriesTableAdapter();
                aInsertPurchaseRequestUpdateTableAdapter.InsertPurchaseRequestUpdates(intPONumber, datTransactionDate, intEmployeeID, strRequestUpdate);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Purchase Request Updates Class // Insert Purchase Request Update " + Ex.Message);

                blnFatalError = true;
            }

            return blnFatalError;
        }
        public PurchaseRequestUpdatesDataSet GetPurchaseRequestUpdatesInfo()
        {
            try
            {
                aPurchaseRequestUpdatesDataSet = new PurchaseRequestUpdatesDataSet();
                aPurchaseRequestUpdatesTableAdapter = new PurchaseRequestUpdatesDataSetTableAdapters.purchaserequestupdatesTableAdapter();
                aPurchaseRequestUpdatesTableAdapter.Fill(aPurchaseRequestUpdatesDataSet.purchaserequestupdates);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Purchase Request Updates Class // Get Purchase Request Updates Info " + Ex.Message);
            }

            return aPurchaseRequestUpdatesDataSet;
        }
        public void UpdatePurchaseRequestUpdatesDB(PurchaseRequestUpdatesDataSet aPurchaseRequestUpdatesDataSet)
        {
            try
            {
                aPurchaseRequestUpdatesTableAdapter = new PurchaseRequestUpdatesDataSetTableAdapters.purchaserequestupdatesTableAdapter();
                aPurchaseRequestUpdatesTableAdapter.Update(aPurchaseRequestUpdatesDataSet.purchaserequestupdates);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Purchase Request Updates Class // Update Purchase Request Updates DB " + Ex.Message);
            }
        }
    }
}
