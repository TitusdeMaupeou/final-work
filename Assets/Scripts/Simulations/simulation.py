# %load_ext autoreload
# %autoreload 2
import models, utils
import orca
import time
import zmq

orca.run([
    "rsh_simulate",              # residential sales hedonic
    "nrh_simulate",              # non-residential rent hedonic

    "households_relocation",     # households relocation model
    "hlcm_simulate",            # households location choice
    "households_transition",     # households transition

    "jobs_relocation",           # jobs relocation model
    "elcm_simulate",             # employment location choice
    "jobs_transition",           # jobs transition

    "feasibility",               # compute development feasibility
    "residential_developer",     # build residential buildings
    "non_residential_developer", # build non-residential buildings
], iter_vars=[2010])