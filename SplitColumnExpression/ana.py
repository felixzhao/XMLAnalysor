
inpath = '1.csv'
outpath = 'out.csv'

lines = open(inpath,'r').readlines()
fout = open(outpath,'w')

terms = []

for l in lines:
  cels = l.split(',')
  exp_list = cels[4].split('&')
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
  out_str = l[:-1] + ' , '
  for t in terms:
    if t in tuples:
      out_str +=  str(tuples[t])
    out_str += ' , '
#  out_str += ' \n'
  print out_str
  print >> fout, out_str

title = 'ruleID,ruleName, groupID, groupName,expression,New Audiencing Rules,'  
for t in terms:
  title += t + ' , '
print >> fout, title
  
fout.close()  