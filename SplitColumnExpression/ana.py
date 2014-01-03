import sys
import re

infile = sys.argv[1]
inpath = 'Jan3/' + infile + '.csv'
outpath = 'out/out_' + infile + '.csv'

lines = open(inpath,'r').readlines()
fout = open(outpath,'w')

terms = []

def RemoveStopword(str):
  result = str
  stop_word = [';', ':', '[', ']', '(', ')', 'Not']
  for w in stop_word:
    result = result.replace(w,' ')
  return result

def SplitExpression(exp):
  return re.split('& | Or', exp)

title = lines[0][:-1]

out_list = []
  
for l in xrange(1,len(lines)):
  line = lines[l]
  cels = line.split(',')
  ful_exp = cels[4]
  exp_list = SplitExpression(RemoveStopword(ful_exp))
  tuples = dict()
  for exp in exp_list:
    tup = exp.split('=')
    tup = [x.strip() for x in tup]
    if tup[0] not in terms:
      terms.append(tup[0])
    if tup[0] not in tuples:
      tuples[tup[0]] = tup[1]
    else:
      tuples[tup[0]] += ' ; ' + str(tup[1])
  out_str = line[:-1] + ' , '
  for t in terms:
    if t in tuples:
      out_str +=  str(tuples[t])
    out_str += ' , '
  out_list.append(out_str)
  print out_str
#  print >> fout, out_str

## print out title
for t in terms:
  title += ' , ' + t
print title
print >> fout, title

## print out records
for r in out_list:
  print >> fout, r
  
fout.close()  