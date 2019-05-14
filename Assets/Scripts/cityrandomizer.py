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

block_0_buildings = []
block_1_buildings = []
block_0_households = []
block_0_jobs = []

i = 0
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

  # block 0 households
  building_id = random.randint(0, 100)
  income = random.randint(500, 27000)
  persons = random.randint(1, 3)
  tenure = random.randint(1, 3)

  # block 0 jobs
  job_category = random.randint(0,3)

  block_0_buildings.append({'residential_units': residential_units, 'non_residential_sqft': non_residential_sqft, 'stories': stories, 'building_type_id': building_type_id, 'year_built': year_built})
  block_1_buildings.append({'residential_sales_price': residential_sales_price, 'non_residential_rent': non_residential_rent})
  block_0_households.append({'building_id': building_id, 'building_type_id': building_type_id, 'income': income, 'persons': persons, 'tenure': tenure})
  block_1_jobs.append({'building_id': building_id, 'job_category': job_category})
  i += 1

df1 = pd.DataFrame(block_0_buildings)
df2 = pd.DataFrame(block_1_buildings)
print(df2)

hdf.put('buildings', df1, format='table', columns='True')
# hdf.put('buildings', df2, format='table', columns='True')
  
hdf.close()