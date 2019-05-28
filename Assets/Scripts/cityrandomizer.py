import random
import h5py
import pandas as pd
import time
import zmq
import json
from urbansim.utils import misc

# script to generate random building, households and jobs dataframes and convert them to hdf
# the order is determined by the San francisco example from Urbansim

hdf = pd.HDFStore('C:/Users/user/Desktop/Final Work/final_work/Unity/Assets/Scripts/Simulations/data/data/titusville.h5')

# load the json settings file
with open('settings.json') as config_file:
    data = json.load(config_file)

# all the parameters we are searching for
params = ['buildings', 'households', 'jobs']

# amount of buildings
building_amount = 100

# fill a dictionary with random data for the parameters
def fill_dict(dictionary, param):
  new_dict = {}
  for k,v in dictionary[param].items():
    new_dict[k] = random.randint(v['min'], v['max'])
  return new_dict

# generate dataframes from every data item and store them in the hdfstore
def fill_hdf(dictionary):
  for item in dictionary:
    df = pd.DataFrame(dictionary[item].items()) 
    hdf.put(item, df, format='table', columns='True')

# generate pandas dataframes for buildings, households, jobs and zones * the number of buildings
def generate_data():
  dict = {}
  i = 0
  while i < building_amount:
    for param in params:
      fill_dict(data, param)
      dict[param] = fill_dict(data, param)
    i+=1
  fill_hdf(dict)

print('generating building data...')

generate_data()

hdf.close()

  # for param in building_params:
  #   print(random.randint(nested_get(data, ['buildings', param, 'min']), nested_get(data, ['buildings', param, 'max']))) 

  # key = random.randint(key["min"], key["max"])
  # buildings.append({key: random.randint(key["min"], key["max"])})

# i = 0
# while i < building_amount:
#   # block 0 buildings
#   residential_units = random.randint(0, 6)
#   non_residential_sqft = random.randint(0, 4000)
#   building_sqft = random.randint(0, 4000)
#   stories = random.randint(0, 4)
#   building_type_id = random.randint(0, 15)
#   year_built = random.randint(1900, 2019)

#   # block 1 buildings
#   residential_sales_price = random.randint(0, 900)
#   non_residential_rent = random.randint(0, 30)

#   # block 0 households
#   building_id = i
#   income = random.randint(500, 27000)
#   persons = random.randint(1, 3)
#   tenure = random.randint(1, 3)

#   # block 0 jobs
#   job_category = random.randint(0,3)

#   #zones
#   tract = random.randint(5602, 6000)
#   area = random.randint(100, 200)
#   acres = random.randint(1, 50)
#   gid = i

#   # block_1_buildings.append({'residential_sales_price': residential_sales_price, 'non_residential_rent': non_residential_rent})
#   buildings.append({'residential_units': residential_units, 'non_residential_sqft': non_residential_sqft, 'stories': stories, 'building_type_id': building_type_id, 'year_built': year_built, 'residential_sales_price': residential_sales_price, 'non_residential_rent': non_residential_rent})
#   households.append({'building_id': building_id, 'building_type_id': building_type_id, 'income': income, 'persons': persons, 'tenure': tenure})
#   jobs.append({'building_id': building_id, 'job_category': job_category})
#   zones.append({'tract': tract, 'area': area, 'acres': acres, 'gid': gid})
#   i += 1

# df1 = pd.DataFrame(buildings)
# df2 = pd.DataFrame(households)
# df3 = pd.DataFrame(jobs)
# df4 = pd.DataFrame(zones)

# # df1.to_hdf('C:/Users/user/Desktop/Final Work/final_work/Unity/Assets/Scripts/Simulations/data/data/titusville.h5', key='df1')

# hdf.put('buildings', df1, format='table', columns='True')
# hdf.put('households', df2, format='table', columns='True')
# hdf.put('jobs', df3, format='table', columns='True')
# hdf.put('zones', df4, format='table', columns='True')
# hdf.put('buildings', df2, format='table', columns='True')
  
# hdf.close()