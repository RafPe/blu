import sys
import os
import subprocess

#Read the docs
read_the_docs_build = os.environ.get('READTHEDOCS', None) == 'True'
#if read_the_docs_build:
subprocess.call('cd ../; doxygen config.doxy', shell=True)

# -- General configuration ------------------------------------------------


extensions = ['breathe']
breathe_projects = {"BluApi": r"../doxygen/output/BluApi/xml"}
breathe_default_project = "BluApi"

# Add any paths that contain templates here, relative to this directory.
templates_path = ['_templates']

# The suffix of source filenames.
source_suffix = '.rst'

# The master toctree document.
master_doc = 'index'

# General information about the project.
project = 'Blu'
copyright = '2016, Anooshiravan Ahmadi, Schuberg Philis'
author = 'Anooshiravan Ahmadi'

version = '1.0.0'
# The full version, including alpha/beta/rc tags.
release = '1.0.0'

exclude_patterns = []

pygments_style = 'sphinx'

# -- Options for HTML output ----------------------------------------------

# The theme to use for HTML and HTML Help pages.  See the documentation for
# a list of builtin themes.
html_theme = 'default'

# Add any paths that contain custom static files (such as style sheets) here,
# relative to this directory. They are copied after the builtin static files,
# so a file named "default.css" will overwrite the builtin "default.css".
html_static_path = ['_static']

# Output file base name for HTML help builder.
htmlhelp_basename = 'BluDocs'