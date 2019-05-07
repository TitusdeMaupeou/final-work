import sys
sys.path.append(r"C:\Program Files\IronPython 2.7\Lib");

import os
import numpy as np
# import pandas as pd
import urbansim.utils.misc

print('test')

def fill_nas_from_config(dfname, df):
    df_cnt = len(df)
    fillna_config = orca.get_injectable("fillna_config")
    fillna_config_df = fillna_config[dfname]
    for fname in fillna_config_df:
        filltyp, dtyp = fillna_config_df[fname]
        s_cnt = df[fname].count()
        fill_cnt = df_cnt - s_cnt
        if filltyp == "zero":
            val = 0
        elif filltyp == "mode":
            val = df[fname].dropna().value_counts().idxmax()
        elif filltyp == "median":
            val = df[fname].dropna().quantile()
        else:
            assert 0, "Fill type not found!"
        print("Filling column {} with value {} ({} values)"
              .format(fname, val, fill_cnt))
        df[fname] = df[fname].fillna(val).astype(dtyp)
    return df