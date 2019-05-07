import numpy as np
import h5py
import sys

np.savetxt(sys.stdout, h5py.File('data/sanfran_public.h5')['jobs'], '%s', ',')