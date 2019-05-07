import string
import numpy as np
import pandas as pd

hdf = pd.HDFStore('C:\Users\user\Desktop\Final Work\final_work')

df1 = pd.read_csv('C:\Users\user\Desktop\Final Work\final_work\Unity\Assets\Scripts\urbansim\urbansim\urbanchoice\tests\data')
hdf.put('DF1', df1, format='table', data_columns=True)

print('hey')
print('df1' + df1)