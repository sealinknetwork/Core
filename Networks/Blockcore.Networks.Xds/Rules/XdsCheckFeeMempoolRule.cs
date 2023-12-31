﻿using System.Diagnostics;
using Blockcore.Consensus.Chain;
using Blockcore.Features.MemoryPool;
using Blockcore.Features.MemoryPool.Interfaces;
using Blockcore.Features.MemoryPool.Rules;
using Microsoft.Extensions.Logging;

namespace Blockcore.Networks.Xds.Rules
{
    /// <summary>
    /// Validates the transaction fee is valid, so that the transaction can be mined eventually.
    /// Checks whether the fee meets minimum fee, free transactions have sufficient priority, and absurdly high fees.
    /// </summary>
    public class XdsCheckFeeMempoolRule : CheckFeeMempoolRule
    {
        public XdsCheckFeeMempoolRule(Network network,
            ITxMempool mempool,
            MempoolSettings mempoolSettings,
            ChainIndexer chainIndexer,
            ILoggerFactory loggerFactory) : base(network, mempool, mempoolSettings, chainIndexer, loggerFactory)
        {
        }

        public override void CheckTransaction(MempoolValidationContext context)
        {
            Debug.Assert(((XdsMain)this.network).AbsoluteMinTxFee.HasValue);

            long consensusRejectFee = ((XdsMain)this.network).AbsoluteMinTxFee.Value;
            if (context.Fees < consensusRejectFee)
            {
                this.logger.LogTrace("(-)[FAIL_ABSOLUTE_MIN_TX_FEE_NOT_MET]");
                context.State.Fail(MempoolErrors.MinFeeNotMet, $" {context.Fees} < {consensusRejectFee}").Throw();
            }

            // calling the base class here allows for customized behavior above the AbsoluteMinTxFee threshold.
            base.CheckTransaction(context);
        }
    }
}