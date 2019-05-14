import random
import h5py
import pandas as pd
import time
import zmq
from urbansim.utils import misc

# script to generate random building, households and jobs dataframes and convert them to hdf
# the order is determined by the San francisco example form Urbansim

hdf = pd.HDFStore('C:/Users/user/Desktop/Final Work/final_work/Unity/Assets/Scripts/Simulations/data/data/titusville.h5')

print('generating building data...')

building_amount = 100

block_0 = []
block_1 = []

i = 1
while i < building_amount:
  # block 0 buildings
  residential_units = random.randint(0, 6)
  non_residential_sqft = random.randint(0, 4000)
  building_sqft = random.randint(0, 4000)
  stories = random.randint(0, 4)
  building_type_id = random.randint(0, 15)
  year_built = random.randint(1900, 2019)

  # block 1 buildings
  residential_sales_price = random.randint(0, 900)
  non_residential_rent = random.randint(0, 30)


  block_0.append({'residential_units': residential_units, 'non_residential_sqft': non_residential_sqft, 'stories': stories, 'building_type_id': building_type_id, 'year_built': year_built})
  block_1.append({'residential_sales_price': residential_sales_price, 'non_residential_rent': non_residential_rent})

  i += 1

print(block_0)
df1 = pd.DataFrame(block_0)
# block_0 = [residential_units, non_residential_sqft, building_sqft, stories, building_type_id, year_built]
# df1 = pf.conpd.DataFrame([block_0], index=['one', 'two'], columns = ['residential_units', 'non_residential_sqft', 'building_sqft', 'stories', 'building_type_id', 'year_built'], dtype=np.float64)

hdf.put('b', df1, format='table', columns='True')
# hdf.put('buildings', df1, format='table', columns='True')
# hdf.put('buildings', df2, format='table', columns='True')

hdf.close()
